using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using azure_m.Models;
using azure_m.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace azure_m.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllServicePage : ContentPage
    {
        public AllServicePage()
        {
            InitializeComponent();
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VirtualMachinePage());
        }

        private async void ImageButton_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ResourceGroupPage());
        }

        private async void ImageButton_Clicked_3(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AllResourcesPage());
        }

        private async void ImageButton_Clicked_4(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AllResourcesPage());
        }

        private async void ImageButton_Clicked_5(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AllResourcesPage());
        }

        private async void ImageButton_Clicked_6(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SubscribePage());
        }

        private async void ImageButton_Clicked_7(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AllResourcesPage());
        }

        private void ImageButton_Clicked_8(object sender, EventArgs e)
        {

        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var imagesender = (Image)sender;
            sub2.IsVisible = !sub2.IsVisible;
            if (sub2.IsVisible)
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
            sub.IsVisible = !sub.IsVisible;
            if (sub.IsVisible)
            {
                imagesender.Source = "down4.png";
            }
            else
            {
                imagesender.Source = "up4.png";
            }
        }
        public void OnMy_Clicked(object sender, EventArgs e)
        {
            //this.Navigation.PushAsync(new MyPage());
        }

        public void OnSetting_Clicked(object sender, EventArgs e)
        {
            //this.Navigation.PushAsync(new SettingsPage());
        }

        public void OnAlert_Clicked(object sender, EventArgs e)
        {
            //this.Navigation.PushAsync(new AlertsPage());
        }
    }


}
