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
    using Services;
    public class LocationOperations
    {
        private static class apiVersion
        {
            public const string list = "2020-01-01";
        }

        //private string baseFormatUrl = $"{QueryInfo.baseStrUrl}/providers/Microsoft.Compute/Locations";
        public async Task<List<Location>> queryListLocation()
        {
            //var baseStrUrl = string.Format(baseFormatUrl);
            var url = Utils.baseStrUrlFull(
                apiVersion: apiVersion.list,
                type: ResourceType.locations);

            ListLocationResponse res;
            try
            {
                 res = await url.GetJsonAsync<ListLocationResponse>();

            }
            catch (Exception ex)
            {
                Utils.error(ex);
                return new List<Location> { new Location() };
            }

            List<Location> locations = Utils.arr2List(res.value);
            return locations;


        }
    }
}