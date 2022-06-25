using System;


namespace azure_m.Models
{


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
    public class Resource
    {
        public string location { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        //public object Properties { get; set; }
        //public string provisioningState { get; set; }

        public Resource()
        {

        }

        public Resource(string location, string name, string id, string type)
        {
            this.location = location;
            this.name = name;
            this.id = id;
            this.type = type;
        }
    }
}
