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
            Routing.RegisterRoute(nameof(AllResourcesPage), typeof(AllResourcesPage)); 
            Routing.RegisterRoute(nameof(AllServicePage), typeof(AllServicePage));
            Routing.RegisterRoute(nameof(AddPage), typeof(AddPage));

            Routing.RegisterRoute(nameof(VirtualMachinePage), typeof(VirtualMachinePage));
            Routing.RegisterRoute(nameof(VMDetailPage), typeof(VMDetailPage));
            Routing.RegisterRoute(nameof(AddVMDetailsPage), typeof(AddVMDetailsPage));

            Routing.RegisterRoute(nameof(VirtualNetworkPage), typeof(VirtualNetworkPage));
            Routing.RegisterRoute(nameof(VNDetailPage), typeof(VNDetailPage));
            Routing.RegisterRoute(nameof(AddVNDetailsPage), typeof (AddVNDetailsPage));

            Routing.RegisterRoute(nameof(ResourceGroupPage), typeof(ResourceGroupPage));
            this.CurrentItem = Home;
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
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
            //StarFlyoutItem.IconImageSource = StarFlyoutItem.IconImageSource.ToString().Equals("File: up4.png") ? "down4.png" : "up4.png";
        }
    }
}
