﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Flurl.Http;
using Newtonsoft.Json;

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

        public static T readMock<T>(string jsonStr)
        {

            var json = JsonConvert.DeserializeObject<T>(jsonStr);
            return json;
        }
    }

}
