using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using azure_m.Models.ResponseModels;
using Xamarin.Forms;

namespace azure_m.ViewModels
{
    public class VirtualMachineViewModel : ContentView
    {
        public List<VirtualMachineResopnse> VmDetails { get; set; }
        public VirtualMachineViewModel()
        {
            VmDetails = new List<azure_m.Models.ResponseModels.VirtualMachineResopnse>()
            {
                new azure_m.Models.ResponseModels.VirtualMachineResopnse(){name="123"}
            };
            virtualMachine = new VirtualMachineResopnse()
            {
                name = "wmwmw",
                location= "japaneast",
            };
        }

        public VirtualMachineResopnse virtualMachine { get; set; } 
    }

}