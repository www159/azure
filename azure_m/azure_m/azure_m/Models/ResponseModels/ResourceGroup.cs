namespace azure_m.Models.ResponseModels
{

    public class ResourceGroupResponse : ResourceGroup { }

    public class ResourceGroup
    {
        public string id { get; set; }
        public string location { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public ResourceGroupProperties properties { get; set; }
        //public string tags;
        //public string managedBy;
    }

    public class ResourceGroupProperties
    {
        public string provisioningState { get; set; }
    }


}
