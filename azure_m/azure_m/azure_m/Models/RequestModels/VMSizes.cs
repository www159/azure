using System;
using System.Collections.Generic;
using System.Text;

namespace azure_m.Models.RequestModels
{
    namespace VMSizes
    {
        namespace List
        {
            public class ListVMSizesBody
            {

            }
            public class ListVMSizesUri
            {
                public string location;
                //public string subscriptionId;
                //public string apiVersion;
            }
            public class ListVMSizesRequest : IRequest<ListVMSizesUri, ListVMSizesBody>
            {

            }
        }
    }
}
