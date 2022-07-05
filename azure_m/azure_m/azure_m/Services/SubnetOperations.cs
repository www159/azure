using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using azure_m.Models.RequestModels.Subnet.CreateOrUpdate;
using azure_m.Models.RequestModels.Subnet.Delete;
using azure_m.Models.RequestModels.Subnet.Get;
using azure_m.Models.RequestModels.Subnet.List;
using azure_m.Models.ResponseModels;

namespace azure_m.Services
{
    public class SubnetOperations
    {
        private static class apiVersion
        {
            public const string createOrUpdate = "2021-08-01";

            public const string delete = "2021-08-01";

            public const string get = "2021-08-01";

            public const string list = "2021-08-01";
        }
        private string baseFormatUrlWithSubnetName = $"{QueryInfo.baseStrUrl}/resourceGroups/{{0}}/providers/Microsoft.Network/virtualNetworks/{{1}}/subnets/{{2}}";

        private string baseFormatUrlWithoutSubnetName = $"{QueryInfo.baseStrUrl}/resourceGroups/{{0}}/providers/Microsoft.Network/virtualNetworks/{{1}}/subnets";
        public async Task CreateOrUpdateSubnet(CreateOrUpdateSubnetRequest createOrUpdateSubnetRequest)
        {
            var baseStrUrl = string.Format(baseFormatUrlWithSubnetName, createOrUpdateSubnetRequest.uri.resourceGroupName,createOrUpdateSubnetRequest.uri.virtualNetworkName,createOrUpdateSubnetRequest.uri.subnetName);
            var url = Utils.withApiVersion(
                baseStrUrl,
                apiVersion.createOrUpdate
                );
            try
            {
                var res = await url
                    .PostJsonAsync(createOrUpdateSubnetRequest.body)
                    .ReceiveString();
            }
            catch (Exception ex)
            {
                Utils.error(ex);
            }
        }
        public async Task GetSubnet(GetSubnetRequest getSubnetRequest)
        {
            var baseStrUrl = string.Format(baseFormatUrlWithSubnetName, getSubnetRequest.uri.resourceGroupName, getSubnetRequest.uri.virtualNetworkName, getSubnetRequest.uri.subnetName);
            var url = Utils.withApiVersion(
                baseStrUrl,
                apiVersion.get
                );
            try
            {
                var res = await url
                    .GetJsonAsync<Subnet>();
            }
            catch (Exception ex)
            {
                Utils.error(ex);
            }
        }
        public async Task ListSubnet(ListSubnetRequest listSubnetRequest)
        {
            var baseStrUrl = string.Format(baseFormatUrlWithoutSubnetName,listSubnetRequest.uri.resourceGroupName,listSubnetRequest.uri.virtualNetworkName);
            var url = Utils.withApiVersion(
                baseStrUrl,
                apiVersion.list
                );
            try
            {
                var res = await url
                    .PostJsonAsync(listSubnetRequest.body)
                    .ReceiveString();
            }
            catch (Exception ex)
            {
                Utils.error(ex);
            }
        }
        public async Task DeleteSubnet(DeleteSubnetRequest deleteSubnetRequest)
        {
            var baseStrUrl = string.Format(baseFormatUrlWithSubnetName, deleteSubnetRequest.uri.resourceGroupName,deleteSubnetRequest.uri.virtualNetworkName,deleteSubnetRequest.uri.subnetName);
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
            catch (Exception ex)
            {
                Utils.error(ex);
            }
        }
    }
}
