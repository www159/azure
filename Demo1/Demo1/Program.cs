using Microsoft.Identity.Client;
using Flurl.Http;
using Flurl;

// See https://aka.ms/new-console-template for more 
string _clientId = "89924e36-f70a-43c3-86c5-51bc7b5e8136";
string _tenantId = "453d8628-343d-48b9-b4d9-c0a97e4be3b7";
string endpoint = "https://login.microsoftonline.com/common/oauth2/authorize";
var app = PublicClientApplicationBuilder
.Create(_clientId)
.WithAuthority(AzureCloudInstance.AzurePublic, _tenantId)
.WithRedirectUri("http://localhost")
.Build();

string[] scopes = new string[]
{
    "https://management.azure.com/user_impersonation"
};

var accounts = await app.GetAccountsAsync();

    var account = accounts.FirstOrDefault();

    var resS = await app.AcquireTokenSilent(scopes, account).ExecuteAsync();

AuthenticationResult res = await app.AcquireTokenInteractive(scopes).ExecuteAsync();

Console.WriteLine(res.AccessToken, res.AuthenticationResultMetadata);


var tokenReq = new Url("https://login.microsoftonline.com/common/oauth2/authorize")
    .SetQueryParams(new Dictionary<string, string>
    {
        ["client_id"] = _clientId
    });

var req = new Url("https://management.azure.com/subscriptions/219b2431-594f-47fa-8e85-664196aa3f92")
    .AppendPathSegment("resources")
    .WithOAuthBearerToken(res.AccessToken)
    .SetQueryParam("api-version", "2021-04-01");

//var response = tokenReq.GetStringAsync().Result;
var response = req.GetJsonAsync().Result;

Console.WriteLine(response);
