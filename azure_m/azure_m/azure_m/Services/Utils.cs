﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Flurl.Http;
using System.Security;

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

        public static Dictionary<string, string> ImgMap = new Dictionary<string, string>()
        {
            ["networkWatchers"] = "networkWatchers.png",
            ["storageAccounts"] = "storageAccounts.png",
            ["disks"] = "disks.png",
            ["sshPublicKeys"] = "sshPublicKeys.png",
            ["virtualMachines"] = "virtualMachines.png",
            ["networkInterfaces"] = "networkInterfaces.png",
            ["netWorkSecurityGroups"] = "netWorkSecurityGroups.png",
            ["publicIPAddresses"] = "publicIPAddresses.png",
            ["virtualNetworks"] = "virtualNetworks.png",
        };

        public static SecureString str2secStr(string str)
        {
            SecureString secureStr = new SecureString();    
            foreach(var ch in str) {
                secureStr.AppendChar(ch);
            }
            return secureStr;
        }
    }

}
