using System;
using System.Collections.Generic;
using System.Text;

namespace azure_m.ViewModels
{
    using Models.ResponseModels;
    using Xamarin.Forms;

    [QueryProperty(nameof(VNResGrpName), nameof(VNResGrpName))]
    [QueryProperty(nameof(VNName), nameof(VNName))]
    public class VNDetailViewModel : BaseViewModel
    {
        private string vnName;

        private string vnResGrpName;

        public string VNName { get => vnName; set => SetProperty(ref vnName, value); }

        public string VNResGrpName { get => vnResGrpName; set => SetProperty(ref vnResGrpName, value); }

        public VNDetailViewModel()
        {

        }
    }
}
