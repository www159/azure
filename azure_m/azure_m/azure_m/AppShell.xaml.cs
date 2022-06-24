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
            Routing.RegisterRoute(nameof(VirtualNetworkPage), typeof(VirtualNetworkPage));
            Routing.RegisterRoute(nameof(MonitorPage), typeof(MonitorPage));
            this.CurrentItem = Home;
        }

        private  void onMenuBtn_Clicked(object sender, EventArgs e)
        {
             Shell.Current.FlyoutIsPresented = false;
            

        }

        private void StarFlyoutItem_Clicked(object sender, EventArgs e)
        {
            StarItems.IsVisible = !StarItems.IsVisible;
            StarItems.IsEnabled = !StarItems.IsEnabled;
            ///HACK: 通过数据绑定控制这里的ImageSource
            StarFlyoutItem.IconImageSource = StarFlyoutItem.IconImageSource.ToString().Equals("File: up4.png") ? "down4.png" : "up4.png";
        }
    }
}
