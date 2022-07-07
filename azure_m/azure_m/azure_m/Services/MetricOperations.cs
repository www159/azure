using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;

namespace azure_m.Services
{

    using Models.ResponseModels;
    using Models.RequestModels.Metrics.List;
    public class MetricOperations
    {

        private static class apiVersion
        {
            public const string list = "2018-01-01";
        }

        public async Task<ListMetricsResponse> queryListMetrics(ListMetricsRequest req)
        {
            var url = Utils.baseStrUrlFull(
                req.uriPath.resourceUri,
                apiVersion.list
            ).SetQueryParams(req.uriQUery);


            ListMetricsResponse res = null;
            try
            {
                res = await url.GetJsonAsync<ListMetricsResponse>();
            }
            catch (Exception ex)
            {
                Utils.error(ex);
            }

            return res;
        }
    }
}
