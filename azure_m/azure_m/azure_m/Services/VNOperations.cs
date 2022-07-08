using System;
using System.Collections.Generic;
using System.Text;
using Flurl;
using Flurl.Http;
using System.Threading.Tasks;
using azure_m.Models.RequestModels.VN.CreateOrUpdate;
using azure_m.Models.RequestModels.VN.Delete;
using azure_m.Models.RequestModels.VN.Get;
using azure_m.Models.RequestModels.VN.List;
using azure_m.Models.RequestModels.VN.ListAll;
using azure_m.Models.ResponseModels;
namespace azure_m.Services
{
   public class VNOperations
    {
        private static class apiVersion
        {
            public const string createOrUpdate = "2021-08-01";

            public const string delete = "2021-08-01";

            public const string get = "2021-08-01";

            public const string list = "2021-08-01";

            public const string listAll= "2021-08-01";
        }
        private string baseFormatUrlWithResourceGroupAndVNname = $"{QueryInfo.baseStrUrl}/resourceGroups/{{0}}/providers/Microsoft.Network/virtualNetworks/{{1}}";
        private string baseFormatUrlWithResourceGroup = $"{QueryInfo.baseStrUrl}/resourceGroups/{{0}}/providers/Microsoft.Network/virtualNetworks";
        private string baseFormatUrlWithoutVNnameOrResourceGroup = $"{QueryInfo.baseStrUrl}/providers/Microsoft.Network/virtualNetworks";

        public List<VirtualNetwork> virtualNetworks { get; set; }


        public async Task queryCreateOrUpdateVN(CreateOrUpdateVNRequest createOrUpdateVNRequest)
        {
            var baseStrUrl = string.Format(baseFormatUrlWithResourceGroupAndVNname, createOrUpdateVNRequest.uri.resourceGroupName, createOrUpdateVNRequest.uri.virtualNetworkName );
            var url = Utils
                .withApiVersion(
                    new Url(baseStrUrl),
                    apiVersion.createOrUpdate)
                .WithOAuthBearerToken(QueryInfo.token);

            try
            {
                var res = await url
                    .PutJsonAsync(createOrUpdateVNRequest.body)
                    .ReceiveString();
            }
            catch (FetchException ex)
            {
                Utils.error(ex);
            }
        }

        public async Task queryGetVN(GetVNRequest getVNRequest)
        {
            var baseStrUrl = string.Format(baseFormatUrlWithResourceGroup, getVNRequest.uri.resourceGroupName, getVNRequest.uri.virtualNetworkName);
            var url = Utils.withApiVersion(
                    new Url(baseStrUrl),
                    apiVersion.get);
            try
            {
                var res = await url
                    .GetJsonAsync<VirtualNetworkResponse>();
            }
            catch (Exception ex)
            {
                Utils.error(ex);
            }
        }

        public async Task queryDeleteVN(DeleteVNRequest deleteVNRequest)
        {
            var baseStrUrl = string.Format(baseFormatUrlWithResourceGroup, deleteVNRequest.uri.resourceGroupName, deleteVNRequest.uri.virtualNetworkName);
            var url = Utils.withApiVersion(
                new Url(baseStrUrl),
                apiVersion.delete);
            try
            {
                var res = await url
                    .DeleteAsync()
                    .ReceiveString();
            }
            catch (Exception ex)
            {
                Utils.error(ex);
            }
        }

        public async Task queryListVN(ListVNRequest listVNRequest)
        {
            var baseStrUrl = string.Format(baseFormatUrlWithResourceGroup, listVNRequest.uri.resourceGroupName);
            var url = Utils.withApiVersion(
                new Url(baseStrUrl),
                apiVersion.list);
            try
            {
                var res = await url
                    .GetJsonAsync<VirtualNetworkResponse>();

            }
            catch (Exception ex)
            {
                Utils.error(ex);
            }

        }

        public async Task<ListVirtualNetworkResponse> queryListAllVN()
        {
            //var url = Utils.withApiVersion(
            //    new Url(baseFormatUrlWithoutVNnameOrResourceGroup),
            //    apiVersion.list);
            var url = Utils.baseStrUrlFull(
                apiVersion: apiVersion.listAll,
                type: ResourceType.virtualNetworks,
                _namespace: QueryInfo.resourceNamespace[ResourceType.virtualNetworks]
                );
            ListVirtualNetworkResponse res = null;
            try
            {
                var str = await url.GetStringAsync();
                res = await url
                    .GetJsonAsync<ListVirtualNetworkResponse>();

            }
            catch (Exception ex)
            {
                Utils.error(ex);
            }
            virtualNetworks = Utils.arr2List(res.value);
            return res;

        }
    }
}
