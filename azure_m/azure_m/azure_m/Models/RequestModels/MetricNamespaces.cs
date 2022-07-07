using System;
using System.Collections.Generic;
using System.Text;

namespace azure_m.Models.RequestModels
{
    namespace MetricNamespace
    {
        namespace List
        {
            public class ListMetricNamespaceBody
            {

            }
            public class ListMetricNamespaceUri
            {
                public string resourceUri { get; set; }

                public string startTime { get; set; }
                //public string apiVersion;
            }
            public class ListMetricsNamespaceRequest : IRequest<ListMetricNamespaceUri, ListMetricNamespaceBody>
            {

            }
        }
    }
}
