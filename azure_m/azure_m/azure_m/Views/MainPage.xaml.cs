#define DEBUG
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace azure_m.Views
{

    using Models;

    public partial class MainPage : ContentPage
    {
        List<StackLayout> ResourcesLayout = null;

        public MainPage()
        {
            InitializeComponent();
            GetResources();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">0表示Recent，1表示Favorite</param>
        public async void  GetResources(int type = 0)
        {
            ResourceLayout.Children.Clear();
            List<Resource> resources = new List<Resource>();
            //查询指定资源，放置在ResourcesLayout中
            //resources = await GetResourcesByApi(type)...
            //resources.sort by type nad name (or linq

#if DEBUG
            if (type == 0)
                
            {
                resources.Add(new Resource
                {
                    id = "1",
                    location = "jp",
                    type = "vm",
                    name = "虚拟机"
                });
                resources.Add(new Resource
                {
                    id = "1",
                    location = "jp",
                    type = "vm",
                    name = "虚拟机"
                });
            }
#else
            resources = await queryResources();
#endif
            //no resources
            if (resources.Count == 0)
            {
                Grid grid = new Grid
                {
                    Margin = new Thickness(20, 0, 20, 0),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    BackgroundColor = Color.MintCream,
                    RowSpacing = 10,
                    RowDefinitions =
                {
                    //new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength (2, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength (1, GridUnitType.Star) }
                }
                };
                var formattedString = new FormattedString();
                formattedString.Spans.Add(new Span { Text = "No resources have been favorited\n", FontAttributes = FontAttributes.Bold });

                var span = new Span { Text = "Favorite resources to quickly navigate to them from the home page." };
                formattedString.Spans.Add(span);
                grid.Children.Add(new Label { FormattedText = formattedString },0,0);
                ResourceLayout.Children.Add(grid);
            }

            else
            {
                resources.ForEach(o =>
                {
                    Grid grid = new Grid
                    {
                        Margin = new Thickness(20, 0, 20, 0),
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        RowSpacing = 10,
                        ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength (2, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) }
                }
                    };
                    grid.Children.Add(new Image { Source = getSourceByType(o.type), HeightRequest = 15, HorizontalOptions = LayoutOptions.Start }, 0, 0);
                    grid.Children.Add(new Label { Text = o.name, HeightRequest = grid.Height, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center }, 0, 0);
                    grid.Children.Add(new Label { Text = o.type, HeightRequest = grid.Height, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center }, 1, 0);
                    grid.Children.Add(new Label { Text = o.location, HeightRequest = grid.Height, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center }, 2, 0);
                    grid.Children.Add(new Xamarin.Forms.Shapes.Rectangle { HeightRequest = 1, VerticalOptions = LayoutOptions.End, BackgroundColor = Color.LightGray },0,3,0,1);
                    ResourceLayout.Children.Add(grid);
                });
            }

        }

        private ImageSource getSourceByType(string kind)
        {
            //DEBUG
            return "vm2.png";
        }

        private void swapBtnColors()
        {
            object bgc = RecentBtn.BackgroundColor, tc = RecentBtn.TextColor, bc = RecentBtn.BorderColor;
            RecentBtn.BackgroundColor = FavoriteBtn.BackgroundColor;
            RecentBtn.TextColor = FavoriteBtn.TextColor;
            RecentBtn.BorderColor = FavoriteBtn.BorderColor;
            FavoriteBtn.BackgroundColor = (Color)bgc;
            FavoriteBtn.TextColor = (Color)tc;
            FavoriteBtn.BorderColor = (Color)bc;
        }

        public void onFavoriteBtn_Clicked(object sender, EventArgs e)
        {
            swapBtnColors();
            //异步 querying datas, 在此期间出现一个刷新标志
            GetResources(1);

        }

        public void onRecentBtn_Clicked(object sender, EventArgs e)
        {
            swapBtnColors();
            //异步 querying datas, 在此期间出现一个刷新标志
            GetResources(0);
        }

        public void OnMyIcon_Clicked(object sender, EventArgs e)
        {
            //this.Navigation.PushAsync(new MyPage());
            DisplayAlert("Alert", "My page", "OK");
        
        }

        public void OnSetting_Clicked(object sender, EventArgs e)
        {
            //this.Navigation.PushAsync(new SettingsPage());
            DisplayAlert("Alert", "SettingPage", "OK");
        }

        public void OnAlert_Clicked(object sender, EventArgs e)
        {
            //this.Navigation.PushAsync(new AlertsPage());

            this.Navigation.PushAsync(new ActivitylogPage());
            DisplayAlert("Alert", "AlertPage", "OK");
        }

        public void OnAdd_Clicked(object sender, EventArgs e)
        {
            //this.Navigation.PushAsync(new AddPage());
            Xamarin.Essentials.Vibration.Vibrate(500);
            Navigation.PushAsync(new AddPage());
        }
        public void OnSubscribe_Clicked(object sender, EventArgs e)
        {
            //this.Navigation.PushAsync(new SubscribePage());
            Navigation.PushAsync(new SubscribePage());
        }
        public void OnVM_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new VirtualMachinePage());
            Navigation.PushAsync(new VirtualMachinePage());
        }
        public void OnDashboard_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new DashboardPage());
            DisplayAlert("Alert", "Dashboard", "OK");
        }
        public void OnMonitor_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MonitorPage());
        }
        public void OnMoreService_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new AllService());
            Navigation.PushAsync(new AllServicePage());
        }

        private void MoreResourceBtn_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("MoreResourceBtn_Clicked", "", "ok");
            Navigation.PushAsync(new AllResourcesPage());
        }
    }
}