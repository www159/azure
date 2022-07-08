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

    public class VirtualNetworkViewModel : BaseViewModel
    {

        private VirtualNetwork _selectedVN;

        public VNOperations vnOperations => DependencyService.Get<VNOperations>();

        public ObservableCollection<VirtualNetwork> VirtualNetworks { get; }

        public Command LoadVNsCommand { get; }

        public Command VNSelected { get; }

        public VirtualNetworkViewModel()
        {

            VirtualNetworks = new ObservableCollection<VirtualNetwork>();

            LoadVNsCommand = new Command(async async => await ExecLoadVNCommand());

            VNSelected = new Command(async (collection) =>
            {
                var vn = (collection as CollectionView).SelectedItem as VirtualNetwork;
                if (vn == null) return;
                await Shell.Current.GoToAsync($"{nameof(VNDetailPage)}?{nameof(VNDetailViewModel.VNName)}={vn.name}&{nameof(VNDetailViewModel.VNResGrpName)}={vn.resourceGroup}");
            });

        }

        async Task ExecLoadVNCommand()
        {
            IsBusy = true;

            try
            {
                VirtualNetworks.Clear();
                var listVirtualNetworkResponse = await vnOperations.queryListAllVN();
                foreach (var virtualNetwork in listVirtualNetworkResponse.value)
                {
                    VirtualNetworks.Add(new VirtualNetwork
                    {
                        id = virtualNetwork.id,
                        name = virtualNetwork.name,
                        resourceGroup = Helpers.deSerializeResourceGroup(virtualNetwork.id),
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
    }
}