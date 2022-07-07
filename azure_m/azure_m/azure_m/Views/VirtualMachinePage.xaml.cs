using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using azure_m.ViewModels;

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


        private void Button_Clicked(object sender, EventArgs e)
        {
            VirtualMachineList.SelectedItem = null;
            DetailesFrame.IsVisible = false;
        }

        private void VirtualMachineList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DetailesFrame.IsVisible = true;           
        }

        private void LogBtn_Clicked(object sender, EventArgs e)
        {

        }
    }
}