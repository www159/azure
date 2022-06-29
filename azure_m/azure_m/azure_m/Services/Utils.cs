using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Flurl.Http;

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

        public static class ImgMap
        {
            public static string networkWatchers = "";
            public static string storageAccounts = "";
            public static string disks = "";
            public static string sshPublicKeys = "";
            public static string virtualMachines = "";
            public static string networkInterfaces = "";
            public static string netWorkSecurityGroups = "";
            public static string publicIPAddresses = "";
            public static string virtualNetworks = "";
        }
    }

}
