using System;
using System.Collections.Generic;
using System.Text;
using Flurl;
using Flurl.Http;
using System.Threading.Tasks;
using azure_m.Models.ResponseModels;
using azure_m.Models;


namespace azure_m.Services
{
    using azure_m.Models.RequestModels.Activitylog.List;
    public class ActivitylogOperations
    {
       

        public List<Activitylog> Activitylogs { get; private set; }
        public string time = DateTime.Now.ToString("yyyy-MM-dd");//年-月-日格式的日期
        public string pretime = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
        public string timeofDay = DateTime.Now.TimeOfDay.ToString();//17：05：0415463格式的时间
        private static class apiVersion
        {
            public const string list = "2015-04-01";
        }
        public string resourceUri = "/subscriptions/219b2431-594f-47fa-8e85-664196aa3f92/resourceGroups/W_GROUP/providers/Microsoft.Compute/virtualMachines/w";
        public string filterFormat = "eventTimestamp ge '{0}T{1}Z' and eventTimestamp le '{2}T{3}Z' and resourceUri eq '{4}'";
        private string baseFormatUrl = $"{QueryInfo.baseStrUrl}/providers/Microsoft.Insights/eventtypes/management/values";

        public ActivitylogOperations()
        {
            Activitylogs = new List<Activitylog>();
        }

        public async Task<ListActivitylogResponse> ListActivityLogQuery()
        {
            var baseUrl = baseFormatUrl;
            ListActivitylogResponse res = null;
            var filter = string.Format(filterFormat, pretime, timeofDay, time, timeofDay, resourceUri);
            var url1 = Utils.withApiVersion(
                baseUrl, apiVersion.list
                );
            IFlurlRequest url = Utils.withFilter(
                url1, filter
                ).WithOAuthBearerToken(QueryInfo.token);
            var _filter = "eventTimestamp ge '2022-07-01T08:02:12.6756260Z' and eventTimestamp le '2022-07-08T08:02:12.6756260Z' and resourceUri eq '/subscriptions/219b2431-594f-47fa-8e85-664196aa3f92/resourceGroups/W_GROUP/providers/Microsoft.Compute/virtualMachines/w'";
            var _apiVersion = "2015-04-01";
            var _url = "https://management.azure.com/subscriptions/219b2431-594f-47fa-8e85-664196aa3f92/providers/Microsoft.Insights/eventtypes/management/values";
            var req = new Url(_url)
                .SetQueryParam("$filter", _filter)
                .SetQueryParam("api-version", _apiVersion)
                .WithOAuthBearerToken(QueryInfo.token);
            //string str;
            //// str = await req.GetStringAsync();
            //str = await req.GetStringAsync();
            try
            {
                
                res = await req
                    .GetJsonAsync<ListActivitylogResponse>();

                //foreach (var activitylog in res.value)
                //{
                //    var simplifiedlog = new Activitylog
                //    {
                //        caller = activitylog.caller,
                //        status = activitylog.status.localizedValue,
                //        operationName = activitylog.operationName.localizedValue,
                //        timestamp = activitylog.eventTimestamp,
                //        stautsValue = activitylog.status.value
                //    };    
                    
                //    Activitylogs.Add(simplifiedlog);                  
                //};
                
               
            }catch(Exception ex)
            {
                Utils.error(ex);
            }
            return res;

        }
        public async Task getActivitylogs()
        {
            ListActivitylogResponse res;
            try
            {
                res = await ListActivityLogQuery();

                var aLogList = Utils.arr2List(res.value);

                await Utils.loopQuery(aLogList, res);

                foreach (var activitylog in aLogList)
                {
                    var simplifiedlog = new Activitylog
                    {
                        caller = activitylog.caller,
                        status = activitylog.status.localizedValue,
                        operationName = activitylog.operationName.localizedValue,
                        timestamp = activitylog.eventTimestamp,
                        stautsValue = activitylog.status.value
                    };

                    Activitylogs.Add(simplifiedlog);
                };

            }
            catch (Exception ex)
            {
                Utils.error(ex);
            }
        }
    }
}
