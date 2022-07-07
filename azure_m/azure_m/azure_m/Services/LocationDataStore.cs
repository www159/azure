using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flurl.Http;
using azure_m.Models.RequestModels.Locations.List;

using Xamarin.Forms;
using System.Threading.Tasks;
using Flurl;

namespace azure_m.Services
{
    using Models.ResponseModels;
    public class LocationDataStore
    {
        private static class apiVersion
        {
            public const string list = "2022-03-01";
        }

        private string baseFormatUrl = $"{QueryInfo.baseStrUrl}/providers/Microsoft.Compute/Locations";
        public async Task queryListLocation()
        {
            var baseStrUrl = string.Format(baseFormatUrl);
            var url = Utils.withApiVersion(
                new Url(baseStrUrl),
                apiVersion.list);
            try
            {
                var res = await url
                    .GetJsonAsync<LocationResponse>();

            }
            catch (Exception ex)
            {
                Utils.error(ex);
            }

        }
    }
}