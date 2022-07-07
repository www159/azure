using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using azure_m.Models.RequestModels;
using Xamarin.Forms;
using System.Threading.Tasks;
using azure_m.Services;
using System.Diagnostics;

namespace azure_m.ViewModels
{
    using Models;

    public class ResourceViewModel: BaseViewModel
    {

        public ResourceOperations resourceDataStore => DependencyService.Get<ResourceOperations>();
        private Resource _selectedResource;

        public static Dictionary<string, string> ImgMap = new Dictionary<string, string>()
        {
            ["networkWatchers"] = "networkWatchers.png",
            ["storageAccounts"] = "storageAccounts.png",
            ["disks"] = "disks.png",
            ["sshPublicKeys"] = "sshPublicKeys.png",
            ["virtualMachines"] = "virtualMachines.png",
            ["networkInterfaces"] = "networkInterfaces.png",
            ["networkSecurityGroups"] = "netWorkSecurityGroups.png",
            ["publicIPAddresses"] = "publicIPAddresses.png",
            ["virtualNetworks"] = "virtualNetworks.png",
        };

        public ObservableCollection<Resource> Resources { get; }
        public Command ResourceTapped { get; }
        public Command LoadResourcesCommand { get; }

        public ResourceViewModel()
        {
            Title = "AllResourceReview";
            Resources = new ObservableCollection<Resource>();
            LoadResourcesCommand = new Command(async () => await ExecuteLoadResourcesCommand());

            ResourceTapped = new Command<Resource>(onResourceSelected);

        }

        async Task ExecuteLoadResourcesCommand()
        {
            IsBusy = true;
            try
            {
                Resources.Clear();
                await resourceDataStore.refreshResourceAsync();
                var resources = resourceDataStore.resources;
                //{
                //    new Resource
                //    {
                //        id = "1",
                //        name = "1",
                //        location = "1",
                //        type = "1",
                //    }
                //};
                foreach (var resource in resources)
                {
                    //get real type
                    resource.type = resource.type.Split('/')[1];
                    resource.imgUrl = ImgMap[resource.type];
                    Resources.Add(resource);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }

        }

        private async void onResourceSelected(Resource res)
        {
            if(res is null)
            {
                return;
            }

            /// await 跳转到相应的resouurce界面

        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedResource = null;
        }

        public Resource SelectedResource
        {
            get => _selectedResource;
            set
            {
                SetProperty(ref _selectedResource, value);
                onResourceSelected(value); 
            }
        }
    }
}
