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
    using Models.ResponseModels;
    using Mocks;

    public class TargetViewModel : BaseViewModel
    {
        public ObservableCollection<Resource> Resources { get; set; }

        public ObservableCollection<string> MetricNames { get; set; }

        public ObservableCollection<MetricData> MetricDatas { get; set; }


        private MetricOperations metricOperations = DependencyService.Get<MetricOperations>();
        private ResourceOperations resourceOperations = DependencyService.Get<ResourceOperations>();
        private MetricDefinirtionOperations metricDefinirtionOperations = DependencyService.Get<MetricDefinirtionOperations>();
        private MetricsNamespaceOperations metricsNamespaceOperations = DependencyService.Get<MetricsNamespaceOperations>();

        public string TZTime { get => $"{DateTime.Now.ToString("yyyy-MM-dd")}T{DateTime.Now.TimeOfDay}Z"; }

        public string TZTimePre { get => $"{DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd")}T{DateTime.Now.TimeOfDay}Z"; }

        private string chosenResourceType;
        private string chosenResourceName;
        private string chosenResourceId;
        private string metricNamespace;
        private string selectedMetricName;

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

        public string SelectedMetricName
        {
            get => selectedMetricName;
            set {
                SetProperty(ref selectedMetricName, value);
                onMetricSelected(value);
            }
        }


        public Command<CollectionView> selectedResource { get; }




        async void LoadReSource()
        {
            await resourceOperations.refreshResourceAsync();

            Resources.Clear();

            foreach (var resource in resourceOperations.resources)
            {
                Resources.Add(resource);
            }
        }
        public TargetViewModel()
        {
            Resources = new ObservableCollection<Resource>();
            MetricNames = new ObservableCollection<string>();
            MetricDatas = new ObservableCollection<MetricData>();

            ChosenResourceName = "请选择一个范围";

            ChosenResourceType = "资源类型";

            LoadReSource();

            selectedResource = new Command<CollectionView>(async (sender) =>
            {
                var resource = sender.SelectedItem as Resource;
                ChosenResourceName = resource.name;
                ChosenResourceType = resource.type;
                chosenResourceId = resource.id;
                // API
                var resMetDef = await metricDefinirtionOperations.queryListMetricDefinition(
                    new Models.RequestModels.MetricDefinition.List.ListMetricDefinitionRequest
                    {
                        uriPath = new Models.RequestModels.MetricDefinition.List.MetricDefinitionRequestUriPath
                        {
                            resourceUri = resource.id
                        }
                    });

                MetricNames.Clear();
                foreach (var val in resMetDef.value)
                {
                    MetricNames.Add(val.name.value);
                }

                var resMetNsp = await metricsNamespaceOperations.queryListMetricsNamespace(new ListMetricsNamespaceRequest
                {
                    uriPath = new ListMetricNamespaceUriPath
                    {
                        reourceUri = resource.id
                    }
                });

                metricNamespace = resMetNsp.value[0].properties.metricNamespaceName;
            });


        }


        private async void onMetricSelected(string selectedMetricName)
        {
            var res = await metricOperations.queryListMetrics(new ListMetricsRequest
            {
                uriPath = new ListMetricsUriPath
                {
                    resourceUri = chosenResourceId
                },
                uriQuery = new ListMetricsUriQuery
                {
                    aggregation = Mocks.MetricReqUriQuery.aggregation,

                    interval = Mocks.MetricReqUriQuery.interval,

                    metricnames = selectedMetricName,

                    metricNamespace = metricNamespace,

                    timespan = $"{TZTimePre}/{TZTime}"

                }
            });

            MetricDatas.Clear();
            foreach(var val in res.value[0].timeseries[0].data)
            {
                if (val.average >= (1024 * 1024))
                {
                    MetricDatas.Add(new MetricData
                    {
                        timeStamp = val.timeStamp,
                        average = val.average/(1024*1024),
                    });
                }
                else
                {
                    MetricDatas.Add(new MetricData
                    {
                        timeStamp = val.timeStamp,
                        average = val.average,
                    });
                }
            }
        }

    }

}