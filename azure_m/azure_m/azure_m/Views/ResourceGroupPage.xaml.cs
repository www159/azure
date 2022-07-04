
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace azure_m.Views
{
    using Models;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResourceGroupPage : ContentPage
    {
        public ResourceGroupPage()
        {
            InitializeComponent();
            GetResources();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">0表示Recent，1表示Favorite</param>
        public void GetResources(int type = 0)
        {
            ResourceLayout.Children.Clear();
            List<Resource> resources = new List<Resource>();
            //查询指定资源，放置在ResourcesLayout中
            //resources = await GetResourcesByApi(type)...
            //resources.sort by type nad name (or linq

            ///DEBUG
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
                grid.Children.Add(new Label { FormattedText = formattedString }, 0, 0);
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
                        BackgroundColor = Color.MintCream,
                        RowSpacing = 10,
                        ColumnDefinitions =
                        {
                            //new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
                            new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
                            new ColumnDefinition { Width = new GridLength (2, GridUnitType.Star) },
                            new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) }
                        }
                    };
                    grid.Children.Add(new Image { Source = getSourceByType(o.type), HeightRequest = 15, VerticalOptions = LayoutOptions.Start }, 0, 0);
                    grid.Children.Add(new Label { Text = o.name, HeightRequest = grid.Height, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Start }, 0, 0);
                    grid.Children.Add(new Label { Text = o.location, HeightRequest = grid.Height, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center }, 1, 0);
                    ResourceLayout.Children.Add(grid);
                });
            }

        }

        private ImageSource getSourceByType(string type)
        {
            //DEBUG
            return "vm2.png";
        }
    }
}