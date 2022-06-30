using azure_m.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;

namespace azure_m.Services
{

    public class IResponseType<T>
    {
        public T value;
    }

    public class ResourceDataStore
    {
        private IFlurlRequest baseRequest = QueryInfo.baseRequest.AppendPathSegment("resources");
        private static class apiVersion
        {
            public const string listResources = "2021-04-01";
        }

        public async Task<Resource[]> ListResourcesAsync(string filter = "", int top = -1)
        {
            var req = Utils.withApiVersion(baseRequest, apiVersion.listResources);
            IResponseType<Resource[]> res = null;
            try
            {
                if (filter == "")
                {
                    res = await req.GetJsonAsync<IResponseType<Resource[]>>();
                }
                else
                {
                    res = await req.SetQueryParams(new
                    {
                        filter = filter,
                        top = top,
                    }).GetJsonAsync<IResponseType<Resource[]>>();
                }
            }
            catch (Exception ex)
            {
                Utils.error(ex);
            }

            if(res == null)
            {
                throw new FetchExecption();
            }


            return res.value;
        }
    }
}
