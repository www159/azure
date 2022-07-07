namespace azure_m.Models.RequestModels
{
    namespace NetworkInterface
    {

        // TODO
        namespace CreateOrUpdate
        {
            using ResponseModels;

            public class NetworkInterfacesProperties
            {
                public bool enableAcceleratedNetworking;

                public NetworkInterfaceIPConfiguration[] ipConfigurations;
            }//网络接口请求主体的参数
            //public class NetworkInterfaceIPConfiguration
            //{
            //    public string name;

            //    public NetworkInterfaceIPConfigurationProperties properties;
            //}//网络接口参数的一部分
            //public class NetworkInterfaceIPConfigurationProperties
            //{
            //    public PublicIPAddress publicIPAddress;

            //    public Subnet subnet;

            //    public SubResource gatewayLoadBalancer;
            //}//网络接口IP配置的参数

            public class SubResource
            {
                public string id;
            }//属于网络接口IP配置参数的一部分


            public class CreateOrUpdateNIBody
            {
                public string location;

                //public string id;

                //public string extendedLocation;

                public NetworkInterfacesProperties properties;
            }//建立网络接口的请求主体部分
            public class CreateOrUpdateNIUri
            {
                public string networkInterfaceName;

                public string resourceGroupName;

            }//建立网络接口的请求主体部分

            public class CreateOrUpdateNIRequest : IRequest<
                   CreateOrUpdateNIUri,
                   CreateOrUpdateNIBody>
            { }//建立网络接口的请求 套用IRequest
        }

    }
}
