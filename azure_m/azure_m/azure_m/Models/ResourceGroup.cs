using System;
using System.Collections.Generic;
using System.Text;

namespace azure_m.Models
{
    public class ResourceGroup
    {
        public string id { get; set; }
        public string location { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public ResourceGroupProperties properties { get; set; }
        //public string tags;
        //public string managedBy;
        public ResourceGroup()
        {

        }
        public ResourceGroup(string id,string location,string name,string type,ResourceGroupProperties resourceGroupProperties)
        {
            this.id = id;
            this.location = location;
            this.name = name;
            this.type = type;
            this.properties.provisioningState = resourceGroupProperties.provisioningState;
        }
    }

    public class ResourceGroupProperties
    {
        public string provisioningState { get; set; }
    }
   

}
