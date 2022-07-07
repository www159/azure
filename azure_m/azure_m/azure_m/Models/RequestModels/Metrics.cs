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
                public string metricNampspace { get; set; }

                public string orderby { get; set; }

                public string resultType { get; set; }

                public string timespan { get; set; }

                public string aggregation { get; set; }

                // public int top { get; set; }
            }
        }

        public class MetricNamesVM {

            public string AvailableMemBytes = "Available Memnory Bytes";

            public string CPUCreditConsumed = "CPU Credit Consumed";

            public string CPUCreditRemaining = "CPU Credit Remaining";
        }

        public class MetricNamesDisk {
        
            public string DiskOnDemandBurstOperations = "Disk On-demand Burst Operations";

        }

    }

}
