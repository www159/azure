using System;
using System.Collections.Generic;
using System.Text;

namespace azure_m.Models
{
    public class Activitylog
    {
        public string imgUrl { get; set; }

        public string status { get; set; }

        public string operationName { get; set; }

        public string timestamp { get; set; }

        public string caller { get; set; }

        public string stautsValue { get; set; }
    }
}
