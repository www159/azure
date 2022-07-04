using System;
using System.Collections.Generic;
using System.Text;

namespace azure_m.Models.RequestModels
{
    namespace VNReuestModels
    {
        namespace CreateOrUpdate
        {

            public class CreateOrupdateVNRequest<CreateOrupdateVNUri, CreateOrUpdateNIBody>{}

            public class CreateOrupdateVNUri {}
            public class CreateOrUpdateVNBody
            {
                public CreateOrUpdateVNProperties properties { get; set; }

                public string location {get;set;}
            }
            public class CreateOrUpdateVNProperties
            {
                public AddressSpace addressSpace { get;set;}

                public Subnet[] subnets { get; set;}

                public VirtualNetworkBgpCommunities bgpCommunities { get; set;}

                public int flowTimeOutInMinutes { get; set;}

                public VirtualNetworkEncryption encryption { get; set;}
            }

            public class AddressSpace
            {
                public string[] addressPrefixes { get; set;}
            }

            public class Subnet
            {
                //public string etag;

                //public string id;
                
                public string name { get; set;}

                public SubnetProperties properties { get; set; }

            }

            public class SubnetProperties
            {
                public string addressPrefix { get; set;}

                public string[] addressPrefixes { get;  set; }

                public Delegation[] delegations { get; set; }

                public ServiceEndpointPropertiesFormat[] serviceEndpoints { get; set; }

                public ServiceEndpointPolicy[] serviceEndpointPolicies { get; set; }
            }

            public class Delegation
            {
                public string etag { get; set; }

                public string id { get; set; }

                public string name { get; set;}

                public DelegationProperties properties { get; set; }

                public string type { get; set; }
            }

            public class DelegationProperties
            {
                public string[] actions { get; set; }

                public string serviceName { get; set; }

                //public ProvisioningState provisioningState;
            }

            public class ServiceEndpointPropertiesFormat
            {
                public string[] locations { get; set; }

                public string service { get; set; }

                //public ProvisioningState provisioning;
            }

            public class ServiceEndpointPolicy
            {
                public string id { get; set;}

                public string etag { get; set;}

                public string kind { get; set; }

                public string location { get; set; }

                public string name { get; set;}

                public object tags { get; set; }

                public string type { get; set; }

                //public ServiceEndpointPolicyProperties ServiceEndpointPolicy;
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
    }
}
