﻿using System;
using Flurl.Http;
using System.Threading.Tasks;
using Flurl;
using Newtonsoft.Json;

namespace azure_m.Services
{
    using Models.RequestModels.VM.CreateOrUpdate;
    using Models.RequestModels.VM.Delete;
    using Models.RequestModels.VM.Dellocate;
    using Models.RequestModels.VM.Get;
    using Models.RequestModels.VM.List;
    using Models.RequestModels.VM.ListAll;
    using Models.RequestModels.VM.Restart;
    using Models.RequestModels.VM.Start;

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
        private string baseFormatUrlWithResourceGroup = $"{QueryInfo.baseStrUrl}/resourceGroups/{{0}}/providers/Microsoft.Compute/virtualMachines/{{1}}";

        private string baseFormatUrlWithoutResourceGroup = $"{QueryInfo.baseStrUrl}/providers/Microsoft.Compute/virtualMachines/{{0}}";

        private string baseFormatUrlWithoutVMname = $"{QueryInfo.baseStrUrl}/resourceGroups/{{0}}/providers/Microsoft.Compute/virtualMachines";

        private string baseFormatUrlWithoutVMnameOrResourceGroup= $"{QueryInfo.baseStrUrl}/providers/Microsoft.Compute/virtualMachines";
        public async Task<int> queryCreateOrUpdateVM(CreateOrUpdateVMRequest createOrUpdateVMRequest)
        {
            var baseStrUrl = string.Format(
                baseFormatUrlWithResourceGroup,
                createOrUpdateVMRequest.uri.resourceGroupName, 
                createOrUpdateVMRequest.uri.vmName);
            var url = Utils.withApiVersion(
                    new Url(baseStrUrl),
                    apiVersion.createOrUpdate)
                    .WithOAuthBearerToken(QueryInfo.token);


                var str = JsonConvert.SerializeObject(createOrUpdateVMRequest.body);
            var res = await url
                .WithHeader("Content-type", "application/json")
                .PutStringAsync(str);
            return res.StatusCode;
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
                    .GetJsonAsync<VirtualMachineResponse>();
            }
            catch(Exception ex)
            {
                Utils.error(ex);
            }
        }

        public async Task queryDeleteVM(DeleteVMRequest deleteVMRequest)
        {
            var baseStrUrl = string.Format(baseFormatUrlWithResourceGroup, deleteVMRequest.uri.resourceGroupName, deleteVMRequest.uri.vmName);
            var url = Utils.withApiVersion(
                new Url(baseStrUrl),
                apiVersion.delete)
                .WithOAuthBearerToken(QueryInfo.token);
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

        public async Task queryListVM(ListVMRequest listVMRequest)
        {
            var baseStrUrl = string.Format(baseFormatUrlWithoutVMname, listVMRequest.uri.resourceGroupName);
            var url = Utils.withApiVersion(
                new Url(baseStrUrl),
                apiVersion.list)
                .WithOAuthBearerToken(QueryInfo.token);
            try
            {
                var res = await url
                    .GetJsonAsync<VirtualMachineResponse>();

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
                    .GetJsonAsync<VirtualMachineResponse>();

            }
            catch (Exception ex)
            {
                Utils.error(ex);
            }

        }//列出该订阅的所有虚拟机

        public async Task queryDellocateVM(DellocateVMRequest dellocateVMRequest)
        {
            var baseStrUrl = string.Format(baseFormatUrlWithResourceGroup, dellocateVMRequest.uri.resourceGroupName, dellocateVMRequest.uri.vmName);
            var url = Utils.withApiVersion(
                new Url(baseStrUrl),
                apiVersion.dellocate
                );
            try
            {
                var res = await url
                    .PostJsonAsync(dellocateVMRequest.body)
                    .ReceiveString();
            }
            catch(Exception ex)
            {
                Utils.error(ex);
            }
        }//释放虚拟机计算资源

        public async Task queryStartVM(StartVMRequest startVMRequest)
        {
            var baseStrUrl = string.Format(baseFormatUrlWithResourceGroup, startVMRequest.uri.resourceGroupName, startVMRequest.uri.vmName);
            var url = Utils.withApiVersion(
                new Url(baseStrUrl),
                apiVersion.start);
            try
            {
                var res = await url.
                    PostJsonAsync(startVMRequest.body)
                    .ReceiveString();
            }
            catch(Exception ex)
            {
                Utils.error(ex);
            }
        }//启动虚拟机
        
        public async Task queryReStartVM(RestartVMRequest restartVMRequest)
        {
            var baseStrUrl = string.Format(baseFormatUrlWithResourceGroup, restartVMRequest.uri.resourceGroupName, restartVMRequest.uri.vmName);
            var url = Utils.withApiVersion(
                new Url(baseStrUrl),
                apiVersion.start);
            try
            {
                var res = await url.
                    PostJsonAsync(restartVMRequest.body)
                    .ReceiveString();
            }
            catch (Exception ex)
            {
                Utils.error(ex);
            }
        }//重启虚拟机
    }
}
