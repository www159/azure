using System;
using System.Collections.Generic;
using System.Text;
using Flurl;
using Flurl.Http;

using azure_m.Models.ResponseModels;
using System.Threading.Tasks;
namespace azure_m.Services
{
    using Models.RequestModels.ResourceGroup.CreateOrUpdate;
    using Models.RequestModels.ResourceGroup.Delete;
    using Models.RequestModels.ResourceGroup.Get;
    using Models.RequestModels.ResourceGroup.List;

    public class ResourceGroupOperations
    {
        private static class apiVersion
        {
            public const string createOrUpdate = "2021-04-01";

            public const string delete = "2021-04-01";

            public const string get = "2021-04-01";

            public const string list = "2021-04-01";
        }
        private string baseFormatUrlWithResourceGroup = $"{QueryInfo.baseStrUrl}/resourceGroups/{{0}}";

        private string baseFormatUrlWithoutResourceGroup = $"{QueryInfo.baseStrUrl}/resourceGroups";
        public async Task CreateOrUpdateResourceGroup(CreateOrUpdateResourceGroupRequest createOrUpdateResourceGroupRequest)
        {
            var baseStrUrl = string.Format(baseFormatUrlWithResourceGroup, createOrUpdateResourceGroupRequest.uri.resourceGroupName);
            var url = Utils.withApiVersion(
                baseStrUrl, 
                apiVersion.createOrUpdate
                );
            try
            {
                var res = await url
                    .PostJsonAsync(createOrUpdateResourceGroupRequest.body)
                    .ReceiveString();
            }
            catch(Exception ex)
            {
                Utils.error(ex);
            }
        }
        public async Task GetResourceGroup(GetResourceGroupRequest getResourceGroupRequest)
        {
            var baseStrUrl = string.Format(baseFormatUrlWithoutResourceGroup, getResourceGroupRequest.uri.resourceGroupName);
            var url = Utils.withApiVersion(
                baseStrUrl,
                apiVersion.get
                );
            try
            {
                var res = await url
                    .GetJsonAsync<ResourceGroupResponse>();
            }
            catch(Exception ex)
            {
                Utils.error(ex);
            }
        }
        public async Task ListResourceGroup(ListResourceGroupRequest listResourceGroupRequest)
        {
            var baseStrUrl = string.Format(baseFormatUrlWithoutResourceGroup);
            var url = Utils.withApiVersion(
                baseStrUrl,
                apiVersion.list
                );
            try
            {
                var res = await url
                    .PostJsonAsync(listResourceGroupRequest.body)
                    .ReceiveString();
            }
            catch(Exception ex)
            {
                Utils.error(ex);
            }
        }
        public async Task DeleteResourceGroup(DeleteResourceGroupRequest deleteResourceGroupRequest)
        {
            var baseStrUrl = string.Format(baseFormatUrlWithResourceGroup, deleteResourceGroupRequest.uri.resourceGroupName);
            var url = Utils.withApiVersion(
                baseStrUrl,
                apiVersion.delete
                );
            try
            {
                var res = await url
                    .DeleteAsync()
                    .ReceiveString();
            }
            catch(Exception ex)
            {
                Utils.error(ex);
            }
        }
    }
}
