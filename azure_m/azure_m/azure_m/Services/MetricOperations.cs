using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl;

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

        private string baseUrl = $"https://management.azure.com/{{0}}/providers/microsoft.insights/metrics";

        public async Task<ListMetricsResponse> queryListMetrics(ListMetricsRequest req)
        {
            var url = Utils.withApiVersion(new Url(string.Format(baseUrl, req.uriPath.resourceUri)), apiVersion.list)
                .SetQueryParams(req.uriQuery)
                .WithOAuthBearerToken(QueryInfo.token);


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
