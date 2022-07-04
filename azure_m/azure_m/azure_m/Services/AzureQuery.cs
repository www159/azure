using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Flurl;
using Flurl.Http;
using System.Threading.Tasks;
using azure_m.Models;
using azure_m.Views;
using System.Linq;
using Microsoft.Identity.Client;



namespace azure_m.Services
{


    public static class QueryInfo
    {
        private static string token { get; set; }
        private static string baseUri { get; set; } = "https://management.azure.com/";
        private static string subscriptionId { get; set; } = "219b2431-594f-47fa-8e85-664196aa3f92";
        public static string baseStrUrl
        {
            get
            {
                return $"{baseUri}subscriptions/{subscriptionId}";
            }
        }
        public static string clientId { get; set; } = "89924e36-f70a-43c3-86c5-51bc7b5e8136";
        public static string tenantId { get; set; } = "453d8628-343d-48b9-b4d9-c0a97e4be3b7";
        public static string redirectUrl { get; set; } = "http://localhost";
        public static IFlurlRequest baseRequest { get; set; }
        public static string methodHead { get; set; } = "X-Http-Method-Override";
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
                authResult = await app.AcquireTokenSilent(scopes, accounts.FirstOrDefault()).ExecuteAsync();
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
                catch(Exception simpleEx)
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

        public static void setSubscriptions(string subscriptionId)
        {
            baseRequest = baseRequest.AppendPathSegment(subscriptionId);
        }

        public static async Task getSubscriptionsAsync()
        {
            //https://management.azure.com/providers/Microsoft.ResourceGraph/resources?api-version=2021-03-01
            var url = new Url(baseUri)
                .AppendPathSegments(new[] {
                    "providers",
                    "Microsoft.ResourceGraph",
                    "resurces"
                });
            var res = await Utils.withApiVersion(url, "2021-03-01").GetJsonAsync<Subscriptions>();

            subscriptionId = res.data[0].subscriptionId;
        }
    }
}
