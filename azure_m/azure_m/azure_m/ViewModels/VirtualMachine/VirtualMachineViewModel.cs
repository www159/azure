using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using System.Text;


using azure_m.Models.ResponseModels;
using Xamarin.Forms;

namespace azure_m.ViewModels
{
    using Models;
    using Services;
    using Views;

    public class VirtualMachineViewModel : BaseViewModel
    {

        private VirtualMachine _selectedVM;

        public VMOperations vmOperations => DependencyService.Get<VMOperations>();

        public ObservableCollection<VirtualMachine> VirtualMachines { get; }

        public Command LoadVMsCommand { get; }

        public Command VMSelected { get; }

        public Command JumpCreatePage { get; }


        public VirtualMachineViewModel()
        {

            VirtualMachines = new ObservableCollection<VirtualMachine>();

            LoadVMsCommand = new Command(async async => await ExecLoadVMCommand());

            VMSelected = new Command(async (collection) =>
            {
                var vm = (collection as CollectionView).SelectedItem as VirtualMachine; 
                if (vm == null) return;
                await Shell.Current.GoToAsync($"{nameof(VMDetailPage)}?{nameof(VMDetailViewModel.VMName)}={vm.name}&{nameof(VMDetailViewModel.VMResGrpName)}={vm.resourceGroup}");
            });

            JumpCreatePage = new Command(async () =>
            {
                await Services.Utils.beforeAddVMDetialPage();
                await Shell.Current.GoToAsync($"{nameof(AddVMDetailsPage)}");
            });

        }

        async Task ExecLoadVMCommand()
        {
            IsBusy = true;

            try
            {
                VirtualMachines.Clear();
                var listVirtualMachineResponse = await vmOperations.queryListAllVM();
                foreach (var virtualMachine in listVirtualMachineResponse.value)
                {
                    VirtualMachines.Add(new VirtualMachine
                    {
                        id = virtualMachine.id,
                        name = virtualMachine.name,
                        resourceGroup = Helpers.deSerializeResourceGroup(virtualMachine.id),
                        osDiskSize = $"{virtualMachine.properties.storageProfile.oSDisk.diskSizeGB}GB",
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        //async void OnVMSelected(VirtualMachine vm)
        //{
        //    if (vm == null) return;
        //    await Shell.Current.GoToAsync($"{nameof(VMDetailPage)}?{nameof(VMDetailViewModel.VMName)}={vm.name}");
        //}

        //async void colSelectionChanged(VirtualMachine vm)
        //{
        //    if (vm == null) return;
        //    var vmIns = vmInses.FirstOrDefault((o) => vm.id == o.name);
        //    await Shell.Current.GoToAsync($"{nameof(VMDetailPage)}?{nameof(VMDetailViewModel.VMIns)}={vmIns}");
        //}

    }

}