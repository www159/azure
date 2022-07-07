using System;
using System.Collections.Generic;
using System.Linq;
using Flurl.Http;
using Flurl;

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
        private string baseFormatUrlWithResourceGroup = $"{QueryInfo.baseStrUrl}/resourcegroups/{{0}}";

        private string baseFormatUrlWithoutResourceGroup = $"{QueryInfo.baseStrUrl}/resourcegroups";
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
        public async Task<List<ResourceGroup>> ListResourceGroup()
        {
            var baseStrUrl = string.Format(baseFormatUrlWithoutResourceGroup);
            var url = Utils.withApiVersion(
                baseStrUrl,
                apiVersion.list
                )
                .WithOAuthBearerToken(QueryInfo.token);

            ListResourceGroupResponse res;
            try
            {
                res = await new Url("https://management.azure.com/subscriptions/219b2431-594f-47fa-8e85-664196aa3f92/resourcegroups?api-version=2021-04-01")
                    .WithOAuthBearerToken(QueryInfo.token)
                    .GetJsonAsync<ListResourceGroupResponse>();
            }
            catch (Exception ex)
            {
                Utils.error(ex);
                return new List<ResourceGroup>();
            }
            List<ResourceGroup> resourceGroups = (res.value.Clone() as ResourceGroup[]).ToList();

            //while(res.nextLink != null)
            //{
            //    res = await Utils.queryWithNextLink<ResourceGroupResponse>(res.nextLink);
            //    foreach(var val in res.value)
            //    {
            //        resourceGroups.Add(val);
            //    }
            //}
            await Utils.loopQuery(resourceGroups, res);

            return resourceGroups;

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
