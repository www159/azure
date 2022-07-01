using System;
using System.Collections.Generic;
using System.Text;

namespace azure_m.Services
{
    class FetchException: Exception
    {

        public string code;
        
        public FetchException() { }
        public FetchException(string message, Exception inner): base(message, inner) { }
        public FetchException(string code, string message): base(message)
        {
            this.code = code;
        }
    }
}
