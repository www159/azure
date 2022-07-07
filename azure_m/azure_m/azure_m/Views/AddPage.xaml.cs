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
                async () =>
                {
                    //service
                    ResourceGroupOperations resourceGroupOperations = DependencyService.Get<ResourceGroupOperations>();
                    LocationOperations locationOperations           = DependencyService.Get<LocationOperations>();
                    VMSizesOperations vmSizesOperations             = DependencyService.Get<VMSizesOperations>();

                    //query
                    QueryInfo.resourceGroups = await resourceGroupOperations.ListResourceGroup();
                    QueryInfo.locations      = await locationOperations.queryListLocation();
                    //默认选第一个地区
                    QueryInfo.vmSizes        = await vmSizesOperations.queryListVMSizes(new ListVMSizesRequest
                    {
                        uri = new ListVMSizesUri
                        {
                            location = QueryInfo.locations.FirstOrDefault().name
                        },
                    });
                    //animate
                    Xamarin.Essentials.Vibration.Vibrate(500);
                });
            

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