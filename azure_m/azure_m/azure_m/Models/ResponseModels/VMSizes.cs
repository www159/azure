using System;
using System.Collections.Generic;
using System.Text;

namespace azure_m.Models
{
    namespace ResponseModels
    {

        public class ListVMSizeResponse: ListResponse<VMSize> { }

        public class VMSizeResponse: VMSize { }

        public class VMSize
        {
            public int maxDataDiskCount { get; set; }

            public int memoryInMB { get; set; }

            public string name { get; set; }

            public int numberOfCores { get; set; }

            public int osDiskSizeInMB { get; set; }

            public int resourceDiskSizeInMB { get; set; }
        }
    }
}
