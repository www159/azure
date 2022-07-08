using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Flurl;
using Flurl.Http;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Identity.Client;
using Xamarin.Forms;



namespace azure_m.Services
{

    using Models.ResponseModels;
    using Views;

    public static class ResourceType
    {

        public const string networkInterfaces = "networkInterfaces";

        public const string publicIPAddresses = "publicIPAddresses";

        public const string virtualNetworks = "virtualNetworks";

        public const string subnets = "subnets";

        public const string virtualMachines = "virtualMachines";

        public const string sshPublicKeys = "sshPublicKeys";

        public const string networkWatchers = "networkWatchers";

        public const string disks = "disks";

        public const string networkSecurityGroups = "networkSecurityGroups";

        public const string resources = "resources";

        public const string metrics = "metrics";

        public const string locations = "locations";
    }

    public static class QueryInfo
    {
        #region 验证相关
        public static string token { get; private set; }

        private static string subscriptionSql { get; set; } = "resourcecontainers\n        | where type == \"microsoft.resources/subscriptions\"\n        | join kind=leftouter (securityresources \n            | where type == \"microsoft.security/securescores\"\n            | where properties.environment == \"Azure\" and properties.displayName == \"ASC score\"\n            ) on subscriptionId\n        | extend secureScore=properties1.score.percentage,\n            managementGroup=properties.managementGroupAncestorsChain,\n            subscriptionName=name,\n            status=properties.state\n        | project id, subscriptionId, subscriptionName, status, managementGroup, secureScore";

        public static string subscriptionId { get; set; } = "219b2431-594f-47fa-8e85-664196aa3f92";

        public static string clientId { get; set; } = "89924e36-f70a-43c3-86c5-51bc7b5e8136";

        public static string tenantId { get; set; } = "453d8628-343d-48b9-b4d9-c0a97e4be3b7";

        public static string redirectUrl { get; set; } = "http://localhost";

        private static string[] scopes { get; set; } = new string[]
        {
            "https://management.azure.com/user_impersonation"
        };

         public static async Task getTokenAsync()
        {
            var app = PublicClientApplicationBuilder
                .Create(clientId)
                .WithAuthority(AzureCloudInstance.AzurePublic, tenantId)
                .WithRedirectUri(redirectUrl)
                .WithBroker()
                .Build();

            AuthenticationResult authResult = null;
            var accounts = await app.GetAccountsAsync();

            try
            {
                authResult = await app
                    .AcquireTokenSilent(scopes, accounts.FirstOrDefault())
                    .ExecuteAsync();
            }
            catch (MsalUiRequiredException ex)
            {
                Utils.error(ex);

                try
                {
                    authResult = await app
                        .AcquireTokenInteractive(scopes)
                        .WithParentActivityOrWindow(App.parentWindow)
                        .ExecuteAsync();

                }
                catch (MsalException msalEx)
                {
                    Utils.error(msalEx);
                }
                catch (Exception simpleEx)
                {
                    Utils.error(simpleEx);
                }
            }
            if (authResult != null)
            {
                token = authResult.AccessToken;
                baseRequest = new Url(baseStrUrl)
                    .WithOAuthBearerToken(token);

            }
        }

        //public static void setSubscriptions(string subscriptionId)
        //{
        //    baseRequest = baseRequest.AppendPathSegment(subscriptionId);
        //}

        // 暂定订阅的获取在getToken之后
        private static async Task getSubscriptionsAsync()
        {
            //https://management.azure.com/providers/Microsoft.ResourceGraph/resources?api-version=2021-03-01
            var url = new Url(baseUri)
                .AppendPathSegments(new[] {
                    "providers",
                    "Microsoft.ResourceGraph",
                    "resources"
                });

            var res = await Utils
                .withApiVersion(url, "2021-03-01")
                .WithOAuthBearerToken(token)
                .PostJsonAsync(new
                {
                    query = subscriptionSql,
                })
                .ReceiveJson<ListSubscriptionResponse>();
            subscriptionId = res.value[0].subscriptionId;

           // subscriptionId = res.data[0].subscriptionId;
        }


        #endregion

        #region 请求相关
        public static string baseUri { get; set; } = "https://management.azure.com/";
        public static string baseStrUrl
        {
            get => $"{baseUri}subscriptions/{subscriptionId}";
   
        }

        public static IFlurlRequest baseRequest { get; set; }


        public static Dictionary<string, string> resourceNamespace = new Dictionary<string, string> {
            [ResourceType.networkInterfaces] = "Microsoft.Network",
            [ResourceType.publicIPAddresses] = "Microsoft.Network",
            [ResourceType.virtualNetworks]   = "Microsoft.Network",
            [ResourceType.subnets]           = "Microsoft.Network",
            [ResourceType.virtualMachines]   = "Microsoft.Compute",
            [ResourceType.metrics]           = "Microsoft.Insight",
            //[ResourceType.locations]         = "Microsoft.Compute",
        };

        public const string subnetNameDefault = "default";

        public const string subnetIPDefault = "10.0.0.0/24";

        public const string ipSpaceDefault = "10.0.0.0/16";

        public const int fltominDefault = 10;
        
        private static string resourceIdFormat = "/subscriptions/{0}/resourceGroups/{1}/providers/{2}/{3}/{4}";

        public static string genSubnetId(string vnName, string resourceGroup, string subnetName) {
            var vnId = string.Format(
                resourceIdFormat,
                subscriptionId,
                resourceGroup,
                resourceNamespace[ResourceType.subnets],
                ResourceType.virtualNetworks,
                vnName);

            return $"{vnId}/{ResourceType.subnets}/{subnetName}";
        }

        public static string genResourceId(string resourceType, string resourceGroup, string name) {
            return string.Format(
                resourceIdFormat,
                subscriptionId,
                resourceGroup,
                resourceNamespace[resourceType],
                resourceType,
                name);
        }
       
       
        
        #endregion

        #region 全局资源
        public static List<ResourceGroup> resourceGroups;

        public static List<Subscription> subscriptions;

        public static List<VMSize> vmSizes;

        public static List<Location> locations;

        #endregion

        #region 服务注册

        public static void registerGlobal() {

            DependencyService.Register<VMOperations>();
            DependencyService.Register<VNOperations>();
            DependencyService.Register<VMSizesOperations>();
            DependencyService.Register<SubnetOperations>();
            DependencyService.Register<NetworkInterfaceOperations>();
            DependencyService.Register<PublicIPAdressOperations>();
            DependencyService.Register<ResourceGroupOperations>();
            DependencyService.Register<ResourceOperations>();
            DependencyService.Register<SubscriptionOperations>();
            DependencyService.Register<LocationOperations>();
            DependencyService.Register<ActivitylogOperations>();
            DependencyService.Register<MetricOperations>();
            DependencyService.Register<MetricDefinirtionOperations>();
            DependencyService.Register<MetricsNamespaceOperations>();
            // DependencyService.Register<>();
            // DependencyService.Register<>();
        }
        #endregion
    }
}
