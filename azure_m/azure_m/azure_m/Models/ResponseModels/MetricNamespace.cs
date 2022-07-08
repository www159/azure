using System;
using System.Collections.Generic;
using System.Text;

namespace azure_m.Models
{
    namespace ResponseModels
    {

        public class ListMetricNamespaceResponse: ListResponse<MetricNamespace> {}

        public class MetricNamespaceResponse: MetricNamespace {}
        public class MetricNamespace
        {
            public string id { get; set; }

            public string name { get; set; }

            public string type { get; set; }

            public string classification { get; set; }

            public MetricNamespaceName properties { get; set; }
        }

        public class MetricNamespaceName
        {
            public string metricNamespaceName { get; set; }
        }

    }
}
