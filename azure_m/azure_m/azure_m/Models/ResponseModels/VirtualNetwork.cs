using System;
using System.Collections.Generic;
using System.Text;

namespace azure_m.Models
{

    namespace ResponseModels
    {

        public class ListVirtualNetworkResponse : ListNResponse<VirtualNetwork> { }

        public class VirtualNetworkResponse : VirtualNetwork { }
        public class VirtualNetwork
        {
            public string etag { get; set; }

            public ExtendedLocation extendedLocation { get; set; }

            public string id { get; set; }

            public string location { get; set; }

            public string name { get; set; }

            public VirtualNetworkProperties properties { get; set; }

            public object tags { get; set; }

            public string type { get; set; }
        }

        public class ExtendedLocation
        {
            public string name { get; set; }

            public string type { get; set; }
        }

        public class VirtualNetworkProperties
        {
            public AddressSpace addressSpace { get; set; }

            public VirtualNetworkBgpCommunities bgpCommunities { get; set; }

            public SubResource ddosProtectionPlan { get; set; }

            public DhcpOptions dhcpOptions { get; set; }

            public bool enableDdosProtection { get; set; }

            public bool enableVmProtection { get; set; }

            public VirtualNetworkEncryption encryption { get; set; }

            public int flowTimeoutInMinutes { get; set; }

            public SubResource[] ipAllocations { get; set; }

            public string provisioningState { get; set; }

            public string resourceGuid { get; set; }

            public Subnet[] subnets { get; set; }

            public VirtualNetworkPeering[] virtualNetworkPeerings { get; set; }


        }

        public class AddressSpace
        {
            public string[] addressPrefixes { get; set; }
        }

        public class VirtualNetworkBgpCommunities
        {
            public string regionalCommunity { get; set; }

            public string virtualNetworkCommunity { get; set; }
        }

        public class DhcpOptions
        {
            public string[] dnsServers { get; set; }
        }

        public class VirtualNetworkEncryption
        {
            public bool enabled { get; set; }

            public string enforcement { get; set; }
        }

        public class SubResource
        {
            public string id { get; set; }
        }

        public class ProvisioningState
        {
            public static string Deleting = "Deleting";

            public static string Failed = "Failed";

            public static string Succeed = "Succeeded";

            public static string Updating = "Updating";
        }

        public class Subnet
        {
            public string etag { get; set; }

            public string id { get; set; }

            public string name { get; set; }

            public SubnetProperties properties { get; set; }

            public string type { get; set; }
        }

        public class SubnetProperties
        {
            public string addressPrefix { get; set; }

            public string[] addressPrefixes { get; set; }

            public ApplicationGatewayIPConfiguration[] applicationGatewayIPConfigurations { get; set; }

            public Delegation[] delegations { get; set; }

            public SubResource[] ipAllocations { get; set; }

            public IPConfigurationProfile[] iPConfigurationProfiles { get; set; }

            public IPConfiguration[] iPConfigurations { get; set; }

            public SubResource natGateway { get; set; }

            public NetworkSecurityGroup networkSecurityGroup { get; set; }

            public string privateEndpointNetworkPolicies { get; set; }

            public PrivateEndpoint[] privateEndpoints { get; set; }

            public string privateLinkServiceNetworkPolicies { get; set; }

            public string provisioningState { get; set; }

            public string purpose { get; set; }

            public ResourceNavigationLink[] resourceNavigationLinks { get; set; }

            public RouteTable routeTable { get; set; }

            public ServiceAssociationLink[] serviceAssociationLinks { get; set; }

            public ServiceEndpointPolicy[] serviceEndpointPolicies { get; set; }

            public ServiceEndpointPropertiesFormat[] serviceEndpoints { get; set; }

        }

        public class ApplicationGatewayIPConfiguration
        {
            public string etag { get; set; }

            public string id { get; set; }

            public string name { get; set; }

            public string type { get; set; }

            public ApplicationGatewayIPConfigurationProperties properties { get; set; }

        }

        public class ApplicationGatewayIPConfigurationProperties
        {
            public string provisioningState { get; set; }

            public SubResource sebnet { get; set; }
        }

        public class Delegation
        {
            public string etag { get; set; }

            public string id { get; set; }

            public string name { get; set; }

            public string type { get; set; }

            public DelegationProperties properties { get; set; }
        }

        public class DelegationProperties
        {
            public string[] actions { get; set; }

            public ProvisioningState provisioningState { get; set; }

            public string serviceName { get; set; }
        }

        public class IPConfigurationProfile
        {
            public string etag { get; set; }

            public string id { get; set; }

            public string name { get; set; }

            public string type { get; set; }

            public IPConfigurationProfileProperties properties { get; set; }
        }

        public class IPConfigurationProfileProperties
        {
            public ProvisioningState provisioningState { get; set; }

            public Subnet subnet { get; set; }
        }

        public class IPConfiguration
        {
            public string etag { get; set; }

            public string id { get; set; }

            public string name { get; set; }

            public IPConfigurationProperties properties { get; set; }
        }
     
        public class PublicIPAddress
            {
                public string id;

                public string location;

                public PublicIPAddressProperties properties;

                public PublicIPAddressSku sku;


            }

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

        public class IPConfigurationProperties
        {
            public string privateIPAddress { get; set; }

            public ProvisioningState provisioningState { get; set; }

            public Subnet subnet { get; set; }

            public string privateIPAllocationMethod { get; set; }

            public PublicIPAddress publicIPAddress { get; set; }
        }

        public class NetworkSecurityGroup
        {
            public string etag { get; set; }

            public string id { get; set; }

            public string location { get; set; }

            public string name { get; set; }

            public NetworkSecurityGroupProperties properties { get; set; }

