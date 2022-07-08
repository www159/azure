using System;
using System.Collections.Generic;
using System.Text;

namespace azure_m.Models.ResponseModels
{
    public class ListActivitylogResponse: ListResponse<EventData> { }

    public class EventData
    {
        public string caller { get; set; }

        public LocalizableString operationName { get; set; }

        public LocalizableString status { get; set; }

        public string eventTimestamp { get; set; }
    }
    public class LocalizableString
    {
        public string localizedValue { get; set; }

        public string value { get; set; }
    }
}
