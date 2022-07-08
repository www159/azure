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
            public class ListMetricNamespaceUriQuery
            {

                public string startTime { get; set; }
                //public string apiVersion;
            }

            public class ListMetricNamespaceUriPath
            {
                public string reourceUri { get; set; }
            }
            public class ListMetricsNamespaceRequest : QueryRequest<
                ListMetricNamespaceUriPath,
                ListMetricNamespaceUriQuery,
                ListMetricNamespaceBody>
            {

            }
        }
    }
}
