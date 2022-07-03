#define DEBUG
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using azure_m.Models;
using azure_m.Models.RequestModels.VMRequestModels.CreateOrUpdate;
using Xamarin.Forms;
using System.Threading.Tasks;
using azure_m.Services;
using System.Diagnostics;

namespace azure_m.ViewModels
{
    public class VMDetailsViewModel : BaseViewModel
    {

        public Dictionary<string, string> subscribes { get; set; } 
        public List<string> subscribesNames { get; set; }
        public string subscribeID;
        public List<string> resourceGroups { get; set; }
        public string ResourceGroup;

        public List<string> AreaSources { get; set; }

        public List<string> Zones { get; set; }
        public Command ZonesIndexChange;

        public List<ImageReference> Images { get; set; }

        public List<string> vmSizes { get; set; }

        public List<string> ports { get; set; }
        public Command portsChange;

        public CreateOrUpdateVMRequest vm = new CreateOrUpdateVMRequest();
        public VMDetailsViewModel()
        {
#if DEBUG
            subscribes = new Dictionary<string, string> { { "免费试用", "123" } };
            resourceGroups = new List<string>{"wfpres", "wfpppres" };
            AreaSources = new List<string> { "(Asia Pacific)Australia East", "(Asia Pacific)Southest Asia(有资格免费试用服务)", };
            Zones = new List<string> { "Zones 1", "Zones 2", "Zones 3" };
            Images = new List<ImageReference> { new ImageReference() { sku = "20_04-lts-gen2", publisher = "Canonical", verison = "latest", offer = "0001-com-ubuntu-server-focal" } };
            vmSizes = new List<string> { "Standard_D2s_v3" };
            ports = new List<string> { "HTTPS(443)", "HTTP(80)","SSH(22)"};

#endif
            subscribesNames = subscribes.Keys.ToList();
            #region Bindings
            Views.AddVmDetailsPage.SubscribeIndexChange += ChangeSubID;
            Views.AddVmDetailsPage.ResourceGroupIndexChanged += (sender, e) => { vm.uri.resourceGroupName = (sender as Picker).SelectedItem.ToString(); };
            Views.AddVmDetailsPage.AreaChanged += (sender, e) => {vm.body.location = AreaSources[(sender as Picker).SelectedIndex]; };
            ZonesIndexChange = new Command((sender) => { 
                //1. clear 2.load WTF why can't clear an array, can it dispose the dangling array?
                //vm.body.zones.
            });
            Views.AddVmDetailsPage.ImagesIndexChanged += (sender, e) => { vm.body.properties.storageProfile.imageReference = Images[(sender as Picker).SelectedIndex]; };
            Views.AddVmDetailsPage.vmSizeIndexChanged+=(sender, e) => { vm.body.properties.hardWareProfile.vmSize = new string[] { vmSizes[(sender as Picker).SelectedIndex] }; };
            Views.AddVmDetailsPage.passwdComplete += (sender, e) => vm.body.properties.osProfile.adminPassword = (sender as Entry).Text.ToString();
            portsChange = new Command((sender) => { });

            #endregion
        }

        private void ChangeSubID(object sender, int i)
        {
            subscribes.TryGetValue(subscribesNames[i], out subscribeID);
        }

        //ContentView basic, disk, net, manage, adv, tag, create;
        //public ObservableCollection<ContentView> pages { get; set; }
        //public void init()
        //{
        //    Title = "创建虚拟机";
        //    basic = new Views.VMDetails.Basic();
        //    disk = new Views.VMDetails.Disk();
        //    net = new Views.VMDetails.Net();
        //    manage = new Views.VMDetails.Manage();
        //    adv = new Views.VMDetails.Advance();
        //    tag = new Views.VMDetails.Tag();
        //    create = new Views.VMDetails.Create();
        //    pages = new ObservableCollection<ContentView>
        //    {
        //        basic, disk,
        //        net,
        //        manage, adv,
        //        tag,
        //        create
        //    };
        //}


    }
}
