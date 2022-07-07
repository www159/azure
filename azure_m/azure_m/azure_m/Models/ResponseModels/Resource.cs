namespace azure_m.Models
{

    namespace ResponseModels
    {

        public class ListResourceResponse: ListResponse<GenericResourceExpanded> { } 

        public class ResourceResponse: GenericResourceExpanded { }

        public class GenericResourceExpanded
        {
            public string id { get; set; }

            public string name { get; set; }

            public string location { get; set; }

            public string type { get; set; }
        }
        //public class BaseAzureItem
        //{
        //    public string Name { get; set; }
        //    public string Id { get; set; }
        //    public object Properties { get; set; }
        //}


        /// <summary>
        /// 用于所有资源列表
        /// </summary>
        /// <typeparam name="T">虚拟资源，对应虚拟资源类型</typeparam>
        //public class Resource
        //{
        //    [JsonProperty("location")]
        //    public string location { get; set; }
        //    [JsonProperty("name")]
        //    public string name { get; set; }
        //    [JsonProperty("id")]
        //    public string id { get; set; }
        //    [JsonProperty("type")]
        //    public string type { get; set; }
        //    //public object Properties { get; set; }
        //    //public string provisioningState { get; set; }

        //    public string imgUrl { get; set; }

        //    public Resource()
        //    {

        //    }

        //    public Resource(string location, string name, string id, string type)
        //    {
        //        this.location = location;
        //        this.name = name;
        //        this.id = id;
        //        this.type = type;
        //    }
        //}
    }
}
