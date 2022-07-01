#define DEBUG

using azure_m.Services;
using azure_m.Views;
using System;
using System.Threading;
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

           // MainPage = new Page1();

            MainPage = new LoginPage();
            (MainPage as LoginPage).LoginComplete += App_LoginComplete;

            var ret = Utils.readMock<azure_m.Models.MockModels.Index>(azure_m.Mocks.Mocks.index);
            

        }

        public static object parentWindow { get; set; } 

       
        private void App_LoginComplete(object sender,EventArgs e)
        {

            MainPage=new AppShell();
        }
        
        public void startBack()
        {
            System.Diagnostics.Process backProc = new System.Diagnostics.Process();
            var current = System.IO.Directory.GetCurrentDirectory();
            //backProc.StartInfo.FileName = @System.Environment.CurrentDirectory + @"..\..\presudo_back\bin\Release\net6.0\publish\pesudo_back.dll";
            //backProc.Start();

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
