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
using Flurl.Http;
using Flurl;



namespace azure_m.Services
{


    public static class QueryInfo
    {
        private static string token { get; set; }
        public static string clientId { get; set; }
        public static string tenantId { get; set; }
        public static IFlurlRequest baseRequest { get; set; }
        private static string[] scopes { get; set; } = new string[]
        {
            "https://management.azure.com/user_impersonation"
        };

        public static async Task getToken()
        {
            var app = PublicClientApplicationBuilder
                .Create(clientId)
                .WithAuthority(AzureCloudInstance.AzurePublic, tenantId)
                .WithDefaultRedirectUri()
                .Build();

            var accounts = await app.GetAccountsAsync();
            var firstAccount = accounts.FirstOrDefault();
            AuthenticationResult authResult = null;

            try
            {
                authResult = await app.AcquireTokenSilent(scopes, firstAccount).ExecuteAsync();
            } 
            catch(MsalUiRequiredException ex)
            {
                Utils.error(ex);

                try
                {
                    authResult = await app
                        .AcquireTokenInteractive(scopes)
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
            if(authResult != null)
            {
                token = authResult.AccessToken;
                baseRequest = new Url("https://management.azure.com/subscriptions")
                    .WithOAuthBearerToken(token);
            }
        }
    }
}
