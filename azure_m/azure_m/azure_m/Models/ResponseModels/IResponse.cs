using System;
using System.Collections.Generic;
using System.Text;

namespace azure_m.Models.ResponseModels
{
    public class ListResponse<T>
    {
        public string nextLink { get; set; }

        public T[] value { get; set; }
    }

    public class ListNResponse<T>
    {
        public T[] value { get; set; }
    }
}
