using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using azure_m.Models;
using Xamarin.Forms;
using System.Threading.Tasks;
using azure_m.Services;
using System.Diagnostics;
using System.Linq;
//using azure_m.Models.RequestModels.VNReuestModels.CreateOrUpdate;
//using azure_m.Models.RequestModels.NetworkInterfaceRequestModels;


namespace azure_m.ViewModels
{
    public class VNDetailsViewModel : BaseViewModel
    {
        public Guid UID = Guid.NewGuid();

        public Dictionary<string, string> subscribes { get; set; }

        public List<string> subscribesNames { get; set; }

        public string subscribeID;

        public List<string> resourceGroups { get; set; }

        public string ResourceGroup;

        public Command vnNameComplete { get; set; }

        public Command IPAddressComplete { get; set; }

        public List<string> AreaSources { get; set; }
        
        public Command CreateOrUpdateVN { get; set; }

        public Models.RequestModels.VN.CreateOrUpdate.CreateOrUpdateVNRequest vn = new Models.RequestModels.VN.CreateOrUpdate.CreateOrUpdateVNRequest();
        public VNDetailsViewModel()
        {
#if DEBUG

            subscribes = new Dictionary<string, string> { { "免费试用", "123" } };
            resourceGroups = new List<string> { "wfpres", "wfpppres" };
            AreaSources = new List<string> { "JapanEast" };
#endif

            subscribesNames = subscribes.Keys.ToList();

            Views.AddVNDetailsPage.SubscribeIndexChange += ChangeSubID;
            Views.AddVNDetailsPage.ResourceGroupIndexChanged += (sender, args) => { vn.uri.resourceGroupName = (sender as Picker).SelectedItem.ToString(); };
            Views.AddVNDetailsPage.AreaChanged += (sender, args) => { vn.body.location = AreaSources[(sender as Picker).SelectedIndex]; };
            Views.AddVNDetailsPage.IPAddressChanged += (sender, args) =>
            {
                vn.body.properties.addressSpace.addressPrefixes[0] = (sender as Entry).Text;
                vn.body.properties.subnets[0].name = "default";
                vn.body.properties.subnets[0].properties.addressPrefix = (sender as Entry).Text;
            };
            Views.AddVNDetailsPage.VNNameChanged += (sender, args) =>
            {
                vn.uri.virtualNetworkName = (sender as Entry).Text;
            };
            //vnNameComplete = new Command((sender) => { vn.uri.virtualNetworkName = (sender as Entry).Text; });       
            //IPAddressComplete = new Command((sender) =>
            //{
            //    vn.body.properties.addressSpace.addressPrefixes[0] = (sender as Entry).Text;
            //    vn.body.properties.subnets[0].name = "default";
            //    vn.body.properties.subnets[0].properties.addressPrefix = (sender as Entry).Text;
            //});
        }




        private void ChangeSubID(object sender, int i)
        {
            subscribes.TryGetValue(subscribesNames[i], out subscribeID);
        }
    }
}
