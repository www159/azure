
using System;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using azure_m.Models.RequestModels.VM.Get;

namespace azure_m.ViewModels
{
    using Services;
    using Models.ResponseModels;
    using Models.RequestModels.VM.Get;
    using Xamarin.Forms;

    [QueryProperty(nameof(VMResGrpName), nameof(VMResGrpName))]
    [QueryProperty(nameof(VMName), nameof(VMName))]
    public class VMDetailViewModel : BaseViewModel
    {
        #region 引用类的重命名
        public class vmSize : Models.ResponseModels.VMSize { }
        #endregion
        public VMOperations VMOperation => DependencyService.Get<VMOperations>();

        private VirtualMachine _vm;
        public VirtualMachine VM
        {
            get => _vm;
            set => SetProperty(ref _vm, value);
        }

        public string Title { get; set; }

        private string _id;
        public string Id
        {
            get => _id;
            set
            {
                SetProperty(ref _id, value);
            }
        }

        private string _vmName = "";
        public string VMName
        {
            get => _vmName;
            set
            {
               Title = value;
                SetProperty(ref _vmName, value);
                checkAndQuery();
            }
        }

        private string _vmResGrpName = "";
        public string VMResGrpName
        {
            get => _vmResGrpName;
            set
            {
                SetProperty(ref _vmResGrpName, value);
                checkAndQuery();
            }

        }

        private string _rGName;
        public string RGName
        {
            get => Regex.Match(VM.id, $"(?<=(resourceGroups/))[.\\s\\S]*?(?=(/))").Value; //regex
            set { SetProperty(ref _rGName, value); }
        }

        private string _location;
        public string Location
        {
            get => _location;
            set { SetProperty(ref _location, value); }
        }

        private ImageReference _image;
        public ImageReference Image
        {
            get => _image;
            set
            {
                SetProperty(ref _image, value);
            }
        }

        private string _vmsize;
        public string VMSize
        {
            get => _vmsize;
            set
            {
                SetProperty(ref _vmsize, value);
            }
        }

        private string _publicIP = "20.210.244.174";
        public string PublicIP
        {
            get => _publicIP;//for test
            set => SetProperty(ref _publicIP, value);
        }

        public VMDetailViewModel()
        {
            /* LoadCommand = new Command(async () =>  await Load(vMRequest))*/
            ;
            _vm = new VirtualMachine();
        }

        private async void checkAndQuery()
        {
            if (_vmName != "" && _vmResGrpName != "")
            {
                VirtualMachine vm = await VMOperation.queryGetVM(new GetVMRequest
                {
                    uri = new GetVMUri
                    {
                        vmName = _vmName,
                        resourceGroupName = _vmResGrpName,
                    }
                });

                VM        = vm;
                Id       = VM.id;
                Location = VM.location;
                Image    = VM.properties.storageProfile.imageReference;
                VMSize   = VM.properties.hardwareProfile.vmSize;
                

            }
        }


        public static Command LoadCommand { get; set; }

        async Task Load(GetVMRequest vMRequest)
        {
            try
            {
                VirtualMachine vm = await VMOperation.queryGetVM(vMRequest);
                VMName = vm.name;
                RGName = Regex.Match(vm.id, $"(?<=(resourceGroups/))[.\\s\\S]*?(?=(/))").Value;
                Location = vm.location;
                Image = vm.properties.storageProfile.imageReference as ImageReference;
                VMSize = vm.properties.hardwareProfile.vmSize;
                //PublicIP = ?
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load VM");
            }
        }
    }

}
