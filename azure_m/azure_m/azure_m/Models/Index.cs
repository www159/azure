using System;
using System.Collections.Generic;
using System.Text;
using azure_m.Services;

namespace azure_m.Models
{
    namespace MockModels
    {
        public class Data
        {
            public string TimeStamp { get; set; }
            public double Average { get; set; }
        }       
        public class Index
        {        
            public List<Data> Data { get; set; }
        }
    }

}
