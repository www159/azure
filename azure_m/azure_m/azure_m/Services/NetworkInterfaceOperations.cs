using Flurl.Http;
using Flurl;
using System.Threading.Tasks;

namespace azure_m.Services
{
    using Models.RequestModels.NetworkInterface.CreateOrUpdate;
    public class NetworkInterfaceOperations
    {
        private static class apiVersion
        {
            public const string createOrUpdate = "2021-08-01";
        }
        private string baseFormatUrlWithResourceGroup = $"{QueryInfo.baseStrUrl}/resourceGroups/{{0}}/providers/{QueryInfo.resourceNamespace[ResourceType.networkInterfaces]}/{ResourceType.networkInterfaces}/{{1}}";

        public async Task queryCreateOrUpdateNI(CreateOrUpdateNIRequest createOrUpdateNIRequest)
        {
            var baseStrUrl = string.Format(baseFormatUrlWithResourceGroup, createOrUpdateNIRequest.uri.resourceGroupName, createOrUpdateNIRequest.uri.networkInterfaceName);
            var url = Utils
                .withApiVersion(
                    new Url(baseStrUrl),
                    apiVersion.createOrUpdate)
                .WithOAuthBearerToken(QueryInfo.token);

            try
            {
                var res = await url
                    .PutJsonAsync(createOrUpdateNIRequest.body)
                    .ReceiveString();
            }
            catch (FetchException ex)
            {
                Utils.error(ex);
            }
        }
    }
}
