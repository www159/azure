using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace azure_m.Views
{
    using ViewModels;
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VirtualMachinePage : ContentPage
    {

        private VirtualMachineViewModel vnViewModel;

        public VirtualMachinePage()
        {
            BindingContext = vnViewModel = new VirtualMachineViewModel();
            InitializeComponent();
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
  
        }

        private void VirtualMachineList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //DetailesFrame.IsVisible = true;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vnViewModel.OnAppearing();

        }
    }
}