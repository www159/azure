namespace azure_m.Models.RequestModels
{
   namespace PublicIPAddress
    {
        namespace CreateOrUpdate
        {
            // TODO

            using RequestModels;

            public class PublicIPAddressProperties
            {
                public IPAlloctionMethod publicIPAllocationMethod;

                public int idleTimeoutInMinutes;

                public IPVersion publicIPAddressVersion;

                public PublicIPAddressDnsSettings dnsSettings;
            }//创建更新公共IP地址的参数

            public class PublicIPAddressDnsSettings
            {
                public string domainNameLabel;
            }//DNS设置

            public class IPVersion
            {
                public string IPv4;

                public string IPv6;
            }//IP版本4或6

            public class IPAlloctionMethod
            {
                public string Dynamic;

                public string Static;
            }//IP分配策略

            //public class PublicIPAddress
            //{
            //    public string id;

            //    public string location;

            //    public PublicIPAddressProperties properties;


            //}//被NetworkInterfaceRequestModel调用的一部分

            public class PublicIPAddressSku
            {
                public PublicIPAddressSkuName name;

                public PublicIPAddressSkuTier tier;
            }//创建/更新公共IP地址的主体的sku参数

            public class PublicIPAddressSkuTier
            {
                public string Basic;

                public string Standard;
            }//sku参数的Tier参数

            public class PublicIPAddressSkuName
            {
                public string Global;

                public string Regional;
            }//sku参数的name参数

            public class CreateOrUpdatePublicIPAddressBody
            {
                public string id;

                public string location;

                public PublicIPAddressProperties properties;

                public PublicIPAddressSku sku;
            }//创建/更新公共IP地址的主体

            public class CreateOrUpdatePublicIPAddressUri
            {
                public string publicIpAddressName;

                public string resourceGroupName;
            }//创建/更新公共IP地址的Uri

            public class CreateOrUpdatePublicIPAddressRequest : IRequest<
                CreateOrUpdatePublicIPAddressUri, CreateOrUpdatePublicIPAddressBody
                >
            { }//创建更新公共IP地址的请求
        }
    }
}
