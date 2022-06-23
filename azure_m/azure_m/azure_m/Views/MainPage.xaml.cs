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

<<<<<<< HEAD
        public void OnMyIcon_Clicked(object sender, EventArgs e)
        {
            //this.Navigation.PushAsync(new MyPage());
            DisplayAlert("Alert", "My page", "OK");
        }

        public void OnSetting_Clicked(object sender, EventArgs e)
        {
            //this.Navigation.PushAsync(new SettingsPage());
            DisplayAlert("Alert", "SettingPage", "OK");
        }

        public void OnAlert_Clicked(object sender, EventArgs e)
        {
            //this.Navigation.PushAsync(new AlertsPage());
            DisplayAlert("Alert", "AlertPage", "OK");
        }

        public void OnAdd_Clicked(object sender, EventArgs e)
        {
            //this.Navigation.PushAsync(new AddPage());
            DisplayAlert("Alert", "AddPage", "OK");
        }
        public void OnSubscribe_Clicked(object sender, EventArgs e)
        {
            //this.Navigation.PushAsync(new SubscribePage());
            DisplayAlert("Alert", "SubscribePage", "OK");
        }
        public void OnVM_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new VirtualMachinePage());
            DisplayAlert("Alert", "VMPage", "OK");
        }
        public void OnDashboard_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new DashboardPage());
            DisplayAlert("Alert", "Dashboard", "OK");
        }
        public void OnMonitor_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new Monitor());
            DisplayAlert("Alert", "MonitorPage", "OK");
        }
        public void OnMoreService_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new AllService());
            DisplayAlert("Alert", "AllService", "OK");
        }

=======
>>>>>>> VirtualNetwork
    }
}