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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        public static string _token { get; set; } = "EwCIA8l6BAAUkj1NuJYtTVha%2bMogk%2bHEiPbQo04AATKbxvuuGpWneXHKSoiUENnv7jfhrRVyXeQjPQLD4R4Cz0/qH%2bZU2mD0bI8KIfDDeQnMM%2bjajXtlu%2bCg%2bgEoIv7SY4FjhpdW9ZWYdKRJ0GPcxQCl%2bkxEgFtBE/8QGj/xb9nPhWtZzmKQlvqSKZW2CtX0mksd6yxtC8/cVPnw34%2bC051oWPtQ6KcHY3GphIH8seWPP2R/CzRdXlQFLJRV2KgOni1aDFaz2Zqmqc9JrNH4qt4TEi3lLwi4yB4hpc51Tyyw521uZkrStHYh80pPi03eNAht4okysKehMiWLlxXZFNutnOen5Gb%2b%2bJyygKavLB4cIJSX2YaRJMq3g0vvijUDZgAACI5Mc0k8/2TsWALC1LriL7252yAMSZOHolK6VPuijlMcKHa%2btG7dG4AZl9/TwRUxg68wreH4CmVz9mZ5/n/hRD5sxaOvmjkmpdUX7EHARzVwWW7FrOZnOd76UHiHZUgQle9t56Ei6DXjLDY10cWJEs9ExPNE9gyd7wZ7qjKBzMMJMS6wgypfqSFYwYa/azdiBdQqQKxmy%2b2F3W1qZmjeaqg36H4AiUm6R9VrZ/KZE5TG3gCg4HXWvlmy6g0qYATrcK9O2bVOgs9f/tNH2xrWC%2bklGevpEiTvlxOQaH8kAGkKG%2bS7PUxGmvkch3aY38y5VQXRwkmmoM1YvYJzOPyMJ4XcAEeFx2BaU4PrKZ2F9xp4aNzD%2bB07RDpRXWIDwieVIrZWju70cfB/Y4MeMwpVw3L5KE6nh2xihHHCXI4MI3shsLDcsR73P96yZiBA%2buuqASw7DuUIlsbSCSjkhVx0w46DY1FskDQs/F24gYRKhk6PMwdiOGidsw97ocitTlpKnQ%2bVFh5ejY83n%2bOWVe4XUkUSoIR%2bqTUQ4s%2bWlNfbfOU8h%2b39TD0MQuRRUGs6P8%2boqMQ6n6GCiXneitzmhNCAbsSRfYVmVhzVm1pVfv5z4IBtm/%2bZsbxOpelwFzNTrJQrQZza2TsjyfrRKjnoRXQt/7bYG/AQUZAjhPUKw2nUe%2bCqk7GjRXB%2bgrV5Qq3P0uDmxXGRt1gR6HOZkok4FKfK1H%2betChmL3NUA39UPq391/UCCE9tXNFdAya8%2bkEfA2gzc9Jn8ijHmxqZtOufygDaFOTqasPknqWCGUz5EZYpJPJErzBxAg%3d%3d";
        public static IFlurlRequest baseRequest { get; set; } = new Url(apiPrefixAd)
            .SetQueryParam("api-version", apiVersion)
            .WithOAuthBearerToken(_token);
        public static QueryList queryList { get; set; } = new QueryList();

        
    }
    public class IResponseType<T>
    {
        public T value { get; set; }
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
                //res = await baseRequest.GetJsonAsync();
                //var ret = await new Url("http://localhost:8080/test/resources").GetStringAsync();
                //res = await new Url("http://localhost:8080/test/resources").GetJsonAsync();
                //res = JsonConvert.DeserializeObject(res);
                res = await baseRequest.GetJsonAsync<IResponseType<Resource[]>>();

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
