using azure_m.Services;
using azure_m.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace azure_m
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
<<<<<<< HEAD
            MainPage = new AllResourcesPage();
=======
            MainPage = new AppShell();
            //VirtualNetworkPage = new AppShell();
>>>>>>> VirtualNetwork
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
