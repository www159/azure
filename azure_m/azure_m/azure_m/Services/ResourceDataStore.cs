using azure_m.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;

namespace azure_m.Services
{
    using Models.ResponseModels;
    using Models;

    public class ResourceDataStore
    {
        private IFlurlRequest baseRequest = QueryInfo.baseRequest.AppendPathSegment("resources");

        public List<Resource> resources { get; private set; }

        private static class apiVersion
        {
            public const string listResources = "2021-04-01";
        }

        public ResourceDataStore()
        {
            resources = new List<Resource>{ };
        }

        public async Task refreshResourceAsync()
        {
            resources.Clear();
            ResourceResponse res;
            while(true)
            {
               try
                {
                    res = await queryResourcesAsync();
                    foreach (var resource in res.value)
                    {
                        var simplifiedResource = new Resource
                        {
                            id = resource.id,
                            name = resource.name,
                            type = resource.type,
                            location = resource.location,
                        };
                        resources.Add(simplifiedResource);
                    }
                    if (res.nextLink == null) break;
                    res = await QueryInfo.queryWithNextLink<ResourceResponse>(res.nextLink);
                }
                catch (Exception ex)
                {
                    Utils.error(ex);
                }
            }
        }

        private async Task<ResourceResponse> queryResourcesAsync(string filter = "", int top = -1)
        {
            var req = Utils.withApiVersion(baseRequest, apiVersion.listResources);
            ResourceResponse res = null;
            try
            {
                if (filter == "")
                {
                    res = await req.GetJsonAsync<ResourceResponse>();
                }
                else
                {
                    res = await req.SetQueryParams(new
                    {
                        filter = filter,
                        top = top,
                    }).GetJsonAsync<ResourceResponse>();
                }
            }
            catch (Exception ex)
            {
                Utils.error(ex);
            }

            if(res == null)
            {
                throw new FetchException();
            }


            return res;
        }
    }
}
