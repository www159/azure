using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Identity.Client;
using Flurl.Http;
using Flurl.Util;
using Flurl;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Azure.Identity;

namespace flurltestForm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var cred = new 
        }

        public async Task<string> GetHttpContentWithToken(string url, string token)
        {
            var httpClient = new System.Net.Http.HttpClient();
            //System.Net.Http.HttpResponseMessage response;
            try
            {
                var request = new Url(url).WithOAuthBearerToken(token);
                //var request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Get, url);
                //Add the token in Authorization header
                //request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token
                //response = await httpClient.SendAsync(request);
                //var content = await response.Content.ReadAsStringAsync();
                var content = await request.GetStringAsync();
                return content;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        private async void SignOutButton_Click(object sender, RoutedEventArgs e)
        {
            var accounts = await App.PublicClientApp.GetAccountsAsync();

            if (accounts.Any())
            {
                try
                {
                    await App.PublicClientApp.RemoveAsync(accounts.FirstOrDefault());
                    this.ResultText.Text = "User has signed-out";
                    this.CallGraphButton.Visibility = Visibility.Visible;
                    this.SignOutButton.Visibility = Visibility.Collapsed;
                }
                catch (MsalException ex)
                {
                    ResultText.Text = $"Error signing-out user: {ex.Message}";
                }
            }
        }

        /// <summary>
        /// Display basic information contained in the token
        /// </summary>
        private void DisplayBasicTokenInfo(AuthenticationResult authResult)
        {
            TokenInfoText.Text = "";
            if (authResult != null)
            {
                TokenInfoText.Text += $"Username: {authResult.Account.Username}" + Environment.NewLine;
                TokenInfoText.Text += $"Token Expires: {authResult.ExpiresOn.ToLocalTime()}" + Environment.NewLine;
            }
        }
    }
    public partial class MainWindow : Window
    {
        //Set the API Endpoint to Graph 'me' endpoint
        string graphAPIEndpoint = "https://graph.microsoft.com/v1.0/me";

        //Set the scope for API call to user.read
        string[] scopes = new string[] { "user.read" };


        /// <summary>
        /// Call AcquireToken - to acquire a token requiring user to sign-in
        /// </summary>
        private async void CallGraphButton_Click(object sender, RoutedEventArgs e)
        {
            AuthenticationResult authResult = null;
            var app = App.PublicClientApp;
            ResultText.Text = string.Empty;
            TokenInfoText.Text = string.Empty;

            var accounts = await app.GetAccountsAsync();
            var firstAccount = accounts.FirstOrDefault();

            try
            {
                authResult = await app.AcquireTokenSilent(scopes, firstAccount)
                    .ExecuteAsync();
            }
            catch (MsalUiRequiredException ex)
            {
                // A MsalUiRequiredException happened on AcquireTokenSilent.
                // This indicates you need to call AcquireTokenInteractive to acquire a token
                System.Diagnostics.Debug.WriteLine($"MsalUiRequiredException: {ex.Message}");

                try
                {
                    authResult = await app.AcquireTokenInteractive(scopes)
                        .WithAccount(accounts.FirstOrDefault())
                        .WithPrompt(Prompt.SelectAccount)
                        .ExecuteAsync();
                }
                catch (MsalException msalex)
                {
                    ResultText.Text = $"Error Acquiring Token:{System.Environment.NewLine}{msalex}";
                }
            }
            catch (Exception ex)
            {
                ResultText.Text = $"Error Acquiring Token Silently:{System.Environment.NewLine}{ex}";
                return;
            }

            //if (authResult != null)
            //{
            ResultText.Text = await GetHttpContentWithToken(graphAPIEndpoint, authResult.AccessToken);
            //var ret = await QueryInfo.queryList.resources.listResources("", -1);
            //ResultText.Text = ret.ToString();
            DisplayBasicTokenInfo(authResult);
            this.SignOutButton.Visibility = Visibility.Visible;
            //}
        }
    }



    public static class QueryInfo
    {
        public const string queryPrefix = "https://management.azure.com/subscriptions/";
        public static string subscriptionId = "219b2431-594f-47fa-8e85-664196aa3f92";
        public const string apiVersion = "2021-04-01";
        public static string apiPrefixAd = queryPrefix + subscriptionId;
        //public static string apiPrefixAd { get { return queryPrefix + subscriptionId; } }
        public static string apiVersionAd { get { return "api-version=" + apiVersion; } }

        public static string _token { get; set; } = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6ImpTMVhvMU9XRGpfNTJ2YndHTmd2UU8yVnpNYyIsImtpZCI6ImpTMVhvMU9XRGpfNTJ2YndHTmd2UU8yVnpNYyJ9.eyJhdWQiOiJodHRwczovL21hbmFnZW1lbnQuY29yZS53aW5kb3dzLm5ldC8iLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC80NTNkODYyOC0zNDNkLTQ4YjktYjRkOS1jMGE5N2U0YmUzYjcvIiwiaWF0IjoxNjU2MTMzNjAxLCJuYmYiOjE2NTYxMzM2MDEsImV4cCI6MTY1NjEzODg0OCwiYWNyIjoiMSIsImFpbyI6IkFVUUF1LzhUQUFBQWpCNm0reTRsVkQvcVRoWkp1dnN4MVFqZmZad2ZuYzdXWFdXSDJYTnFaalJ4WU5MYzVVVS9KRG9MRUs0aHpnVEhnakFsYi9GMEFKL09lUmlEUW1VMDNRPT0iLCJhbHRzZWNpZCI6IjE6bGl2ZS5jb206MDAwMzQwMDEwMkZERUZBMiIsImFtciI6WyJwd2QiXSwiYXBwaWQiOiJjNDRiNDA4My0zYmIwLTQ5YzEtYjQ3ZC05NzRlNTNjYmRmM2MiLCJhcHBpZGFjciI6IjIiLCJlbWFpbCI6IjIxMDc3OTUyNDRAcXEuY29tIiwiZmFtaWx5X25hbWUiOiJwZXRlciIsImdpdmVuX25hbWUiOiJmdSIsImdyb3VwcyI6WyJjMmRiNzk0My1lNWZiLTQ2YzItYWMyZC0yY2Y0M2VkYTNiMzEiXSwiaWRwIjoibGl2ZS5jb20iLCJpcGFkZHIiOiIxMDMuMTUyLjExMi4xNTAiLCJuYW1lIjoicGV0ZXIgZnUiLCJvaWQiOiJmYWQ1OTE2ZS0xNjk4LTQ5NmMtYmVlNi1iNjMxOTI0Mjc3NWMiLCJwdWlkIjoiMTAwMzIwMDIwNzQ3OTM5MSIsInJoIjoiMC5BVlVBS0lZOVJUMDB1VWkwMmNDcGZrdmp0MFpJZjNrQXV0ZFB1a1Bhd2ZqMk1CT0lBTm8uIiwic2NwIjoidXNlcl9pbXBlcnNvbmF0aW9uIiwic3ViIjoiLXRXcUk5ZDlkX1BmTFFETkZQd3hfUjlRQjNXWWswN25KbzZPdkxyU2ZyUSIsInRpZCI6IjQ1M2Q4NjI4LTM0M2QtNDhiOS1iNGQ5LWMwYTk3ZTRiZTNiNyIsInVuaXF1ZV9uYW1lIjoibGl2ZS5jb20jMjEwNzc5NTI0NEBxcS5jb20iLCJ1dGkiOiI2Y1cxTXlMRk4wT3pMLTE2MmVrUUFBIiwidmVyIjoiMS4wIiwid2lkcyI6WyI2MmU5MDM5NC02OWY1LTQyMzctOTE5MC0wMTIxNzcxNDVlMTAiXSwieG1zX3RjZHQiOjE2NTU3MDM0NjV9.CsUdUvvoaUlx3weuQNpVrnF0DRwkerCGT9nj6LG-ZqucCamO-gnCohhE8Fm6oSF7Mo8JkkaJ7eD-SVJ-ItYhhZlmRvUHJsKpuRhRKCH4rZrVjSn_6kViRIhMhRXtYeAs_QkYOYjgpYLRKDcAqmx4XQ1dlultKTemDDO24EqN7QJNMUoLGENPkN8-xKHmmUa6fXt5z20yrNcWIZaeYkU_FiMRGAA0n9lpJlcN5BV26tu8st1Y60Tm_m-8UCKmimQx4qAHCSURnZhnrLo0-VAYysLuq1PLUCDJSmeduFd71dblGVfAi_m8_eJiMWn8_0XQzzRsY1O__dcO7DbdBxFvWQ";    public static IFlurlRequest baseRequest { get; set; } = new Url(apiPrefixAd)
            .SetQueryParam("api-version", apiVersion)
            .WithOAuthBearerToken(_token);
        public static QueryList queryList { get; set; } = new QueryList();

        public static JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
            DateFormatString = "yyyy-MM-dd HH:mm",
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };
        public static T DynamicToEntity<T>(dynamic o)
        {
            string json = JsonConvert.SerializeObject(o, Settings);
            return JsonConvert.DeserializeObject<T>(json, Settings);
        }

    }


    public class QueryList
    {
        public ResourcesQuery resources = new ResourcesQuery();
    }


    public record IResType<T>
    {
        public T value { get; set; }
    }

    public class ResourcesQuery
    {
        //IFlurlRequest baseRequest = new FlurlRequest();
        IFlurlRequest baseRequest = QueryInfo.baseRequest.AppendPathSegment("resources");

        public async Task<Resource[]> listResources(string filter, int top)
        {
            dynamic res;
            if (filter is "" && top is -1)
            {
                var ret = await new Url("http://localhost:8080/test/resources").GetStringAsync();
                //res = await baseRequest.GetStringAsync();
                //res = JsonConvert.DeserializeObject<IResType<Resource[]>>(res);
                res = await baseRequest.GetJsonAsync<IResType<Resource[]>>();

            }
            else if (filter is "")
            {
                res = await baseRequest.SetQueryParams(new
                {
                    top = top,
                }).GetStringAsync();
                res = JsonConvert.DeserializeObject<IResType<Resource[]>>(res);
            }
            else if (top is -1)
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

            //return res.value;
            return res.value;
            //return QueryInfo.DynamicToEntity<Resource[]>(res.value);
        }
    }
    public class Resource
    {
        public string location { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        //public object Properties { get; set; }
        //public string provisioningState { get; set; }


    }
}
