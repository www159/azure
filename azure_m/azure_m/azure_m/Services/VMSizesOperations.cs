using System;
using System.Collections.Generic;
using System.Text;
using Flurl;
using System.Threading.Tasks;
using Flurl.Http;
namespace azure_m.Services
{

    using Models.RequestModels.VMSizes.List;

    using Models.ResponseModels;


    public class VMSizesOperations
    {
        private static class apiVersion
        {

            //public const string createOrUpdate = "2022-03-01";

            //public const string get = "2022-03-01";

            public const string list = "2022-03-01";

            //public const string listAll = "2022-03-01";

            //public const string delete = "2022-03-01";

            //public const string restart = "2022-03-01";

            //public const string dellocate = "2022-03-01";

            //public const string start = "2022-03-01";
        }
        private string baseFormatUrlWithLocation = $"{QueryInfo.baseStrUrl}/providers/Microsoft.Compute/locations/{{0}}/vmSizes";


        public async Task<List<VMSize>> queryListVMSizes(ListVMSizesRequest listVMSizesRequest)
        {
            var baseStrUrl = string.Format(baseFormatUrlWithLocation, listVMSizesRequest.uri.location);
            var url = Utils.withApiVersion(
                new Url(baseStrUrl),
                apiVersion.list)
                .WithOAuthBearerToken(QueryInfo.token);

            

            ListVMSizeResponse res = null;
            try
            {
                res = await url
                    .GetJsonAsync<ListVMSizeResponse>();

            }
            catch (Exception ex)
            {
                Utils.error(ex);
                return new List<VMSize>();
            }

            List<VMSize> VMSizes = Utils.arr2List(res.value);

            await Utils.loopQuery(VMSizes, res);

            return VMSizes;

        }//列出指定资源组所有虚拟机大小
    }
}
