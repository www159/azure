using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Flurl;
using Flurl.Http;
using System.Threading.Tasks;

namespace azure_m.Services
{


    public static class QueryInfo
    {
        public const string queryPrefix = "https://management.azure.com/subscriptions/";
        public static string subscriptionId = "";
        public const string apiVersion = "2021-04-01";
        public static string apiPrefixAd { get { return queryPrefix + subscriptionId; } }
        public static string apiVersionAd { get { return "api-version=" + apiVersion; } }
        public static QueryList queryList = new QueryList();
    }

   
    public class QueryList
    {
        public ResourcesQuery resources = new ResourcesQuery();
    }


    public class ResourcesQuery
    {
        Url baseUrl = new Url(QueryInfo.apiPrefixAd).AppendPathSegment("resourcegroups"); 
        public async Task<T> listResources<T>(string filter = "", Nullable<int> top = null)
        {
            
            if(filter is "" && top is null)
            {
                return await baseUrl.Clone().GetJsonAsync<T>();
            }
            else if(filter is "")
            {
                return await baseUrl.Clone().SetQueryParams(new
                {
                    top = top,
                }).GetJsonAsync<T>();
            }
            else if(top is null)
            {
                return await baseUrl.Clone().SetQueryParams(new
                {
                    filter = filter
                }).GetJsonAsync<T>();
            }
            else
            {
                return await baseUrl.Clone().SetQueryParams(new
                {
                    filter = filter,
                    top = top
                }).GetJsonAsync<T>();
            }
        }
    }
}
