using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace azure_m.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
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

        }

        public void onRecentBtn_Clicked(object sender, EventArgs e)
        {
            swapBtnColors();
            //异步 querying datas, 在此期间出现一个刷新标志
        }

    }
}