using System;
using System.Collections.Generic;
using System.Text;

namespace azure_m.Models.RequestModels
{
    namespace MetricDefinition
    {
        namespace List
        {
            public class ListMetricDefinitionRequest: QueryRequest<
                MetricDefinitionRequestUriPath,
                MetricDefinitionRequestUriQuery,
                MetricDefinitionRequestBody
                >
            {

            }

            public class MetricDefinitionRequestUriPath
            {
                public string resourceUri { get; set; }
            }

            public class MetricDefinitionRequestUriQuery
            {

            }

            public class MetricDefinitionRequestBody
            {

            }
        }
    }
}
