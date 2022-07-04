using System;
using System.Collections.Generic;
using System.Text;

namespace azure_m.Models.RequestModels
{
    namespace ListMetrics 
    {
        public class ListMetricsRequest<ListMetricsUri, ListMetricsBody> { }

        public class ListMetricsBody { }

        public class ListMetricsUri 
        {
            public string resourceUri { get; set; }

            public string apiVersion { get; set; }

            public string filter { get; set; }

            public string interval { get; set; }

            public string metricnampspace { get; set; }

            public string orderby { get; set; }

            public string resultType { get; set; }

            public string timespan { get; set; }

            public int top { get; set; }
        }

    }

}
