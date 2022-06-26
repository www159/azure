using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using azure_m.Models;
using Xamarin.Forms;
using System.Threading.Tasks;
using azure_m.Services;
using System.Diagnostics;

namespace azure_m.ViewModels
{
    public class ResourceViewModel: BaseViewModel
    {

        public ResourceDataStore resDataStore => DependencyService.Get<ResourceDataStore>();
        private Resource _selectedResource;

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
                var resources = await resDataStore.GetResourcesAsync();
                //var resources = new Resource[]
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
