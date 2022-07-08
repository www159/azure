using System;
using System.Collections.Generic;
using System.Text;

namespace azure_m.Models.ResponseModels
{

    public class ListMetricDefinitionResponse: ListNResponse<MetricDefinition> { }

    public class MetricDefinition
    {
        public LocalizableString name { get; set; }

        public MetricAvailablity[] metricAvailablities { get; set; }
    }

    public class MetricAvailablity
    {
        public string retention { get; set; }   

        public string timeGrain { get; set; }
    }

}
