using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using azure_m.Views;

namespace azure_m.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public Command OpenMonitor { get; }
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
            OpenMonitor = new Command(OnMonitorClicked);
        }

        private async void OnMonitorClicked(Object obj) 
        {
            await Shell.Current.GoToAsync($"//{nameof(MonitorPage)}");
        }

        public ICommand OpenWebCommand { get; }
    }
}