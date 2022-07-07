namespace azure_m.Models.RequestModels
{
   namespace Subnet
    {
        namespace CreateOrUpdate
        {
            using ResponseModels;

            public class CreateOrUpdateSubnetUri
            {
                public string resourceGroupName;

                public string subnetName;

                public string virtualNetworkName;
            }
            public class CreateOrUpdateSubnetBody
            {
                public string location;

                public string id;

                public string name;

                public SubnetProperties properties;

                public string type;
            }
            public class CreateOrUpdateSubnetRequest : IRequest<CreateOrUpdateSubnetUri, CreateOrUpdateSubnetBody>
            {

            }
        } 
        namespace Delete
        {
            public class DeleteSubnetBody
            {

            }
            public class DeleteSubnetUri
            {
                public string resourceGroupName;
                public string subnetName;
                public string virtualNetworkName;
            }
            public class DeleteSubnetRequest : IRequest<DeleteSubnetUri, DeleteSubnetBody>
            {

            }
        }
        namespace List
        {
            public class ListSubnetBody
            {

            }
            public class ListSubnetUri
            {
                public string resourceGroupName;
                public string virtualNetworkName;
            }
            public class ListSubnetRequest : IRequest<ListSubnetUri, ListSubnetBody>
            {

            }
        }
        namespace Get
        {
            public class GetSubnetBody
            {

            }
            public class GetSubnetUri
            {
                public string resourceGroupName;
                public string virtualNetworkName;
                public string subnetName;
            }
            public class GetSubnetRequest : IRequest<GetSubnetUri, GetSubnetBody>
            {

            }
        }
    }
}
