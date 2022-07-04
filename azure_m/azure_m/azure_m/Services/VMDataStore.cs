using System;
using System.Collections.Generic;
using System.Text;
using Flurl.Http;
using azure_m.Models.RequestModels.VMRequestModels;
using azure_m.Models.RequestModels.VMRequestModels.CreateOrUpdate;
using azure_m.Models.RequestModels.VMRequestModels.Get;
using azure_m.Models.RequestModels.VMRequestModels.Delete;
using azure_m.Models.RequestModels.VMRequestModels.Dellocate;
using azure_m.Models.RequestModels.VMRequestModels.List;
using azure_m.Models.RequestModels.VMRequestModels.ListAll;
using azure_m.Models.RequestModels.VMRequestModels.Restart;
using azure_m.Models.RequestModels.VMRequestModels.Start;
using System.Threading.Tasks;
using Flurl;

namespace azure_m.Services
{
    public class VMDataStore
    {
        private static class apiVersion {

            public const string createOrUpdate = "2022-03-01";
        }
        
        //private CreateOrUpdateVMRequest createOrUpdateVMRequest;
        private string baseFormatUrlWithResourceGroup = $"{QueryInfo.baseStrUrl}/resourceGroups/{{0}}/providers/Microsoft.Compute/VirtualMachines/{{1}}";

        private string baseFormatUrlWithoutRecourceGroup = $"{QueryInfo.baseStrUrl}/providers/Microsoft.Compute/VirtualMachines/{{0}}";
        public async Task queryCreateOrUpdateVM(CreateOrUpdateVMRequest createOrUpdateVMRequest)
        {
            var baseStrUrl = string.Format(baseFormatUrlWithResourceGroup, createOrUpdateVMRequest.uri.resourceGroupName, createOrUpdateVMRequest.uri.vmName);
            var url = Utils.withApiVersion(
                    new Url(baseStrUrl).WithHeader(QueryInfo.methodHead, "PUT"),
                    apiVersion.createOrUpdate);

            try
            {
                var res = await url
                    .PostJsonAsync(createOrUpdateVMRequest.body)
                    .ReceiveString();
            }
            catch(FetchException ex)
            {
                Utils.error(ex);
            }
        }

    }
}
