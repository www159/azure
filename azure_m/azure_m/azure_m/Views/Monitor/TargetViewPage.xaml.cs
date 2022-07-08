using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using azure_m.ViewModels;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace azure_m.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class TargetViewPage : ContentPage
    {

        public TargetViewPage()
        {
            InitializeComponent();
            
        }



        private void ChooseTargetClicked(object sender, EventArgs e)
        {
            ChooseTarget.IsVisible = !ChooseTarget.IsVisible;
        }

        private void ApplyTargetClicked(object sender, EventArgs e)
        {     
            ChooseTarget.IsVisible = false;           
        }

        private void CancelTargetClicked(object sender, EventArgs e)
        {
            
            ChooseTarget.IsVisible = false;
        }
   
    }
}