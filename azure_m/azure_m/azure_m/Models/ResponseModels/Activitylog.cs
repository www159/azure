using System;
using System.Collections.Generic;
using System.Text;

namespace azure_m.Models.ResponseModels
{
    public class ActivitylogResponse
    {
        public EventData[] value;
        public string nextLink;
    }
    public class EventData
    {
        public string caller;

        public LocalizableString operationName;

        public LocalizableString status;

        public string eventTimestamp;
    }
    public class LocalizableString
    {
        public string localizedValue;

        public string value;
    }
}
