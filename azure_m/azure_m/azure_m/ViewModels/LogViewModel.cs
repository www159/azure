using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using azure_m.Models;
using azure_m.Services;
using Xamarin.Forms;

namespace azure_m.ViewModels
{
    public class LogViewModel : ContentView
    {
        public List<Models.MockModels.Data> Data { get; set; }
        public LogViewModel()
        {
            var ret = Utils.readMock<azure_m.Models.MockModels.Index>(azure_m.Mocks.Mocks.index);
            Data = ret.Data;
        }
    }
}