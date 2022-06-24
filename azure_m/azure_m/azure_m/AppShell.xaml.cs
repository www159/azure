﻿using azure_m.ViewModels;
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
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

        private  void onMenuBtn_Clicked(object sender, EventArgs e)
        {
             Shell.Current.FlyoutIsPresented = false;
            

        }

    }
}
