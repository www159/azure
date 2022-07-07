using System;
using System.Collections.Generic;
using System.Text;
using Flurl;
using Flurl.Http;

namespace azure_m.Services
{
    public class Activitylog
    {
        public DateTime time = DateTime.Now.Date;
        private static class apiVersion
        {
            public const string list = "2015-04-01";
        }

        private string baseFormatUrlWithResourceGroupAndVNname = $"{QueryInfo.baseStrUrl}/providers/Microsoft.Insights/eventtypes/management/values";
        //private string baseFormatUrlWithResourceGroup = $"{QueryInfo.baseStrUrl}/resourceGroups/{{0}}/providers/Microsoft.Compute/virtualMachines/{{1}}";
        //https://management.azure.com/subscriptions/{subscriptionId}/providers/Microsoft.Insights/eventtypes/management/values?api-version=2015-04-01&$filter={$filter}
    }
}
