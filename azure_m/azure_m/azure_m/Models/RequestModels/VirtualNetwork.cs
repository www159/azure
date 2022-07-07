namespace azure_m.Models.RequestModels
{
    namespace VN
    {
        namespace CreateOrUpdate
        {

            using ResponseModels;


            public class CreateOrUpdateVNRequest : IRequest<CreateOrUpdateVNUri, CreateOrUpdateVNBody>
            {
                public static CreateOrUpdateVNRequest create()
                {
                    return new CreateOrUpdateVNRequest
                    {
                        uri = new CreateOrUpdateVNUri { },

                        body = new CreateOrUpdateVNBody
                        {
                            properties = new CreateOrUpdateVNProperties
                            {
                                addressSpace = new AddressSpace { addressPrefixes = new string[2] },
                                subnets = new Subnet[]
                            {
                                new Subnet
                                {
                                    properties = new SubnetProperties
                                    {

                                    }
                                }
                            }

                            }
                        }
                    };

                }
            }

            public class CreateOrUpdateVNUri
            {
                public string resourceGroupName;
                public string virtualNetworkName;
            }
            public class CreateOrUpdateVNBody
            {
                public CreateOrUpdateVNProperties properties { get; set; }

                public string location { get; set; }
            }

            public class CreateOrUpdateVNProperties
                {
                    public AddressSpace addressSpace { get; set; }

                    public Subnet[] subnets { get; set; }

                    public VirtualNetworkBgpCommunities bgpCommunities { get; set; }

                    public int flowTimeOutInMinutes { get; set; }

                    public VirtualNetworkEncryption encryption { get; set; }
                }

                //public class AddressSpace
                //{
                //    public string[] addressPrefixes { get; set; }
                //}

                //public class Subnet
                //{
                //    public string etag { get; set; }

                //    public string id { get; set; }

                //    public string name { get; set; }

                //    public SubnetProperties properties { get; set; }

                //    public string type { get; set; }
                //}
                public class SubResource
                {
                    public string id { get; set; }
                }
                //public class SubnetProperties
                //{
                //    public string addressPrefix { get; set; }

                //    public string[] addressPrefixes { get; set; }

                //    public ApplicationGatewayIPConfiguration[] applicationGatewayIPConfigurations { get; set; }

                //    public Delegation[] delegations { get; set; }

                //    public SubResource[] ipAllocations { get; set; }

                //    public IPConfigurationProfile[] iPConfigurationProfiles { get; set; }

                //    public IPConfiguration[] iPConfigurations { get; set; }

                //    public SubResource natGateway { get; set; }

                //    public NetworkSecurityGroup networkSecurityGroup { get; set; }

                //    public VirtualNetworkPrivateEndpointNetworkPolicies privateEndpointNetworkPolicies { get; set; }

                //    public PrivateEndpoint[] privateEndpoints { get; set; }

                //    public VirtualNetworkPrivateLinkServiceNetworkPolicies privateLinkServiceNetworkPolicies { get; set; }

                //    public ProvisioningState provisioningState { get; set; }

                //    public string purpose { get; set; }

                //    public ResourceNavigationLink[] resourceNavigationLinks { get; set; }

                //    public RouteTable routeTable { get; set; }

                //    public ServiceAssociationLink[] serviceAssociationLinks { get; set; }

                //    public ServiceEndpointPolicy[] serviceEndpointPolicies { get; set; }

                //    public ServiceEndpointPropertiesFormat[] serviceEndpoints { get; set; }

                //}

                public class ProvisioningState
                {
                    public static string Deleting = "Deleting";

                    public static string Failed = "Failed";

                    public static string Succeed = "Succeeded";

                    public static string Updating = "Updating";
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
                    public ProvisioningState provisioningState { get; set; }

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

                public class IPConfigurationProperties
                {
                    public string privateIPAddress { get; set; }

                    public ProvisioningState provisioningState { get; set; }

                    public Subnet subnet { get; set; }

                    public string privateIPAllocationMethod { get; set; }

                    //public PublicIPAddress publicIPAddress { get; set; }
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

                public class NetworkSecurityGroupProperties
                {
                    //public SecurityRule[] defaultSecurityRules { get; set; }

                    //public Flowlog[] flowlogs { get; set; }

                    //public NetworkInterface[] networkInterfaces{ get; set;}

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

                public class VirtualNetworkBgpCommunities
                {
                    public string regionalCommunity { get; set; }

                    public string virtualNetworkCommunity { get; set; }
                }

                public class VirtualNetworkEncryption
                {
                    public bool enabled { get; set; }

                    public string enforcement { get; set; }
                }

            }
            namespace Get
            {
                public class GetVNRequest : IRequest<GetVNUri, GetVNBody> { }

                public class GetVNUri
                {
                    public string resourceGroupName;
                    public string virtualNetworkName;
                }
                public class GetVNBody
                {
                }
            }
            namespace List
            {
                public class ListVNRequest : IRequest<ListVNUri, ListVNBody> { }

                public class ListVNUri
                {
                    public string resourceGroupName;
                }
                public class ListVNBody
                {
                }
            }
            namespace Delete
            {
                public class DeleteVNRequest : IRequest<DeleteVNUri, DeleteVNBody> { }

                public class DeleteVNUri
                {
                    public string resourceGroupName;
                    public string virtualNetworkName;
                }
                public class DeleteVNBody
                {
                }
            }
            namespace ListAll
            {
                public class ListAllVNRequest : IRequest<ListAllVNUri, ListAllVNBody> { }

                public class ListAllVNUri
                {
                }
                public class ListAllVNBody
                {
                }
            }
        }
    }
