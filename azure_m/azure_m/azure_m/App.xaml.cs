﻿using azure_m.Services;
using azure_m.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.Identity.Client;

namespace azure_m
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<ResourceDataStore>();
            MainPage = new LoginPage();
            ((LoginPage)MainPage).LoginCompleted += h;
            //LoginPage loginPage = new LoginPage();
            ////VirtualNetworkPage = new AppShell
            //loginPage.LoginCompleted += h;
        }

        public void h(object sender, string e)
        {
            Console.WriteLine(e);
            MainPage=new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