            public object tags { get; set; }

            public string type { get; set; }
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

        public class NetworkInterface
        {
            public string id { get; set; }
            public string location { get; set; }
            public string name { get; set; }
            public NetworkInterfaceProperties properties { get; set; }
            public string type { get; set; }

            

        }

        public class NetworkSecurityGroupProperties
        {
            //public SecurityRule[] defaultSecurityRules { get; set; }

            //public Flowlog[] flowlogs { get; set; }

            public NetworkInterface[] networkInterfaces { get; set; }

            public ProvisioningState provisioningState { get; set; }

            public string resourceGuid { get; set; }

            //public SecurityRule[] securityRules { get; set; }

            public Subnet[] subnets { get; set; }
        }

        public class VirtualNetworkPrivateEndpointNetworkPolicies
        {
            public static string Disabled = "Disabled";

            public static string Enable = "Enable";
        }

        public class PrivateEndpoint
        {
            public string etag { get; set; }

            public string id { get; set; }

            public string location { get; set; }

            public string name { get; set; }

            //public PrivateEndpointProperties privateEndpoint{ get; set;}

            public object tags { get; set; }

            public string type { get; set; }
        }

        public class VirtualNetworkPrivateLinkServiceNetworkPolicies
        {
            public static string Disabled = "Disabled";

            public static string Enable = "Enable";
        }

        public class ResourceNavigationLink
        {
            public string etag { get; set; }

            public string id { get; set; }

            public string location { get; set; }

            public string name { get; set; }

            public ResourceNavigationLinkProperties properties { get; set; }

            public string type { get; set; }
        }

        public class ResourceNavigationLinkProperties
        {
            public string link { get; set; }

            public string linkedResourceType { get; set; }

            public ProvisioningState provisioningState { get; set; }
        }

        public class RouteTable
        {
            public string etag { get; set; }

            public string id { get; set; }

            public string location { get; set; }

            public string name { get; set; }

            public RouteTableProperties properties { get; set; }

            public string type { get; set; }
        }

        public class RouteTableProperties
        {
            public bool disableBgpRoutePropagation { get; set; }

            public ProvisioningState provisioningState { get; set; }

            public string resourceGuid { get; set; }

            //public Route[] routes { get; set; }

            public Subnet[] subnets { get; set; }
        }

        public class ServiceAssociationLink
        {
            public string etag { get; set; }

            public string id { get; set; }

            public string name { get; set; }

            public ServiceAssociationLinkProperties properties { get; set; }

            public string type { get; set; }
        }

        public class ServiceAssociationLinkProperties
        {
            public bool allowDelete { get; set; }

            public string link { get; set; }

            public string linkedResourceType { get; set; }

            public string[] locations { get; set; }

            public ProvisioningState provisioningState { get; set; }
        }

        public class ServiceEndpointPolicy
        {
            public string etag { get; set; }

            public string id { get; set; }

            public string kind { get; set; }

            public string location { get; set; }

            public string name { get; set; }

            public ServiceEndpointPolicyProperties properties { get; set; }

            public object tags { get; set; }

            public string type { get; set; }
        }

        public class ServiceEndpointPolicyProperties
        {
            public string[] contextualServiceEndpointPolicies { get; set; }

            public ProvisioningState provisioningState { get; set; }

            public string resourceGuid { get; set; }

            public string serviceAlias { get; set; }

            public ServiceEndpointPolicyDefinition[] serviceEndpointPolicyDefinitions { get; set; }

            public Subnet[] subnets { get; set; }
        }

        public class ServiceEndpointPolicyDefinition
        {
            public string etag { get; set; }

            public string id { get; set; }

            public string name { get; set; }

            public string description { get; set; }

            public ProvisioningState provisioningState { get; set; }

            public string service { get; set; }

            public string[] serviceResources { get; set; }
        }

        public class ServiceEndpointPropertiesFormat
        {
            public string[] locations { get; set; }

            public ProvisioningState provisioningState { get; set; }

            public string service { get; set; }
        }

        public class VirtualNetworkPeering
        {
            public string etag { get; set; }

            public string id { get; set; }

            public string name { get; set; }

            public VirtualNetworkPeeringProperties properties { get; set; }

            public string type { get; set; }
        }

        public class VirtualNetworkPeeringProperties
        {
            public bool alloForwarderTraffic { get; set; }

            public bool allowGatewayTraffic { get; set; }

            public bool allowVirtualNetworkAccess { get; set; }

            public bool doNotVerifyRemoteGateways { get; set; }

            public VirtualNetworkPeeringState peeringState { get; set; }

            public VirtualNetworkPeeringLevel peeringSyncLecel { get; set; }

            public ProvisioningState provisioningState { get; set; }

            public AddressSpace remoteAddressSpace { get; set; }

            public VirtualNetworkBgpCommunities remoteBgpCommunities { get; set; }

            public SubResource remoteVirtualNetwork { get; set; }

            public AddressSpace remoteVirtualNetworkAddressSpace { get; set; }

            public VirtualNetworkEncryption virtualNetworkEncryption { get; set; }

            public string resourceGuid { get; set; }

            public bool useRemoteGateways { get; set; }
        }

        public class VirtualNetworkPeeringLevel
        {
            public static string FullyInSync = "FullyInSync";

            public static string LocalAndRemoteNotInSync = "LocalAndRemoteNotInSync";

            public static string LocalNotInSync = "LocalNotInSync";

            public static string RemoteNotInSync = "RemoteNotInSync";
        }

        public class VirtualNetworkPeeringState
        {
            public static string Connected = "Connected";

            public static string Disconnected = "Disconnected";

            public static string Initiated = "Initiated";
        }
    }
}
