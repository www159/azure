using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using azure_m.Services;
using Xamarin.Forms;
using azure_m.Views;
using System.Collections.ObjectModel;

namespace azure_m.ViewModels
{
    using Models;

    using Models.RequestModels.MetricNamespace.List;
    using Models.RequestModels.Metrics.List;

    public class TargetViewModel : BaseViewModel
    {
        public ObservableCollection<Resource> Resources { get; set; }

        private MetricOperations operations = DependencyService.Get<MetricOperations>();
        private ResourceOperations resourceOperations = DependencyService.Get<ResourceOperations>();

        string chosenResourceType;

        string chosenResourceName;

        public string ChosenResourceType
        {
            get => chosenResourceType;
            set => SetProperty(ref chosenResourceType, value);
        }

        public string ChosenResourceName
        {
            get => chosenResourceName;
            set => SetProperty(ref chosenResourceName, value);
        }

        public Command<CollectionView> selectedResource { get; }

        
        
        public List<Models.MockModels.Data> Ccr { get; set; }
        public List<Models.MockModels.Data> Ccc { get; set; }
        public List<Models.MockModels.Data> Amb { get; set; }

        async void LoadReSource()
        {
            await resourceOperations.refreshResourceAsync();

            Resources.Clear();
            
            foreach(var resource in resourceOperations.resources)
            {
                Resources.Add(resource);
            }
        }
        public TargetViewModel()
        {
            Resources = new ObservableCollection<Resource>();

            ChosenResourceName = "请选择一个范围";

            ChosenResourceType = "资源类型";

            LoadReSource();

            selectedResource = new Command<CollectionView>(async (sender) =>
            {
                var resource = sender.SelectedItem as Resource;
                ChosenResourceName = resource.name;
                ChosenResourceType = resource.type;
                // API

            });
        }
       

      

    }

}