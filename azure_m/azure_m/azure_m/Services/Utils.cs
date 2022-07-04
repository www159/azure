using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Flurl.Http;
using System.Security;
using Newtonsoft.Json;
using Flurl;

namespace azure_m.Services
{
    static partial class Utils
    {
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



        public static SecureString str2secStr(string str)
        {
            SecureString secureStr = new SecureString();    
            foreach(var ch in str) {
                secureStr.AppendChar(ch);
            }
            return secureStr;
    
        }
            public static T readMock<T>(string jsonStr)
        {

            var json = JsonConvert.DeserializeObject<T>(jsonStr);
            return json;
        }
    }

}
