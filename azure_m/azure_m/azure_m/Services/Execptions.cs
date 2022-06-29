using System;
using System.Collections.Generic;
using System.Text;

namespace azure_m.Services
{
    class FetchExecption: ApplicationException
    {
        public FetchExecption(): base("返回值为空")
        {
            
        }
        public FetchExecption(string message): base(message)
        {
            
        }
    }
}
