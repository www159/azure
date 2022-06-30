using System;
using System.Collections.Generic;
using System.Text;

namespace azure_m.Models
{
    partial class MockModels
    {
        public class Data
        {
            public string timeStamp;
            public string average;
        }
        public class Index
        {
            public List<Data> data;
        }
    }
}
