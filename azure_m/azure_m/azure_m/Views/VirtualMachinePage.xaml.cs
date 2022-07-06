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
    public partial class VirtualMachinePage : ContentPage
    {
        public VirtualMachinePage()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            DetailesFrame.IsVisible = true;
            btn.Text = (VirtualMachineList.SelectedItem as azure_m.ViewModels.VmDetails).Name;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DetailesFrame.IsVisible = false;
        }

    }
}