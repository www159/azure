namespace azure_m.Models.RequestModels
{
    namespace ResourceGroup
    {
        namespace CreateOrUpdate
        {

            public class CreateOrUpdateResourceGroupUri
            {
                public string resourceGroupName;
            }
            public class CreateOrUpdateResourceGroupBody
            {
                public string location;
            }
            public class CreateOrUpdateResourceGroupRequest : IRequest<CreateOrUpdateResourceGroupUri, CreateOrUpdateResourceGroupBody>
            {

            }
        }//创建/更新资源组

        namespace Get
        {
            public class GetResourceGroupBody
            {

            }
            public class GetResourceGroupUri
            {
                public string resourceGroupName;
            }
            public class GetResourceGroupRequest : IRequest<GetResourceGroupUri, GetResourceGroupBody>
            {

            }
        }//获取指定资源组信息

        namespace Delete
        {
            public class DeleteResourceGroupBody
            {

            }
            public class DeleteResourceGroupUri
            {
                public string resourceGroupName;
            }
            public class DeleteResourceGroupRequest : IRequest<DeleteResourceGroupUri, DeleteResourceGroupBody>
            {

            }
        }//删除指定资源组

        namespace List
        {
            public class ListResourceGroupBody
            {

            }
            public class ListResourceGroupUri
            {
            }
            public class ListResourceGroupRequest : IRequest<ListResourceGroupUri, ListResourceGroupBody>
            {

            }
        }//列出所有资源组
    }
}
