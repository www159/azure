using azure_m.Models;
using azure_m.Models.ResponseModels;
using azure_m.Services;
using System;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace azure_m.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public class VMDetailViewModel: BaseViewModel
    {
        #region 引用类的重命名
        public class ImageReference:Models.RequestModels.VM.CreateOrUpdate.ImageReference{}
        public class vmSize:Models.ResponseModels.VMSize{}
        #endregion
        public IDataStore<VirtualMachine> VMDataStore => DependencyService.Get<IDataStore<VirtualMachine>>();
        public VirtualMachine VM {get; set;}
        
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
            set{ VM.name = value; SetProperty(ref _vmName, value);}
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

        private string _publicIP;
        public string PublicIP{
            get => "20.210.244.174";//for test
        }


        public async void LoadVMId(string VMId){
            try{
                var qvm = await VMDataStore.GetItemAsync(VMId);
                Id = qvm.id;
                VMName = qvm.name;
                RGName = Regex.Match(qvm.id, $"(?<=(resourceGroups/))[.\\s\\S]*?(?=(/))").Value;
                Location = qvm.location;
                Image = qvm.properties.storageProfile.imageReference as ImageReference;
                VMSize = qvm.properties.hardwareProfile.vmSize;
                //PublicIP = ?
            }
            catch(Exception){
                Debug.WriteLine("Failed to Load VM");
            }
        }
    }
}
