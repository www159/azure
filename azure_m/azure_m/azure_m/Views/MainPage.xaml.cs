using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using azure_m.Models;

namespace azure_m.Views
{
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
        public void  GetResources(int type = 0)
        {
            ResourceLayout.Children.Clear();
            List<azure_m.Models.Resource> resources = new List<azure_m.Models.Resource>();
            //查询指定资源，放置在ResourcesLayout中
            //resources = await GetResourcesByApi(type)...
            //resources.sort by type nad name 

            ///DEBUG
            if(type == 0)
            {
                resources.Add(new Resource( "jp", "vm", "1", "虚拟机"));
                resources.Add(new Resource( "jp", "vm", "1", "虚拟机"));
            }

            resources.ForEach(o => {
                Grid grid = new Grid
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    ColumnDefinitions =
                {
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto }
                }
                };
                grid.Children.Add(new Image { Source=getSourceByType(o.type), HeightRequest=15, VerticalOptions=LayoutOptions.Center},0,0);
                grid.Children.Add(new Label { Text=o.name, HeightRequest=grid.Height, VerticalOptions=LayoutOptions.Center, HorizontalOptions=LayoutOptions.Start},1,0);
                grid.Children.Add(new Label { Text = o.type, HeightRequest=grid.Height, VerticalOptions=LayoutOptions.Center, HorizontalOptions=LayoutOptions.Center},2,0);
                //grid.Children.Add(new Label { Text = o.ChangeTime, HeightRequest=grid.Height, VerticalOptions=LayoutOptions.Center, HorizontalOptions= LayoutOptions.End},3,0);

                ResourceLayout.Children.Add(grid);
            });

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
            GetResources(1);
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
            DisplayAlert("Alert", "AlertPage", "OK");
        }

        public void OnAdd_Clicked(object sender, EventArgs e)
        {
            //this.Navigation.PushAsync(new AddPage());
            DisplayAlert("Alert", "AddPage", "OK");
        }
        public void OnSubscribe_Clicked(object sender, EventArgs e)
        {
            //this.Navigation.PushAsync(new SubscribePage());
            DisplayAlert("Alert", "SubscribePage", "OK");
        }
        public void OnVM_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new VirtualMachinePage());
            DisplayAlert("Alert", "VMPage", "OK");
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
            DisplayAlert("Alert", "AllService", "OK");
        }

        private void MoreResourceBtn_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("MoreResourceBtn_Clicked", "", "ok");
        }
    }
}