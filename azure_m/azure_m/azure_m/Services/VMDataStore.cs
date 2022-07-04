using System;
using System.Collections.Generic;
using System.Text;
using Flurl.Http;

using azure_m.Models.RequestModels.VMRequestModels.CreateOrUpdate;
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
        private string baseFormatUrlWithResurceGroup = $"{QueryInfo.baseStrUrl}/resourceGroups/{{0}}/providers/Microsoft.Compute/VirtualMachines/{{1}}";
        
        public async Task queryCreateOrUpdateVM(CreateOrUpdateVMRequest createOrUpdateVMRequest)
        {
            var baseStrUrl = string.Format(baseFormatUrlWithResurceGroup, createOrUpdateVMRequest.uri.resourceGroupName, createOrUpdateVMRequest.uri.vmName);
            var url = Utils.withApiVersion(
                    baseStrUrl,
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
