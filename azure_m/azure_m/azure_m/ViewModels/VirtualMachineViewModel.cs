using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using azure_m.Models.ResponseModels;
using Xamarin.Forms;

namespace azure_m.ViewModels
{
    public class VirtualMachineViewModel : BaseViewModel
    {
        public List<VirtualMachineResopnse> VmDetails { get; set; }

        public Command OnSelectChanged { get; set; }
        public VirtualMachineViewModel()
        {
            VmDetails = new List<VirtualMachineResopnse>()
            {
                new VirtualMachineResopnse{name="123",location="japanese"},
                new VirtualMachineResopnse{name="456",location="chinese"}
            };
            OnSelectChanged = new Command(sender => {
                var tmp = VmDetails.FirstOrDefault(o => o.name == ((sender as CollectionView).SelectedItem as VirtualMachineResopnse)?.name);
                if (tmp != null)
                {
                    Name = tmp.name;
                    Location=tmp.location;
                    Sku = tmp.properties.storageProfile.imageReference.sku;
                    OSDisk_Name = tmp.properties.storageProfile.osDisk.name;
                    Offer = tmp.properties.storageProfile.imageReference.offer;
                }
            }); 
        }
        public VirtualMachineResopnse virtualMachine  =new VirtualMachineResopnse();

        private string zero;
        public string Name { 
            get { return virtualMachine.name; } 
            set { 
                virtualMachine.name = value;
                SetProperty(ref zero, value);
            } 
        }
        public string Location
        {
            get => virtualMachine.location;
            set {
                virtualMachine.location = value;
                SetProperty(ref zero, value);
            }
        }
        public string OSDisk_Name
        {
            get => virtualMachine.properties.storageProfile.osDisk.name;
            set
            {
                virtualMachine.properties.storageProfile.osDisk.name = value;
                SetProperty(ref zero, value);
            }
        }
        public string Sku
        {
            get => virtualMachine.properties.storageProfile.imageReference.sku;
            set
            {
                virtualMachine.properties.storageProfile.imageReference.sku=value;
                SetProperty(ref zero, value);
            }
        }
        public string Offer
        {
            get => virtualMachine.properties.storageProfile.imageReference.offer;
            set
            {
                virtualMachine.properties.storageProfile.imageReference.offer = value;
                SetProperty (ref zero, value);
            }
        }

    }
   

}