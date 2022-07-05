#define DEBUG
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using azure_m.Models;
using azure_m.Models.RequestModels.VMRequestModels.CreateOrUpdate;
using azure_m.Models.RequestModels.NetworkInterfaceRequestModels;
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
        public Command ZonesIndexChange { get; set; }

        public List<ImageReference> Images { get; set; }

        public List<string> vmSizes { get; set; }

        public List<string> ports { get; set; }
        public Command portsChange { get; set; }

        public List<string> vnetworks { get; set; }

        public List<string> subnets { get; set; }

        public List<string> publicIPs { get; set; }

        public List<string> net_ports { get; set; }
        public Command net_portsChange { get; set; }


        public string mail { get; set; }
        public string PhoneNumber { get; set; }

        public Command CreateOrUpdateVM { get; set; }

        public CreateOrUpdateNIRequest nIRequest { get; set; } = new CreateOrUpdateNIRequest { body = new CreateOrUpdateNIBody { properties = new NetworkInterfacesProperties { ipConfigurations = new NetworkInterfaceIPConfiguration[1] } } };

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
            net_ports = new List<string> { "HTTPS(443)", "HTTP(80)", "SSH(22)","RDP(3389)" };

#endif  

            subscribesNames = subscribes.Keys.ToList();
            #region Bindings
            Views.AddVmDetailsPage.SubscribeIndexChange += ChangeSubID;
            Views.AddVmDetailsPage.ResourceGroupIndexChanged += (sender, e) => { vm.uri.resourceGroupName = (sender as Picker).SelectedItem.ToString(); };
            Views.AddVmDetailsPage.AreaChanged += (sender, e) => {vm.body.location = AreaSources[(sender as Picker).SelectedIndex]; };
            vmNameComplete=new Command((sender) => { vm.uri.vmName = vm.body.properties.osProfile.computerName = (sender as Entry).Text; });
            ZonesIndexChange = new Command((sender) => {
                if (vm.body.zones != null && vm.body.zones.Length != 0) { Array.Clear(vm.body.zones, 0, vm.body.zones.Length); }
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

            Views.AddVmDetailsPage.vnetChanged += (sender, e) => {
                nIRequest.body.properties.ipConfigurations[0] = new NetworkInterfaceIPConfiguration
                {
                    properties = new NetworkInterfaceIPConfigurationProperties
                    {

                    }
                };
                vm.body.properties.networkProfile.networkInterfaces[0] = new NetworkInterface
                {
                    id = $"/subscriptions/{QueryInfo.subscriptionId}/resourceGroups/{vm.uri.resourceGroupName}/providers/Microsoft.Network/networkInterfaces/{UID}",
                    properties = new NetworkInterfaceProperties { primary = true }
                };
            };
            Views.AddVmDetailsPage.subnetChanged += (sender, e) =>
            {
                nIRequest.body.properties.ipConfigurations[0] = new NetworkInterfaceIPConfiguration
                {
                    properties = new NetworkInterfaceIPConfigurationProperties
                    {

                    }
                };
                vm.body.properties.networkProfile.networkInterfaces[0] = new NetworkInterface
                {
                    id = $"/subscriptions/{azure_m.Services.QueryInfo.subscriptionId}/resourceGroups/{vm.uri.resourceGroupName}/providers/Microsoft.Network/networkInterfaces/{UID}",
                    properties = new NetworkInterfaceProperties { primary = true }
                };
            };
            Views.AddVmDetailsPage.publicIPChanged += (sender, e) => {//当nic更改时,应直接修改nIrequest
                nIRequest.body.properties.ipConfigurations[0] = new NetworkInterfaceIPConfiguration {
                    properties = new NetworkInterfaceIPConfigurationProperties
                    {

                    }
                };
                vm.body.properties.networkProfile.networkInterfaces[0] =  new NetworkInterface
                {
                    id = $"/subscriptions/{azure_m.Services.QueryInfo.subscriptionId}/resourceGroups/{vm.uri.resourceGroupName}/providers/Microsoft.Network/networkInterfaces/{UID}",
                    properties = new NetworkInterfaceProperties { primary = true }
                };
            };
            Views.AddVmDetailsPage.DeleteOptionChanged += (sender, e) => { vm.body.properties.networkProfile.networkInterfaces[0].properties.deleteOptions = (sender as CheckBox).IsChecked ? "Delete" : "Detach"; };

            //TODO:未完成的commands
            Views.AddVmDetailsPage.diskTypeIndexChanged+=(sender, e) => { };
            portsChange = new Command((sender) => { });
            net_portsChange = new Command((sender) => { });
            CreateOrUpdateVM = new Command((sender) => { //创建或更新，发送请求
                //publicIP
                //subnet 选择的是已经有的subnet, 选择默认的ipaddress？
                //nic 创建一个叫{UID}的nic

                (new VMDataStore()).queryCreateOrUpdateVM(vm);//调用，创建
            });

        #endregion
        }

        private void ChangeSubID(object sender, int i)
        {
            subscribes.TryGetValue(subscribesNames[i], out subscribeID);
            
        }
    }
}
