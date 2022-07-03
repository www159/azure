using System;
using System.Collections.Generic;
using System.Text;

namespace azure_m.Models.RequestModels
{
    namespace VNReuestModels
    {
        namespace CreateOrUpdate
        {
            public class CreateOrUpdateVNBody
            {
                public CreateOrUpdateVNProperties properties;

                public string location;
            }

            public class CreateOrUpdateVNProperties
            {
                public AddressSpace addressSpace;

                public Subnet[] subnets;

                public VirtualNetworkBgpCommunities bgpCommunities;

                public int flowTimeOutInMinutes;

                public VirtualNetworkEncryption encryption;
            }

            public class AddressSpace
            {
                public string[] addressPrefixes;
            }

            public class Subnet
            {
                //public string etag;

                //public string id;
                
                public string name;

                public SubnetProperties properties;

            }

            public class SubnetProperties
            {
                public string addressPrefix;

                public string[] addressPrefixes;

                public Delegation[] delegations;

                public ServiceEndpointPropertiesFormat[] serviceEndpoints;

                public ServiceEndpointPolicy[] serviceEndpointPolicies;
            }

            public class Delegation
            {
                public string etag;

                public string id;

                public string name;

                public DelegationProperties properties;

                public string type;
            }

            public class DelegationProperties
            {
                public string[] actions;

                public string serviceName;

                //public ProvisioningState provisioningState;
            }

            public class ServiceEndpointPropertiesFormat
            {
                public string[] locations;

                public string service;

                //public ProvisioningState provisioning;
            }

            public class ServiceEndpointPolicy
            {
                public string id;

                public string etag;

                public string kind;

                public string location;

                public string name;

                public object tags;

                public string type;

                //public ServiceEndpointPolicyProperties ServiceEndpointPolicy;
            }

            public class VirtualNetworkBgpCommunities
            {
                public string regionalCommunity;

                public string virtualNetworkCommunity;
            }

            public class VirtualNetworkEncryption
            {
                public bool enabled;

                public string enforcement;
            }

        }
    }
}
