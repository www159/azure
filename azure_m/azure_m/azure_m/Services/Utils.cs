using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Flurl.Http;
using System.Security;
using Newtonsoft.Json;
using Flurl;
using System.Threading.Tasks;
using System.Linq;

namespace azure_m.Services
{
    using Models.ResponseModels;

    using Models.RequestModels.Metrics.List;
    using Xamarin.Forms;
    using azure_m.Models.RequestModels.VMSizes.List;

    static partial class Utils
    {

        #region 异常
        public static Action<Exception> errorMethod { get; set; }

        static Utils()
        {
            errorMethod = e => { Debug.WriteLine(e); };
        }

        public static void error(Exception e)
        {
            errorMethod.Invoke(e);
        }

        public static void error(string s = "")
        {
            errorMethod.Invoke(new Exception(s));
        }

        public static IFlurlRequest withApiVersion(IFlurlRequest req, string apiVersion)
        {
            return req.SetQueryParam("api-version", apiVersion);
        }

        public static Url withApiVersion(Url url, string apiVersion)
        {
            return url.SetQueryParam("api-version", apiVersion);
        }
        public static IFlurlRequest withFilter(IFlurlRequest url, string filter)
        {
            return url.SetQueryParam("$filter", filter);
        }

        public static Url withFilter(Url url, string filter)
        {
            return url.SetQueryParam("$filter", filter);
        }

        #endregion
        #region 类型转化
        public static SecureString str2secStr(string str)
        {
            SecureString secureStr = new SecureString();
            foreach (var ch in str)
            {
                secureStr.AppendChar(ch);
            }
            return secureStr;

        }
        public static T readMock<T>(string jsonStr)
        {

            var json = JsonConvert.DeserializeObject<T>(jsonStr);
            return json;
        }

        public static List<T> arr2List<T>(T[] arr)
        {
            return (arr.Clone() as T[]).ToList<T>();
        }


        #endregion

        #region 请求

        public static IFlurlRequest baseStrReq(string url, string apiVersion)
        {
            return withApiVersion(new Url(url), apiVersion).WithOAuthBearerToken(QueryInfo.token);
        }

        public static IFlurlRequest baseStrUrlFull(
            string apiVersion,
            string type,
            string resourceGroup = "",
            string _namespace = "",
            string name = "")
        {

            string url = $"{QueryInfo.baseStrUrl}{(resourceGroup == "" ? "" : $"/resourceGroups/{resourceGroup}")}{(_namespace == "" ? "" : $"/providers/{_namespace}")}/{type}{(name == "" ? "" : $"/{name}")}";
            IFlurlRequest req = withApiVersion(new Url(url), apiVersion).WithOAuthBearerToken(QueryInfo.token);
            return req;
        }

        public static async Task<T> queryWithNextLink<T>(string url)
        {
            var req = new Url(url).WithOAuthBearerToken(QueryInfo.token);
            return await req.GetJsonAsync<T>();
        }

        public static async Task loopQuery<T, V>(List<V> list, T res)
            where T : ListResponse<V>
        {

            while (true)
            {
                if (res.nextLink == null) break;
                res = await queryWithNextLink<T>(res.nextLink);
                foreach (var val in res.value)
                {
                    list.Add(val);
                }
            }
        }
        #endregion
        #region metric 请求参数
        public static IFlurlRequest baseMetricUrl(
            string apiVersion,
            string resourceUri)
        {
            string url = $"{QueryInfo.baseStrUrl}/{resourceUri}/providers/{QueryInfo.resourceNamespace[ResourceType.metrics]}/{ResourceType.metrics}";
            return withApiVersion(url, apiVersion).WithOAuthBearerToken(QueryInfo.token);
        }


        private static string[] timeDurationStr = new string[] {
            "Y", "M", "D", "H", "M", "S"
        };

        public static string ISODuration(int[] timeList)
        {
            if (timeList.Length != 6) throw new Exception("timeList必须大小为6");
            string baseStr = "P";
            for (var i = 0; i < timeList.Length; i++)
            {
                if (timeList[i] == 0)
                {
                    if (i == 2)
                    {
                        if (baseStr == "P") baseStr += "0T";
                        else baseStr += "T";
                    }
                    continue;
                }
                baseStr += $"{timeList[i]}{timeDurationStr[i]}";
                if (i == 2) baseStr += "T";
            }
            return baseStr;
        }


        public static ListMetricsUriQuery metricQueryDefault()
        {
            return new ListMetricsUriQuery
            {
                aggregation = "average",
                interval = ISODuration(new int[] { 0, 0, 0, 1, 0, 0 }),


            };
        }
        #endregion

        #region 跳转异步回调特化
        public static async Task beforeAddVMDetialPage()
        {
            //service
            ResourceGroupOperations resourceGroupOperations = DependencyService.Get<ResourceGroupOperations>();
            LocationOperations locationOperations = DependencyService.Get<LocationOperations>();
            VMSizesOperations vmSizesOperations = DependencyService.Get<VMSizesOperations>();

            //query
            QueryInfo.resourceGroups = await resourceGroupOperations.ListResourceGroup();
            QueryInfo.locations = await locationOperations.queryListLocation();
            //默认选第一个地区
            QueryInfo.vmSizes = await vmSizesOperations.queryListVMSizes(new ListVMSizesRequest
            {
                uri = new ListVMSizesUri
                {
                    location = QueryInfo.locations.FirstOrDefault().name
                },
            });
            //animate
            Xamarin.Essentials.Vibration.Vibrate(500);
            #endregion
        }

        public static async Task beforeJumpAddVNDetialPage()
        {
            ResourceGroupOperations resourceGroupOperations = DependencyService.Get<ResourceGroupOperations>();
            LocationOperations locationOperations = DependencyService.Get<LocationOperations>();

            QueryInfo.resourceGroups = await resourceGroupOperations.ListResourceGroup();
            QueryInfo.locations = await locationOperations.queryListLocation();
        }
    }
}