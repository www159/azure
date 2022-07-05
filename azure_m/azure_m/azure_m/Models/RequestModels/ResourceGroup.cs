namespace azure_m.Models.RequestModels
{
    namespace ResourceGroupRequestModels
    {
        namespace CreateOrUpdateResourceGroup
        {

            public class CreateOrUpdateResourceResourceGroupUri
            {
                public string resourceGroupName;
            }
            public class CreateOrUpdateResourceResourceGroupBody
            {
                public string location;
            }
            public class CreateOrUpdateResourceGroupRequest : IRequest<CreateOrUpdateResourceResourceGroupUri, CreateOrUpdateResourceResourceGroupBody>
            {

            }
        }//创建/更新资源组

        namespace GetResourceGroup
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

        namespace DeleteResourceGroup
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

        namespace ListResourceGroup
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
