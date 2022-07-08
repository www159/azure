using System;
using System.Collections.Generic;
using System.Text;

namespace azure_m.Models.RequestModels
{
    public class IRequest<T, U>
    {
        public T uri;

        public U body;
    }

    public class QueryRequest<T, U, V> {

        public T uriPath;

        public U uriQuery;

        public V body;
    }
}
