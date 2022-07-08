#define DEBUG
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using azure_m.Models;

using Xamarin.Forms;
using System.Threading.Tasks;
using azure_m.Services;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace azure_m.ViewModels
{
    using Models.RequestModels.VM.CreateOrUpdate;
    using Models.RequestModels.NetworkInterface.CreateOrUpdate;
    using Models.RequestModels.PublicIPAddress.CreateOrUpdate;
    using Models.RequestModels.VN.CreateOrUpdate;
    using Models.ResponseModels;

    public class VMDetailsViewModel : BaseViewModel
    {

        #region bind properties
        public Guid UID = Guid.NewGuid();

        public int DefaultIndex0 { get; set; } = 0;
        public int DefaultIndex1 { get; set; } = 1;

        public Dictionary<string, string> subscribes { get; set; }
        public List<string> subscribesNames { get; set; }
        public string subscribeID;
        public List<string> resourceGroups { get; set; }
        public string ResourceGroup;

        public Command vmNameComplete { get; set; }

        public List<Location> AreaSources { get; set; }

        public List<string> Zones { get; set; }
        public Command ZonesIndexChange { get; set; }

        public List<ImageReference> Images { get; set; }

        public List<string> vmSizes { get; set; }

        public List<string> ports { get; set; }
        public Command portsChange { get; set; }

        public List<string> vnetworks { get; set; }
        public string Selectedvnet { get; set; }

        public List<string> subnets { get; set; }
        public string Selectedsubnet { get; set; }

        public List<string> publicIPs { get; set; }
        public string SelectedpubIP { get; set; }

        public List<string> net_ports { get; set; }
        public Command net_portsChange { get; set; }


        public string mail { get; set; }
        public string PhoneNumber { get; set; }



        public Command CreateOrUpdateVM { get; set; }
        public static event EventHandler<int> CreateFinishd;

        public CreateOrUpdateNIRequest nIRequest { get; set; } = new CreateOrUpdateNIRequest { body = new CreateOrUpdateNIBody { properties = new NetworkInterfacesProperties { ipConfigurations = new NetworkInterfaceIPConfiguration[1] } } };

        public CreateOrUpdateVMRequest vm = new CreateOrUpdateVMRequest { };

        public string VMName
        {
            get => vm.uri.vmName;
            set => vm.uri.vmName = vm.body.properties.osProfile.computerName = value;
        }

        public string AdminUsername 
        { 
            get => vm.body.properties.osProfile.adminUsername;
            set => vm.body.properties.osProfile.adminUsername = value;
        }


        #endregion

        #region initialize
        public VMDetailsViewModel()
        {
            subscribes = new Dictionary<string, string> { { "免费试用", "123" } };
            //#if DEBUG
            //        resourceGroups = new List<string> { "wfpres", "wfpppres" };
            //        vnetworks = new List<string> { "new_group-vnet" };
            //#endif


            #region 初始化绑定资源

            resourceGroups = new List<string>();
            foreach(var val in QueryInfo.resourceGroups)
            {
                resourceGroups.Add(val.name);
            }

            AreaSources = new List<Location>();
            foreach(var val in QueryInfo.locations)
            {
                AreaSources.Add(val);
            }

            vmSizes = new List<string>();
            foreach (var val in QueryInfo.vmSizes)
            {
                vmSizes.Add(val.name);
            }




            Zones = new List<string> { "Zones 1", "Zones 2", "Zones 3" };
            Images = new List<ImageReference> { new ImageReference() { sku = "20_04-lts-gen2", publisher = "Canonical", version = "latest", offer = "0001-com-ubuntu-server-focal" } };
            ports = new List<string> { "HTTPS(443)", "HTTP(80)", "SSH(22)" };
            net_ports = new List<string> { "HTTPS(443)", "HTTP(80)", "SSH(22)", "RDP(3389)" };

            subscribesNames = subscribes.Keys.ToList();

            #region subscription events
            Views.AddVMDetailsPage.SubscribeIndexChange += ChangeSubID;
            Views.AddVMDetailsPage.ResourceGroupIndexChanged += (sender, e) => { vm.uri.resourceGroupName = (sender as Picker).SelectedItem.ToString(); };
            Views.AddVMDetailsPage.AreaChanged += (sender, e) => { vm.body.location = AreaSources[(sender as Picker).SelectedIndex].name; };
            vmNameComplete = new Command((sender) => { vm.uri.vmName = vm.body.properties.osProfile.computerName = (sender as Entry).Text; });
            ZonesIndexChange = new Command((sender) =>
            {
                if (vm.body.zones != null && vm.body.zones.Length != 0) { Array.Clear(vm.body.zones, 0, vm.body.zones.Length); }
                vm.body.zones = new string[(sender as CollectionView).SelectedItems.Count()];
                int idx = 0;
                foreach (string zone in (sender as CollectionView).SelectedItems) { vm.body.zones[idx++] = zone; }
            });
            Views.AddVMDetailsPage.ImagesIndexChanged += (sender, e) =>
            {
                vm.body.properties.storageProfile.imageReference = Images[(sender as Picker).SelectedIndex];
                if (Regex.IsMatch(vm.body.properties.storageProfile.imageReference.offer, "ubuntu"))
                {
                    vm.body.properties.storageProfile.oSDisk = new OSDisk
                    {
                        osType = "Linux",
                        name = "Disk_" + UID.ToString(),
                        createOption = "FromImage",
                        caching = "ReadWrite",
                        managedDisk = new ManagedDiskParameters { storageAccountType = "Premium_LRS" },
                        diskSizeGB = 30
                    };
                }
            };
            Views.AddVMDetailsPage.vmSizeIndexChanged += (sender, e) => vm.body.properties.hardwareProfile.vmSize = vmSizes[(sender as Picker).SelectedIndex].ToString();
            Views.AddVMDetailsPage.passwdComplete += (sender, e) => vm.body.properties.osProfile.adminPassword = (sender as Entry).Text.ToString();

            Views.AddVMDetailsPage.vnetChanged += (sender, e) =>
            {
            };
            Views.AddVMDetailsPage.subnetChanged += (sender, e) =>
            {
            };
            Views.AddVMDetailsPage.publicIPChanged += (sender, e) =>
            {
            };
            Views.AddVMDetailsPage.DeleteOptionChanged += (sender, e) => { vm.body.properties.networkProfile.networkInterfaces[0].properties.deleteOption = (sender as CheckBox).IsChecked ? "Delete" : "Detach"; };
            Views.AddVMDetailsPage.vnetChanged += (sender, e) => Selectedvnet = (sender as Picker).SelectedItem.ToString();
            Views.AddVMDetailsPage.subnetChanged += (sender, e) => Selectedsubnet = (sender as Picker).SelectedItem.ToString();
            Views.AddVMDetailsPage.publicIPChanged += (sender, e) => SelectedpubIP = (sender as Picker).SelectedItem.ToString();
            Views.AddVMDetailsPage.DeleteOptionChanged += (sender, e) => vm.body.properties.networkProfile.networkInterfaces[0].properties.deleteOption = (sender as CheckBox).IsChecked ? "Delete" : "Detach";

            //TODO:未完成的commands
            Views.AddVMDetailsPage.diskTypeIndexChanged += (sender, e) => { };
            portsChange = new Command((sender) => { });
            net_portsChange = new Command((sender) => { });
            #endregion

            #region 创建虚拟机 Command
            //过程: 创建公网&&创建虚拟网络 -> 创建虚拟网卡 -> 创建虚拟机
            //约定：
            //1. 只有一个系统盘，无数据盘
            //2. 如果区域不同，那么将默认创建虚拟网络
            //3. 无论虚拟网络是否新建，都将使用默认虚拟子网。

            CreateOrUpdateVM = new Command(async (sender) =>
        {

            #region local var
            PublicIPAdressOperations publicIPAddressOperations = new PublicIPAdressOperations();

            VNOperations vnOperations = new VNOperations();

            NetworkInterfaceOperations networkInterfaceOperations = new NetworkInterfaceOperations();

            VMOperations vmDataStore = new VMOperations();

            string publicIPAddressName = $"IP_{UID}";

            string virtualNetworkName = $"{vm.uri.resourceGroupName}_VNET";

            string networkInterfaceName = $"ipconfig_{UID}";

            string resourceGroup = vm.uri.resourceGroupName;
            int StatusCode;
            #endregion

            #region PublicIPAddress
            await publicIPAddressOperations.queryCreateOrUpdatePublicIPAddress(new CreateOrUpdatePublicIPAddressRequest
            {
                body = new CreateOrUpdatePublicIPAddressBody
                {
                    location = vm.body.location,
                },
                uri = new CreateOrUpdatePublicIPAddressUri
                {
                    resourceGroupName = vm.uri.resourceGroupName,
                    publicIpAddressName = publicIPAddressName,
                },
            });
            #endregion

            #region VNet
            await vnOperations.queryCreateOrUpdateVN(new CreateOrUpdateVNRequest
            {
                body = new CreateOrUpdateVNBody
                {
                    location = vm.body.location,
                    properties = new CreateOrUpdateVNProperties
                    {
                        addressSpace = new AddressSpace
                        {
                            addressPrefixes = new string[]
                           {
                                        QueryInfo.ipSpaceDefault
                           }
                        },
                        flowTimeOutInMinutes = QueryInfo.fltominDefault,
                        subnets = new Subnet[] {
                                    new Subnet {
                                        name = QueryInfo.subnetNameDefault,
                                        properties = new SubnetProperties {
                                            addressPrefix = QueryInfo.subnetIPDefault,
                                        }
                                    },
                            },
                    },
                },
                uri = new CreateOrUpdateVNUri
                {
                    resourceGroupName = vm.uri.resourceGroupName,
                    virtualNetworkName = virtualNetworkName,
                }
            });

            #endregion

            #region NIC
            await networkInterfaceOperations.queryCreateOrUpdateNI(new CreateOrUpdateNIRequest
            {
                body = new CreateOrUpdateNIBody
                {
                    properties = new NetworkInterfacesProperties
                    {
                        enableAcceleratedNetworking = false,
                        ipConfigurations = new NetworkInterfaceIPConfiguration[] {
                                    new NetworkInterfaceIPConfiguration {
                                        name = networkInterfaceName,
                                        properties = new NetworkInterfaceIPConfigurationProperties {
                                            publicIPAddress = new PublicIPAddress {
                                                id = QueryInfo.genResourceId(
                                                    ResourceType.publicIPAddresses,
                                                    resourceGroup,
                                                    publicIPAddressName)
                                            },
                                            subnet = new Subnet {
                                                id = QueryInfo.genSubnetId(
                                                    virtualNetworkName,
                                                    resourceGroup,
                                                    QueryInfo.subnetNameDefault
                                                )
                                            }
                                        }
                                    }
                        }
                    },
                    location = vm.body.location,
                },
                uri = new CreateOrUpdateNIUri
                {
                    resourceGroupName = vm.uri.resourceGroupName,
                    networkInterfaceName = networkInterfaceName,
                }
            });

            #endregion

            #region VM
            vm.body.properties.networkProfile.networkInterfaces[0].id = QueryInfo.genResourceId(
                ResourceType.networkInterfaces,
                resourceGroup,
                networkInterfaceName);

            StatusCode = await vmDataStore.queryCreateOrUpdateVM(vm);//调用，创建

            CreateFinishd?.Invoke(this, StatusCode);
            #endregion
        });
            #endregion

            #endregion

        }
        #endregion

        private void ChangeSubID(object sender, int i)
        {
            subscribes.TryGetValue(subscribesNames[i], out subscribeID);
        }
    }
}
