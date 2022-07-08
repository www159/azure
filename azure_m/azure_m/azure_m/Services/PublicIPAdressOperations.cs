using Flurl.Http;
using Flurl;
using System.Threading.Tasks;


namespace azure_m.Services
{
    using Models.RequestModels.PublicIPAddress.CreateOrUpdate;
    public class PublicIPAdressOperations
    {
        private static class apiVersion
        {
            public const string createOrUpdate = "2021-08-01";
        }
        private string baseFormatUrlWithResourceGroup = $"{QueryInfo.baseStrUrl}/resourceGroups/{{0}}/providers/{QueryInfo.resourceNamespace[ResourceType.publicIPAddresses]}/{ResourceType.publicIPAddresses}/{{1}}";

        public async Task queryCreateOrUpdatePublicIPAddress(CreateOrUpdatePublicIPAddressRequest createOrUpdatePublicIPAddressRequest)
        {
            var baseStrUrl = string.Format(baseFormatUrlWithResourceGroup, createOrUpdatePublicIPAddressRequest.uri.resourceGroupName, createOrUpdatePublicIPAddressRequest.uri.publicIpAddressName);
            var url = Utils
                .withApiVersion(
                    new Url(baseStrUrl),
                    apiVersion.createOrUpdate)
                .WithOAuthBearerToken(QueryInfo.token); 
                

            try
            {
                var res = await url
                    .PutJsonAsync(createOrUpdatePublicIPAddressRequest.body)
                    .ReceiveString();
            }
            catch (FetchException ex)
            {
                Utils.error(ex);
            }
        }

    }
}
