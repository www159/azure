using System;
using System.Collections.Generic;
using System.Text;

namespace azure_m.Models
{
    public class Resource
    {
        public string name { get; set; }

        public string id { get; set; }

        public string type { get; set; }

        public string location { get; set; }

        public string imgUrl { get; set; }
    }
}
