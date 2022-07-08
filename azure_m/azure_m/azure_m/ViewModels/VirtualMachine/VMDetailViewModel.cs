using azure_m.Models;
using azure_m.Models.ResponseModels;
using azure_m.Services;
using System;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using azure_m.Models.RequestModels.VM.Get;

namespace azure_m.ViewModels
{
    using Models.ResponseModels;
    using Xamarin.Forms;

    [QueryProperty(nameof(VMResGrpName), nameof(VMResGrpName))]
    [QueryProperty(nameof(VMName), nameof(VMName))]
    public class VMDetailViewModel : BaseViewModel
    {
        #region 引用类的重命名
        public class ImageReference:Models.RequestModels.VM.CreateOrUpdate.ImageReference{}
        public class vmSize:Models.ResponseModels.VMSize{}
        #endregion
        public VMOperations VMOperation => DependencyService.Get<VMOperations>();
        public VirtualMachine VM {get; set;}
        public string Title { get; set; }
        private string _id;
        public string Id{
            get =>VM.id;
            set
            { 
                VM.id = value;
                SetProperty(ref _id,value);
            }
        }

        private string _vmName;
        public string VMName {
            get =>VM.name;
            set{ VM.name = Title= value; SetProperty(ref _vmName, value);}
        }

        private string _rGName;
        public string RGName {
            get => Regex.Match(VM.id, $"(?<=(resourceGroups/))[.\\s\\S]*?(?=(/))").Value; //regex
            set { SetProperty(ref _rGName, value);}
        }

        private string _location;
        public string Location{
            get => VM.location;
            set { VM.location = value; SetProperty(ref _location, value);}
        }

        private ImageReference _image;
        public ImageReference Image{
            get=>VM.properties.storageProfile.imageReference as ImageReference;
            set{
                VM.properties.storageProfile.imageReference = value;
                SetProperty(ref _image,value);
            }
        }

        private string _vmsize;
        public string VMSize {
            get => VM.properties.hardwareProfile.vmSize;
            set {
                VM.properties.hardwareProfile.vmSize = value;
                SetProperty(ref _vmsize, value);
            }
        }

        private string _publicIP = "20.210.244.174";
        public string PublicIP{
            get => _publicIP;//for test
            set => SetProperty(ref _publicIP, value);
        }

        public VMDetailViewModel(GetVMRequest vMRequest)
        {
            LoadCommand = new Command(async () =>  await Load(vMRequest));
        }


        public static Command LoadCommand { get; set; }
        async Task Load(GetVMRequest vMRequest)
        {
            try{
                VirtualMachine vm =  await VMOperation.queryGetVM(vMRequest);
                VMName = vm.name;
                RGName = Regex.Match(vm.id, $"(?<=(resourceGroups/))[.\\s\\S]*?(?=(/))").Value;
                Location = vm.location;
                Image = vm.properties.storageProfile.imageReference as ImageReference;
                VMSize = vm.properties.hardwareProfile.vmSize;
                //PublicIP = ?
            }
            catch(Exception){
                Debug.WriteLine("Failed to Load VM");
            }
        }
    }

}
