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

        public static string _token { get; set; } = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6ImpTMVhvMU9XRGpfNTJ2YndHTmd2UU8yVnpNYyIsImtpZCI6ImpTMVhvMU9XRGpfNTJ2YndHTmd2UU8yVnpNYyJ9.eyJhdWQiOiJodHRwczovL21hbmFnZW1lbnQuY29yZS53aW5kb3dzLm5ldC8iLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC80NTNkODYyOC0zNDNkLTQ4YjktYjRkOS1jMGE5N2U0YmUzYjcvIiwiaWF0IjoxNjU2MDkzNTM1LCJuYmYiOjE2NTYwOTM1MzUsImV4cCI6MTY1NjA5OTExOSwiYWNyIjoiMSIsImFpbyI6IkFVUUF1LzhUQUFBQWxEZnMxS0ppQ0tKaSszWjZPSUs0WVBqbWw2U3BhV2djMk5EWlVnbzlQUitKQ2gvUEpSRm1JR3oyenhRMVgrWTVUV0tySzVsMUZyWVhLQTgzRTdKVlNnPT0iLCJhbHRzZWNpZCI6IjE6bGl2ZS5jb206MDAwMzQwMDEwMkZERUZBMiIsImFtciI6WyJwd2QiXSwiYXBwaWQiOiJjNDRiNDA4My0zYmIwLTQ5YzEtYjQ3ZC05NzRlNTNjYmRmM2MiLCJhcHBpZGFjciI6IjIiLCJlbWFpbCI6IjIxMDc3OTUyNDRAcXEuY29tIiwiZmFtaWx5X25hbWUiOiJwZXRlciIsImdpdmVuX25hbWUiOiJmdSIsImdyb3VwcyI6WyJjMmRiNzk0My1lNWZiLTQ2YzItYWMyZC0yY2Y0M2VkYTNiMzEiXSwiaWRwIjoibGl2ZS5jb20iLCJpcGFkZHIiOiIxMDMuMTUyLjExMi4xNTAiLCJuYW1lIjoicGV0ZXIgZnUiLCJvaWQiOiJmYWQ1OTE2ZS0xNjk4LTQ5NmMtYmVlNi1iNjMxOTI0Mjc3NWMiLCJwdWlkIjoiMTAwMzIwMDIwNzQ3OTM5MSIsInJoIjoiMC5BVlVBS0lZOVJUMDB1VWkwMmNDcGZrdmp0MFpJZjNrQXV0ZFB1a1Bhd2ZqMk1CT0lBTm8uIiwic2NwIjoidXNlcl9pbXBlcnNvbmF0aW9uIiwic3ViIjoiLXRXcUk5ZDlkX1BmTFFETkZQd3hfUjlRQjNXWWswN25KbzZPdkxyU2ZyUSIsInRpZCI6IjQ1M2Q4NjI4LTM0M2QtNDhiOS1iNGQ5LWMwYTk3ZTRiZTNiNyIsInVuaXF1ZV9uYW1lIjoibGl2ZS5jb20jMjEwNzc5NTI0NEBxcS5jb20iLCJ1dGkiOiJBRnR0UkszX1pFdTJoUHVYbXBBLUFBIiwidmVyIjoiMS4wIiwid2lkcyI6WyI2MmU5MDM5NC02OWY1LTQyMzctOTE5MC0wMTIxNzcxNDVlMTAiXSwieG1zX3RjZHQiOjE2NTU3MDM0NjV9.rPr2cTLbDI8iUfdXPmPAAClP9R-sue_kx3hkNtMaUlWSTrXmm6zC7ZpA-AOvCObG-t-3tS_IvTu9wDV2mYfsfIW1uFBNmP60mphJ4-s34beq3yZQXOnscmUo50hD0IVLWi6RDqow4i5PbZEr3ainBlKg5qv_61XGKLMUi-7vX5QVi6tdmchBxrIyaPheMRP0gAHRlcvwwCFk65fE3Qwk0L32-78sSZjkEDWpyYo5aGWS-qkXLcqnSTHWMAlhnluelNkxMuoOn95GPXYCRspbQ77nj7M1_Z-cUGGF-mCfi9Tgsyd35oanDb-sNLN_G6lleQiGFMYye5kHcWXhIYQLtA";
        public static IFlurlRequest baseRequest { get; set; } = new Url(apiPrefixAd)
            .SetQueryParam("api-version", apiVersion)
            .WithOAuthBearerToken(_token);
        public static QueryList queryList { get; set; } = new QueryList();

        
    }
    public interface IResponseType<T>
    {
        T value { get; set; }
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
            IResponseType<Resource[]> res;
            if(filter is "" && top is -1)
            {
                res = await baseRequest.GetJsonAsync();

            }
            else if(filter is "")
            {
                res = await baseRequest.SetQueryParams(new
                {
                    top = top,
                }).GetJsonAsync();
            }
            else if(top is -1)
            {
                res = await baseRequest.SetQueryParams(new
                {
                    filter = filter
                }).GetJsonAsync();
            }
            else
            {
                res = await baseRequest.SetQueryParams(new
                {
                    filter = filter,
                    top = top
                }).GetJsonAsync();
            }

            return res.value;
        }
    }
}
