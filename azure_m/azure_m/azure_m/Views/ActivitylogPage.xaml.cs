using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using azure_m.ViewModels;

namespace azure_m.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivitylogPage : ContentPage
    {
        ActivitylogViewModel activitylogViewModel;
        public ActivitylogPage()
        {
            InitializeComponent();
            BindingContext = activitylogViewModel = new ActivitylogViewModel();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            activitylogViewModel.OnAppearing();
        }
    }
}