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
    using Models.ResponseModels;
    public class VMDataStore
    {
        private static class apiVersion {

            public const string createOrUpdate = "2022-03-01";

            public const string get = "2022-03-01";

            public const string list= "2022-03-01";

            public const string listAll = "2022-03-01";

            public const string delete = "2022-03-01";

            public const string restart = "2022-03-01";

            public const string dellocate = "2022-03-01";

            public const string start = "2022-03-01";
        }
        
        //private CreateOrUpdateVMRequest createOrUpdateVMRequest;
        private string baseFormatUrlWithResourceGroup = $"{QueryInfo.baseStrUrl}/resourceGroups/{{0}}/providers/Microsoft.Compute/VirtualMachines/{{1}}";

        private string baseFormatUrlWithoutResourceGroup = $"{QueryInfo.baseStrUrl}/providers/Microsoft.Compute/VirtualMachines/{{0}}";

        private string baseFormatUrlWithoutVMname = $"{QueryInfo.baseStrUrl}/resourceGroups/{{0}}/providers/Microsoft.Compute/VirtualMachines";

        private string baseFormatUrlWithoutVMnameOrResourceGroup= $"{QueryInfo.baseStrUrl}/providers/Microsoft.Compute/VirtualMachines";
        public async Task queryCreateOrUpdateVM(CreateOrUpdateVMRequest createOrUpdateVMRequest)
        {
            var baseStrUrl = string.Format(baseFormatUrlWithResourceGroup, createOrUpdateVMRequest.uri.resourceGroupName, createOrUpdateVMRequest.uri.vmName);
            var url = Utils.withApiVersion(
                    new Url (baseStrUrl),
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
        }//创建/更新虚拟机的请求

        public async Task queryGetVM(GetVMRequest getVMRequest)
        {
            var baseStrUrl = string.Format(baseFormatUrlWithResourceGroup, getVMRequest.uri.resourceGroupName, getVMRequest.uri.vmName);
            var url = Utils.withApiVersion(
                    new Url(baseStrUrl),
                    apiVersion.get);
            try
            {
                var res = await url
                    .GetJsonAsync<VirtualMachineResopnse>();
            }
            catch(Exception ex)
            {
                Utils.error(ex);
            }
        }

        public async Task queryDeleteVM(DeleteRequest deleteRequest)
        {
            var baseStrUrl = string.Format(baseFormatUrlWithResourceGroup, deleteRequest.uri.resourceGroupName, deleteRequest.uri.vmName);
            var url = Utils.withApiVersion(
                new Url(baseStrUrl),
                apiVersion.delete);
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
        }//删除虚拟机操作

        public async Task queryListVM(ListRequest listRequest)
        {
            var baseStrUrl = string.Format(baseFormatUrlWithoutVMname, listRequest.uri.resourceGroupName);
            var url = Utils.withApiVersion(
                new Url(baseStrUrl),
                apiVersion.list);
            try
            {
                var res = await url
                    .GetJsonAsync<VirtualMachineResopnse>();

            }
            catch(Exception ex)
            {
                Utils.error(ex);
            }

        }//列出指定资源组所有虚拟机

        public async Task queryListAllVM()
        {
            var url = Utils.withApiVersion(
                new Url(baseFormatUrlWithoutVMnameOrResourceGroup),
                apiVersion.list);
            try
            {
                var res = await url
                    .GetJsonAsync<VirtualMachineResopnse>();

            }
            catch (Exception ex)
            {
                Utils.error(ex);
            }

        }//列出该订阅的所有虚拟机

        public async Task queryDellocateVM(DellocateRequest dellocateRequest)
        {
            var baseStrUrl = string.Format(baseFormatUrlWithResourceGroup, dellocateRequest.uri.resourceGroupName, dellocateRequest.uri.vmName);
            var url = Utils.withApiVersion(
                new Url(baseStrUrl),
                apiVersion.dellocate
                );
            try
            {
                var res = await url
                    .PostJsonAsync(dellocateRequest.body)
                    .ReceiveString();
            }
            catch(Exception ex)
            {
                Utils.error(ex);
            }
        }//释放虚拟机计算资源

        public async Task queryStartVM(StartRequest startRequest)
        {
            var baseStrUrl = string.Format(baseFormatUrlWithResourceGroup, startRequest.uri.resourceGroupName, startRequest.uri.vmName);
            var url = Utils.withApiVersion(
                new Url(baseStrUrl),
                apiVersion.start);
            try
            {
                var res = await url.
                    PostJsonAsync(startRequest.body)
                    .ReceiveString();
            }
            catch(Exception ex)
            {
                Utils.error(ex);
            }
        }//启动虚拟机
        
        public async Task queryReStartVM(RestartRequest restartRequest)
        {
            var baseStrUrl = string.Format(baseFormatUrlWithResourceGroup, restartRequest.uri.resourceGroupName, restartRequest.uri.vmName);
            var url = Utils.withApiVersion(
                new Url(baseStrUrl),
                apiVersion.start);
            try
            {
                var res = await url.
                    PostJsonAsync(restartRequest.body)
                    .ReceiveString();
            }
            catch (Exception ex)
            {
                Utils.error(ex);
            }
        }//重启虚拟机
    }
}
