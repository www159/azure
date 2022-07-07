using System;
using System.Collections.Generic;
using System.Text;
using Flurl.Http;
using System.Threading.Tasks;

namespace azure_m.Services
{
    using Models.RequestModels.Subscriptions.List;
    using Models.ResponseModels;

    public class SubscriptionOperations
    {
        private static class apiVersion
        {
            public const string list = "2020-01-01";
        }

        public async Task<ListSubscriptionResponse> queryListSubscriptions(ListSubscriptionsRequest req)
        {
            var url = Utils.baseStrReq(QueryInfo.baseUri, apiVersion.list);

            ListSubscriptionResponse res = null;

            try
            {
                res = await url.GetJsonAsync<ListSubscriptionResponse>();
            }
            catch (Exception ex)
            {
                Utils.error(ex);
            }

            return res;
        }
    }
}
