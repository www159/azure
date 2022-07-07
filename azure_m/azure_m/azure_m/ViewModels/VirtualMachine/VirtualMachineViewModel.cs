using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;


using azure_m.Models.ResponseModels;
using Xamarin.Forms;

namespace azure_m.ViewModels
{
    using Models.ResponseModels;
    public class VirtualMachineViewModel : BaseViewModel
    {
        public ObservableCollection<VirtualMachine> VirtualMachines { get; set; }

        public Command LoadVMsCommand;


        public VirtualMachineViewModel()
        {


        }

        public VirtualMachineResponse virtualMachine { get; set; } 
    }

}