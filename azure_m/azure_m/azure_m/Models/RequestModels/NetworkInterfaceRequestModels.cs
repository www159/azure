namespace azure_m.Models.RequestModels
{
    namespace NetworkInterfaceRequestModels
    {
        // TODO
        using PublicIPAddressRequestModels;
        public class NetworkInterfacesProperties
        {
            public bool enableAcceleratedNetworking;

            public NetworkInterfaceIPConfiguration ipConfigurations;
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

        public class SubResource
        {
            public string id;
        }

        public class Subnet
        {
            //public string etag;

            public string id;

            //public string name;
        }

        public class CreateOrUpdateNIBody
        {
            public string location;

            //public string id;

            //public string extendedLocation;

            public NetworkInterfacesProperties properties;
        }//建立网络接口的请求Body部分
        public class CreateOrUpdateNIUri
        {
            public string networkInterfaceName;

            public string resourceGroupName;

        }//建立网络接口的请求Uri部分

        public class CreateOrUpdateNIRequest : IRequest<
               CreateOrUpdateNIUri,
               CreateOrUpdateNIBody>
        { }//建立网络接口的请求 套用IRequest

    }
}
