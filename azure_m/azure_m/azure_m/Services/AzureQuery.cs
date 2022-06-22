using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;

namespace azure_m.Services
{

 
    public static class QueryInfo
    {
        public const string queryPrefix = "https://management.azure.com/subscriptions/";
        public static string subscriptionId = "";
        public const string apiVersion = "2021-04-01";
        public const string apiVersionAd = "api-version=" + apiVersion;
        public static Dictionary<string, Object> queryList = new Dictionary<string, Object>()
        {
            ["resources"] = new ResourcesQuery(),
        };
        //public static HttpResponseMessage query(string url, HttpMethod method)
        //{
        //    Htt
        //}
    }

   
  


    public class ResourcesQuery
    { 
        public string listResources(string filter = "", Nullable<int> top = null)
        {
            
            if(filter is "" && top is null)
            {
                return $"/resourcegroups?{QueryInfo.apiVersionAd}";
            }
            else if(filter is "")
            {
                return $"/resourcegroups?$top={top}&{QueryInfo.apiVersionAd}";
            }
            else if(top is null)
            {
                return $"/resourcegroups?$filter={filter}&{QueryInfo.apiVersionAd}";
            }
            else
            {
                return $"/resourcegroups?$filter={filter}&$top={top}&{QueryInfo.apiVersionAd}";
            }
        }
    }
}
