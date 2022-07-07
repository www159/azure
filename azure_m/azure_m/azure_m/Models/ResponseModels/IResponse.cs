using System;
using System.Collections.Generic;
using System.Text;

namespace azure_m.Models.ResponseModels
{
    public class IResponse<T>
    {
        T[] value { get; set; } 
    }
}
