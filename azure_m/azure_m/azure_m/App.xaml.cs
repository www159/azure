#define DEBUG
#if DEBUG
using System.Text.RegularExpressions;
#endif
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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjY0MzM5QDMyMzAyZTMxMmUzME5POGpvUUM2bGx6SGJscW5Xcm52Y3ZzdXhpQjc3OFV0TVYvTEM3SnRJUVk9");
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            QueryInfo.registerGlobal();

           // MainPage = new Page1();

            MainPage = new LoginPage();
            (MainPage as LoginPage).LoginComplete += App_LoginComplete;
            
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
