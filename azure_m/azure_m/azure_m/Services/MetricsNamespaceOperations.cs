using System;
using System.Collections.Generic;
using System.Text;
using Flurl;
using System.Threading.Tasks;
using Flurl.Http;
namespace azure_m.Services
{

    using Models.RequestModels.MetricNamespace.List;

    using Models.ResponseModels;


    public class MetricsNamespaceOperations
    {
        private static class apiVersion
        {
            public const string list = "2022-03-01";
        }
        //private string baseFormatUrlWithResourceUri = $"{QueryInfo.baseStrUrl}/providers/Microsoft.Compute/locations/{{0}}/vmSizes";
        private string baseFormatUrlWithResourceUri = $"https://management.azure.com/{{0}}/providers/microsoft.insights/metricNamespaces"; //QueryInfo.baseStrUrl里没有这个前缀


        public async Task<IResponse<MetricNamespacesResponse>> queryListMetricsNamespace(ListMetricsNamespaceRequest listMetricsNamespaceRequest)
        {
            var baseStrUrl = string.Format(baseFormatUrlWithResourceUri, listMetricsNamespaceRequest.uri.resourceUri);
            var url = Utils.withApiVersion(
                new Url(baseStrUrl),
                apiVersion.list)
                .WithOAuthBearerToken(QueryInfo.token);

            IResponse<MetricNamespacesResponse> res = null;
            try
            {
                res = await url
                    .GetJsonAsync<IResponse<MetricNamespacesResponse>>();

            }
            catch (Exception ex)
            {
                Utils.error(ex);
            }
            return res;

        }//列出指定资源组所有MetricsNamespace
    }
}
