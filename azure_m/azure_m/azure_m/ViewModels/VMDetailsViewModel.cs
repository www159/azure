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
using System.Text.RegularExpressions;

namespace azure_m.ViewModels
{
    public class VMDetailsViewModel : BaseViewModel
    {
        public Guid UID =Guid.NewGuid();

        public Dictionary<string, string> subscribes { get; set; } 
        public List<string> subscribesNames { get; set; }
        public string subscribeID;
        public List<string> resourceGroups { get; set; }
        public string ResourceGroup;

        public Command vmNameComplete { get; set; }

        public List<string> AreaSources { get; set; }

        public List<string> Zones { get; set; }
        public Command ZonesIndexChange;

        public List<ImageReference> Images { get; set; }

        public List<string> vmSizes { get; set; }

        public List<string> ports { get; set; }
        public Command portsChange;

        public List<string> vnetworks { get; set; }

        public List<string> subnets { get; set; }

        public List<string> publicIPs { get; set; }

        public List<NetworkInterface> networkInterfaces { get; set; }

        public CreateOrUpdateVMRequest vm = new CreateOrUpdateVMRequest();
        public VMDetailsViewModel()
        {
#if DEBUG
            subscribes = new Dictionary<string, string> { { "免费试用", "123" } };
            resourceGroups = new List<string> { "wfpres", "wfpppres" };
            AreaSources = new List<string> { "japaneast" };
            Zones = new List<string> { "Zones 1", "Zones 2", "Zones 3" };
            Images = new List<ImageReference> { new ImageReference() { sku = "20_04-lts-gen2", publisher = "Canonical", verison = "latest", offer = "0001-com-ubuntu-server-focal", communityGalleryImageId = "", exactVersion = "", shareGalleryImageId = "" } };
            vmSizes = new List<string> { "Standard_D2s_v3", "Standard_B1s" };
            ports = new List<string> { "HTTPS(443)", "HTTP(80)", "SSH(22)" };

            vnetworks = new List<string> { "new_group-vnet" };
            networkInterfaces = new List<NetworkInterface> {  };

#endif
            subscribesNames = subscribes.Keys.ToList();
            #region Bindings
            Views.AddVmDetailsPage.SubscribeIndexChange += ChangeSubID;
            Views.AddVmDetailsPage.ResourceGroupIndexChanged += (sender, e) => { vm.uri.resourceGroupName = (sender as Picker).SelectedItem.ToString(); };
            Views.AddVmDetailsPage.AreaChanged += (sender, e) => {vm.body.location = AreaSources[(sender as Picker).SelectedIndex]; };
            vmNameComplete=new Command((sender) => { vm.uri.vmName = vm.body.properties.osProfile.computerName = (sender as Entry).Text; });
            ZonesIndexChange = new Command((sender) => {
                Array.Clear(vm.body.zones, 0, vm.body.zones.Length);
                vm.body.zones = new string[(sender as CollectionView).SelectedItems.Count()];
                int idx = 0;
                foreach(string zone in (sender as CollectionView).SelectedItems) { vm.body.zones[idx++]=zone; }
            });
            Views.AddVmDetailsPage.ImagesIndexChanged += (sender, e) =>
            {
                vm.body.properties.storageProfile.imageReference = Images[(sender as Picker).SelectedIndex];
                if (Regex.IsMatch(vm.body.properties.storageProfile.imageReference.offer, "ubuntu"))
                {
                    vm.body.properties.storageProfile.oSDisk = new OSDisk
                    {
                        osType = "Linux",
                        name = "Disk_" + UID.ToString(),
                        createOptions = "FromImage",
                        caching = "ReadWrite",
                        managedDisk = new ManagedDiskParameters { storageAccountType = "Premium_LRS" },
                        diskSizeGB = 30
                    };
                }
            };
            Views.AddVmDetailsPage.vmSizeIndexChanged+=(sender, e) => { vm.body.properties.hardWareProfile.vmSize = new string[] { vmSizes[(sender as Picker).SelectedIndex] }; };
            Views.AddVmDetailsPage.passwdComplete += (sender, e) => vm.body.properties.osProfile.adminPassword = (sender as Entry).Text.ToString();
            portsChange = new Command((sender) => { });

            Views.AddVmDetailsPage.diskTypeIndexChanged+=(sender, e) => { };

            Views.AddVmDetailsPage.nicChanged += (sender, e) => {//新建一个nic
                networkInterfaces.Add(new NetworkInterface
                {
                    id = $"/subscriptions/{azure_m.Services.QueryInfo.subid}/resourceGroups/{vm.uri.resourceGroupName}/providers/Microsoft.Network/networkInterfaces/{UID}",
                    properties = new NetworkInterfaceProperties { primary = true }
                });
            };

        #endregion
        }

        private void ChangeSubID(object sender, int i)
        {
            subscribes.TryGetValue(subscribesNames[i], out subscribeID);
        }
    }
}
