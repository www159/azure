using System;
using System.Collections.Generic;
using System.Text;
using azure_m.Models.ResponseModels;
using static azure_m.Models.ResponseModels.PublicIPAdressResponse;

namespace azure_m.Models.ResponseModels
{
    public class NetworkInterfaceResponse
    {
        public string id { get; set; }
        public string location { get; set; }
        public string name { get; set; }
        public NetworkInterfaceProperties properties { get; set; }
        public string type { get; set; }
        public NetworkInterfaceResponse()
        {

        }
        public NetworkInterfaceResponse(string id,string location,string name,NetworkInterfaceProperties properties,string type)
        {
            this.id = id;
            this.location = location;
            this.name = name;
            this.properties = properties;
            this.type = type;
        }
        public class NetworkInterfaceProperties
        {
            public bool enableAcceleratedNetworking;

            public NetworkInterfaceIPConfiguration[] ipConfigurations;
        }
        public class NetworkInterfaceIPConfiguration
        {
            public string name;

            public NetworkInterfaceIPConfigurationProperties properties;
        }
        public class NetworkInterfaceIPConfigurationProperties
        {
            public PublicIPAddress publicIPAddress;

            public Subnet subnet;

            public SubResource gatewayLoadBalancer;
        }

    }

}
