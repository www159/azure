using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace azure_m.Models
{
    namespace ResponseModels
    {
        public class Location
        {
            public string name { get; set; }
            public string displayName { get; set; }
        }

        public class LocationResponse : Location { }

        public class ListLocationResponse: ListResponse<Location> { }
    }
}