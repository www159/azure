using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace azure_m.Services
{
    using Models.ResponseModels;
    using Models.RequestModels.MetricDefinition.List;
    using Services;
    using Mocks;

    public class MetricDefinirtionOperations
    {
        static class apiVersion
        {
            public const string get = "2018-01-01";
        }

        public async Task<ListMetricDefinitionResponse> queryListMetricDefinition(ListMetricDefinitionRequest req)
        {
            var uriPath = req.uriPath;
            var res = new ListMetricDefinitionResponse
            {
                value = new MetricDefinition[3],
            };
                
            if(uriPath.resourceUri.Contains(ResourceType.virtualMachines))
            {
                res.value = new MetricDefinition[]
                {
                    new MetricDefinition
                    {
                        name = new LocalizableString
                        {
                            value = Mocks.MetricNamesVM.CPUCreditsConsumed,
                        }
                    },
                    new MetricDefinition
                    {
                        name = new LocalizableString
                        {
                            value = Mocks.MetricNamesVM.CPUCreditsRemaining,
                        }
                    },
                    new MetricDefinition
                    {
                        name = new LocalizableString
                        {
                            value = Mocks.MetricNamesVM.AvailableMemBytes
                        }
                    }
                };
            }
            else
            {
                res.value = new MetricDefinition[]
            {
                new MetricDefinition
                {
                    name = new LocalizableString
                    {
                        value = Mocks.MetricNamesDisk.DiskOnDemandBurstOperations
                    }
                }
            };
            }

            return res;
        }
    }
}
