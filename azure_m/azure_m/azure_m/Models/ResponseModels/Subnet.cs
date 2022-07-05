using System;
using System.Collections.Generic;
using System.Text;

namespace azure_m.Models.ResponseModels
{
    public class Subnet
    {
        public string etag { get; set; }

        public string id { get; set; }

        public string name { get; set; }

        public SubnetProperties properties { get; set; }

        public string type { get; set; }

        public Subnet()
        {

        }
        public Subnet(string etag, string id, string name, SubnetProperties properties, string type)
        {
            this.etag = etag;
            this.id = id;
            this.name = name;
            this.properties = properties;
            this.type = type;
        }
    }
       public class SubnetProperties
    {
        public string addressPrefix { get; set; }

        public string[] addressPrefixes { get; set; }
    }
       
}
