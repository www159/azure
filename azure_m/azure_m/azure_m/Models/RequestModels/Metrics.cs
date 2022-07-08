using System;
using System.Collections.Generic;
using System.Text;

namespace azure_m.Models.RequestModels
{
    namespace Metrics
    {
        namespace List
        {
            public class ListMetricsRequest : QueryRequest<
            ListMetricsUriPath,
            ListMetricsUriQuery,
            ListMetricsBody>
            { }

            public class ListMetricsBody { }

            public class ListMetricsUriPath
            {
                public string resourceUri { get; set; }

            }

            public class ListMetricsUriQuery
            {
                // public string filter { get; set; }

                public string interval { get; set; }

                // Type: MetricNames;
                public string metricNamespace { get; set; }

                public string orderby { get; set; }

                public string resultType { get; set; }

                public string timespan { get; set; }

                public string aggregation { get; set; }

                public string metricnames { get; set; }

                // public int top { get; set; }
            }
        }


    }

}
