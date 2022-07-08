using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace azure_m.Models
{
    namespace ResponseModels
    {
        public class ListMetricsResponse
        {
            public double cost { get; set; }
            public string interval { get; set; }
            public string resourceregion { get; set; }
            public string timespan { get; set; }
            public Metrics[] value { get; set; }
        }

        public class MetricsResponse: Metrics { }

        public class MetricsErrorResponse
        {
            public string message { get; set; }
            public string code { get; set; }
        }
        public class Metrics
        {
            public string displayDescription { get; set; }
            public string errorCode { get; set; }
            public string errorMessage { get; set; }
            public string id { get; set; }
            public LocalizableString name { get; set; }
            public string type { get; set; }
            public TimeSeriesElement[] timeseries { get; set; }
            public string unit { get; set; }
        }


        public class TimeSeriesElement
        {
            public MetricValue[] data { get; set; }
            public MetadataValue[] metadatavalues { get; set; }
        }
        public class MetricValue
        {
            public double average { get; set; }
            public double count { get; set; }
            public double maximum { get; set; }
            public double minimum { get; set; }
            public string timeStamp { get; set; }
            public double total { get; set; }
        }
        public class MetadataValue
        {
            public LocalizableString name { get; set; }
            public string value { get; set; }
        }

        public class MetricUnit
        {
            public string BitsPerSecond { get; set; }
            public string ByteSeconds { get; set; }
            public string Bytes { get; set; }
            public string BytesPerSecond { get; set; }
            public string Cores { get; set; }
            public string Count { get; set; }
            public string CountPerSecond { get; set; }
            public string MilliCores { get; set; }
            public string MilliSeconds { get; set; }
            public string NanoCores { get; set; }
            public string Percent { get; set; }
            public string Seconds { get; set; }
            public string Unspecified { get; set; }
        }
    }
}