using System;
using System.Collections.Generic;
using System.Text;

namespace azure_m.Models
{
    namespace ResponseModels
    {
        public class Subscriptions
        {
            public int count { get; set; }

            public SubscriptionId[] data { get; set; }

            /*

            public Facet[] facets;

            public string resultTruncated;

            */
        }

        public class SubscriptionId
        {
            public string id { get; set; }

            public string subscriptionId { get; set; }

            public string status { get; set; }

            /*

            public ManageGroup manageGroup;

            public string secureScore;

            */

        }
    }
}
