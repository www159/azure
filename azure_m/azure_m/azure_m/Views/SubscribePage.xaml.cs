using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace azure_m.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubscribePage : ContentPage
    {
        public SubscribePage()
        {
            InitializeComponent();
        }

        private void OnAddFilterClicked(object sender, EventArgs e)
        {
            var button = new Button { CornerRadius = 20, Text = "待定" };
            Choose.Children.Add(button);
        }
        private void OnMoreClicked(object sender, EventArgs e)
        {

        }
        private void OnShutDownClicked(object sender, EventArgs e)
        {
            Subscribe.IsVisible = false;
        }
        private void OnAddSubscribeClicked(object sender, EventArgs e)
        {
            Subscribe.IsVisible = true;
        }
        private void OnManageClicked(object sender, EventArgs e)
        {

        }
        private void OnCheckClicked(object sender, EventArgs e)
        {
            
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var imagesender = (Image)sender;
            Favorite.IsVisible = !Favorite.IsVisible;
            if (Favorite.IsVisible)
            {
                imagesender.Source = "down4.png";
            }
            else
            {
                imagesender.Source = "up4.png";
            }
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            var imagesender = (Image)sender;
            All.IsVisible = !All.IsVisible;
            if (All.IsVisible)
            {
                imagesender.Source = "down4.png";
            }
            else
            {
                imagesender.Source = "up4.png";
            }
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            var imagesender = (Image)sender;
            Favorite.IsVisible = !Favorite.IsVisible;
            if (Favorite.IsVisible)
            {
                imagesender.Source = "down4.png";
            }
            else
            {
                imagesender.Source = "up4.png";
            }
        }
    }
}