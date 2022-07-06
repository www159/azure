namespace azure_m.Models.ResponseModels
{

    public class ResourceGroupResponse
    {

        public string nextLink { get; set; }  

        public ResourceGroup[] value { get; set; }

    }

    public class ResourceGroup
    {
        public string id { get; set; }
        public string location { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public ResourceGroupProperties properties { get; set; }
        public object tags;
        public string managedBy;
    }

    public class ResourceGroupProperties
    {
        public string provisioningState { get; set; }
    }


}
