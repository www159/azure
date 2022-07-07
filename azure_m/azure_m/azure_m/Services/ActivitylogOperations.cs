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
        public string pretime = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
        public string timeofDay = DateTime.Now.TimeOfDay.ToString();//17：05：0415463格式的时间
        private static class apiVersion
        {
            public const string list = "2015-04-01";
        }
        public string resourceUri = "/subscriptions/219b2431-594f-47fa-8e85-664196aa3f92/resourceGroups/W_GROUP/providers/Microsoft.Compute/virtualMachines/w";
        public string filterFormat = @"eventTimestamp ge '{{0}}T{{1}}Z' and eventTimestamp le '{{2}}T{{3}}Z' and resourceUri eq '{{4}}'";
        private string baseFormatUrl = $"{QueryInfo.baseStrUrl}/providers/Microsoft.Insights/eventtypes/management/values";

        public async Task<ActivitylogResponse> ListActivityLogQuery (){
            var baseUrl = baseFormatUrl;
            ActivitylogResponse res=null;
            var filter = string.Format(filterFormat, pretime, timeofDay, time, timeofDay, resourceUri);
            Url url1 = Utils.withApiVersion(
                baseUrl, apiVersion.list
                );
            Url url = Utils.withFilterVersion(
                url1, filter
                );
            try
            {
                res = await url
                    .GetJsonAsync<ActivitylogResponse>();
                foreach (var activitylog in res.value)
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
                
               
            }catch(Exception ex)
            {
                Utils.error(ex);
            }
            return res;

        }
        public async Task getActivitylogs()
        {
            Activitylogs.Clear();
            ActivitylogResponse res;
            while (true)
            {
                try
                {
                    res = await ListActivityLogQuery();
                    foreach (var activitylog in res.value)
                    {
                        var simplifiedlog = new Activitylog
                        {
                            caller = activitylog.caller,
                            operationName = activitylog.operationName.localizedValue,
                            timestamp = activitylog.eventTimestamp,
                            status = activitylog.status.localizedValue
                        };
                        Activitylogs.Add(simplifiedlog);
                    }
                    if (res.nextLink == null)
                    {
                        break;
                    }
                    res = await Utils.queryWithNextLink<ActivitylogResponse>(res.nextLink);
                }catch(Exception ex)
                {
                    Utils.error(ex);
                }
            }
        }
    }
}
