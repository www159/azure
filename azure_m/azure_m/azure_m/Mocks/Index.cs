namespace azure_m.Mocks
{
    partial class Mocks
    {
        public static string ccr = "{\"data\":[{\"timeStamp\":\"2022-06-29T01:55:00Z\",\"average\":595591168},{\"timeStamp\":\"2022-06-29T02:00:00Z\",\"average\":595591168},{\"timeStamp\":\"2022-06-29T02:05:00Z\",\"average\":595591168},{\"timeStamp\":\"2022-06-29T02:10:00Z\",\"average\":595486310.4},{\"timeStamp\":\"2022-06-29T02:15:00Z\",\"average\":595591168},{\"timeStamp\":\"2022-06-29T02:20:00Z\",\"average\":595591168}]}";
        public static string ccc = "{\"data\":[{\"timeStamp\":\"2022-06-29T01:55:00Z\",\"average\":595591168},{\"timeStamp\":\"2022-06-29T02:00:00Z\",\"average\":595591168},{\"timeStamp\":\"2022-06-29T02:05:00Z\",\"average\":595591168},{\"timeStamp\":\"2022-06-29T02:10:00Z\",\"average\":595486310.4},{\"timeStamp\":\"2022-06-29T02:15:00Z\",\"average\":595591168},{\"timeStamp\":\"2022-06-29T02:20:00Z\",\"average\":595591168},{\"timeStamp\":\"2022-06-29T02:20:00Z\",\"average\":595591168}]}";
        public static string amb = "{\"data\":[{\"timeStamp\":\"2022-06-29T01:55:00Z\",\"average\":595591168},{\"timeStamp\":\"2022-06-29T02:00:00Z\",\"average\":595591168},{\"timeStamp\":\"2022-06-29T02:05:00Z\",\"average\":595591168},{\"timeStamp\":\"2022-06-29T02:10:00Z\",\"average\":595486310.4},{\"timeStamp\":\"2022-06-29T02:15:00Z\",\"average\":595591168},{\"timeStamp\":\"2022-06-29T02:22:00Z\",\"average\":595591168}]}";

        public static class MetricNamesVM
        {

            public static string AvailableMemBytes = "Available Memory Bytes";

            public static string CPUCreditsConsumed = "CPU Credits Consumed";

            public static string CPUCreditsRemaining = "CPU Credits Remaining";
        }

        public static class MetricNamesDisk
        {

            public static string DiskOnDemandBurstOperations = "Disk On-demand Burst Operations";

        }

        public static class MetricReqUriQuery
        {
            public static string aggregation = "average";

            public static string interval = "PT1H";

        }

    }
}