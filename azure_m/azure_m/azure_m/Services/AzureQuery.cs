using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Flurl;
using Flurl.Http;
using System.Threading.Tasks;
using azure_m.Models;
using azure_m.Views;
using System.Diagnostics;
using Xamarin.Forms;

namespace azure_m.Services
{


    public static class QueryInfo
    {
        public const string queryPrefix = "https://management.azure.com/subscriptions/";
        public static string subscriptionId = "219b2431-594f-47fa-8e85-664196aa3f92";
        public const string apiVersion = "2021-04-01";
        public static string apiPrefixAd = queryPrefix + subscriptionId;
        //public static string apiPrefixAd { get { return queryPrefix + subscriptionId; } }
        public static string apiVersionAd { get { return "api-version=" + apiVersion; } }

        public static string _token { get; set; } = "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6ImpTMVhvMU9XRGpfNTJ2YndHTmd2UU8yVnpNYyIsImtpZCI6ImpTMVhvMU9XRGpfNTJ2YndHTmd2UU8yVnpNYyJ9.eyJhdWQiOiJodHRwczovL21hbmFnZW1lbnQuY29yZS53aW5kb3dzLm5ldC8iLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC80NTNkODYyOC0zNDNkLTQ4YjktYjRkOS1jMGE5N2U0YmUzYjcvIiwiaWF0IjoxNjU2MDUwNzA1LCJuYmYiOjE2NTYwNTA3MDUsImV4cCI6MTY1NjA1NTM5NCwiYWNyIjoiMSIsImFpbyI6IkFVUUF1LzhUQUFBQTNvMUE4S3Q1UVpjQk5CUnFCblhpdWVWWHNTYngzcFV3NEVFQjF5R3haQnpWdTBvcVJIa0NPSjdORS95Rmp5dUlJWnVpcmdWOHNmL2hDWnppWnBITmp3PT0iLCJhbHRzZWNpZCI6IjE6bGl2ZS5jb206MDAwMzQwMDEwMkZERUZBMiIsImFtciI6WyJwd2QiXSwiYXBwaWQiOiJjNDRiNDA4My0zYmIwLTQ5YzEtYjQ3ZC05NzRlNTNjYmRmM2MiLCJhcHBpZGFjciI6IjIiLCJlbWFpbCI6IjIxMDc3OTUyNDRAcXEuY29tIiwiZmFtaWx5X25hbWUiOiJwZXRlciIsImdpdmVuX25hbWUiOiJmdSIsImdyb3VwcyI6WyJjMmRiNzk0My1lNWZiLTQ2YzItYWMyZC0yY2Y0M2VkYTNiMzEiXSwiaWRwIjoibGl2ZS5jb20iLCJpcGFkZHIiOiIxMDMuMTUyLjExMi4xNTAiLCJuYW1lIjoicGV0ZXIgZnUiLCJvaWQiOiJmYWQ1OTE2ZS0xNjk4LTQ5NmMtYmVlNi1iNjMxOTI0Mjc3NWMiLCJwdWlkIjoiMTAwMzIwMDIwNzQ3OTM5MSIsInJoIjoiMC5BVlVBS0lZOVJUMDB1VWkwMmNDcGZrdmp0MFpJZjNrQXV0ZFB1a1Bhd2ZqMk1CT0lBTm8uIiwic2NwIjoidXNlcl9pbXBlcnNvbmF0aW9uIiwic3ViIjoiLXRXcUk5ZDlkX1BmTFFETkZQd3hfUjlRQjNXWWswN25KbzZPdkxyU2ZyUSIsInRpZCI6IjQ1M2Q4NjI4LTM0M2QtNDhiOS1iNGQ5LWMwYTk3ZTRiZTNiNyIsInVuaXF1ZV9uYW1lIjoibGl2ZS5jb20jMjEwNzc5NTI0NEBxcS5jb20iLCJ1dGkiOiJLb0lHT0h1ajhVR2ZSbmZZdy02UUFBIiwidmVyIjoiMS4wIiwid2lkcyI6WyI2MmU5MDM5NC02OWY1LTQyMzctOTE5MC0wMTIxNzcxNDVlMTAiXSwieG1zX3RjZHQiOjE2NTU3MDM0NjV9.lAWSW40dapYQhuqqHd9GRq9biBsAZD-9L5bm-kVW6vaJ8rqz_VwMEGiibmhSO0ASaiCSnqNNPqGtBbRFslCtfxE8As30TmJc5Wi8r6sQAuyXrzStofKwijW1E7bzc1-Fmt32wyMFa-N5rhEuyy-0bYp8Jc9OlbDneEpfbD9I6AmdFct0RCypRV26bLmgj8JkTh963J8FauIgmla0srQ7AdLVVCBQa-WVvYkGzU45se07DbH2No51H9lma11TQTTSFPMmADd2MkVuZPK8psFpWJPWX4v9LSh3UswWlnllzzVg2tu3akLJakNLM0ve4JRDKjQZ6OFfqoaJecRQGWr0QA";
        public static IFlurlRequest baseRequest { get; set; } = new Url(apiPrefixAd)
            .SetQueryParam("api-version", apiVersion)
            .WithOAuthBearerToken(_token);
        public static QueryList queryList { get; set; } = new QueryList();

    }


    public class QueryList
    {
        public ResourcesQuery resources = new ResourcesQuery();
    }


    public class ResourcesQuery
    {
        //IFlurlRequest baseRequest = new FlurlRequest();
        IFlurlRequest baseRequest = QueryInfo.baseRequest.AppendPathSegment("resources");
        public async Task<Resource[]> listResources(string filter, int top)
        {
            
            if(filter is "" && top is -1)
            {
                var res = await new Url("https://www.baidu.com").GetStringAsync();
                return await new Url("").GetJsonAsync();
            }
            else if(filter is "")
            {
                return await baseRequest.SetQueryParams(new
                {
                    top = top,
                }).GetJsonAsync<Resource[]>();
            }
            else if(top is -1)
            {
                return await baseRequest.SetQueryParams(new
                {
                    filter = filter
                }).GetJsonAsync<Resource[]>();
            }
            else
            {
                return await baseRequest.SetQueryParams(new
                {
                    filter = filter,
                    top = top
                }).GetJsonAsync<Resource[]>();
            }
        }
    }
}
