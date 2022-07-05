using System;
using System.Collections.Generic;
using System.Text;
using azure_m.Models.RequestModels.NetworkInterfaceRequestModels.CreateOrUpdateNI;
using Flurl.Http;
using Flurl;
using System.Threading.Tasks;

namespace azure_m.Services
{
    public class NetworkInterfaceOperations
    {
        private static class apiVersion
        {
            public const string createOrUpdate = "2021-08-01";
        }
        private string baseFormatUrlWithResourceGroup = $"{QueryInfo.baseStrUrl}/resourceGroups/{{0}}/providers/Microsoft.Network/networkInterfaces/{{1}}";

        public async Task queryCreateOrUpdateNI(CreateOrUpdateNIRequest createOrUpdateNIRequest)
        {
            var baseStrUrl = string.Format(baseFormatUrlWithResourceGroup, createOrUpdateNIRequest.uri.resourceGroupName, createOrUpdateNIRequest.uri.networkInterfaceName);
            var url = Utils.withApiVersion(
                    new Url(baseStrUrl),
                    apiVersion.createOrUpdate);

            try
            {
                var res = await url
                    .PostJsonAsync(createOrUpdateNIRequest.body)
                    .ReceiveString();
            }
            catch (FetchException ex)
            {
                Utils.error(ex);
            }
        }
    }
}
