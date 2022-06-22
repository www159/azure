using azure_m.ViewModels;
using azure_m.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace azure_m
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

        private async void onMenuBtn_Clicked(object sender, EventArgs e)
        {
            //TODO: 这里修改为侧边栏收回
            await Shell.Current.GoToAsync("//MainPage");
            
        }

    }
}
