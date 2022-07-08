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
    using Services;
    using Models.RequestModels.VMSizes.List;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {
        
        public AddPage()
        {
            InitializeComponent();
        }

        public void CreateServiceVM(object sender, EventArgs e)
        {
            DisplayAlert("VM", "", "OK");
#pragma warning disable
            Helpers.AsyncbeforeJump(
                Navigation,
                typeof(AddVMDetailsPage),
                Services.Utils.beforeAddVMDetialPage
                );
            

        }
        public void CreateServiceFuncApp(object sender, EventArgs e)
        {
            DisplayAlert("FuncApp", "", "OK");
        }
        public void CreateServiceWebApp(object sender, EventArgs e)
        {
            DisplayAlert("WebApp", "", "OK");
        }

        public void Createwin19(object sender, EventArgs e)
        {
            DisplayAlert("win19", "", "OK");
        }
        public void Createubuntu20(object sender, EventArgs e)
        {
            DisplayAlert("u20", "", "OK");
        }
        public void Createwin10(object sender, EventArgs e)
        {
            DisplayAlert("win10", "", "OK");
        }
        public void GetInformation(object sender, EventArgs e)
        {

            DisplayAlert("how to pass parameter?", $"{e}", "OK");
        }
    }
}