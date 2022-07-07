using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace azure_m.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class MonitorPage : ContentPage
{
    public MonitorPage()
    {
        InitializeComponent();
    }
        public async void OnTargetViewClick(object obj,EventArgs e) 
        {
            await Navigation.PushAsync(new TargetViewPage());
        }
        public async void OnWarnViewClick(object obj, EventArgs e)
        {
            await Navigation.PushAsync(new WarnViewPage());
        }
        public async void OnLogViewClick(object obj, EventArgs e)
        {
            await Navigation.PushAsync(new LogViewPage());
        }
    }
}