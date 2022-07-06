using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace azure_m.ViewModels
{
    public class VirtualMachineViewModel : ContentView
    {
        public List<VmDetails> VmDetails { get; set; }
        public VirtualMachineViewModel()
        {
            VmDetails = new List<VmDetails>()
            {
                new VmDetails() { Name = "好啊",SourceGroup="vm",Size="不知道" },
                new VmDetails(){Name="不是很ok",SourceGroup="disk",Size="第二个"}
            };
        }
    }

    public class VmDetails
    {
        public string Name { get; set; }
        public string SourceGroup { get; set; }
        public string Size { get; set; }
    }
}