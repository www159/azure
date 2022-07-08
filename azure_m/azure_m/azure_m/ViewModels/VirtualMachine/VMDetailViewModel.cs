using System;
using System.Collections.Generic;
using System.Text;

namespace azure_m.ViewModels
{
    using Models.ResponseModels;
    using Xamarin.Forms;

    [QueryProperty(nameof(VMResGrpName), nameof(VMResGrpName))]
    [QueryProperty(nameof(VMName), nameof(VMName))]

    public class VMDetailViewModel: BaseViewModel
    {
        private string vmName;

        private string vmResGrpName;

        public string VMName { get => vmName; set => SetProperty(ref vmName, value); }

        public string VMResGrpName { get => vmResGrpName; set => SetProperty(ref vmResGrpName, value); }

        public VMDetailViewModel()
        {
            
        }
    }
}
