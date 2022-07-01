using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using azure_m.Services;
using Xamarin.Forms;
using azure_m.Views;

namespace azure_m.ViewModels
{
    public class TargetViewModel : ContentView
    {
        public List<Models.MockModels.Data> Data { get; set; }
        public TargetViewModel()
        {
            var ret = Utils.readMock<azure_m.Models.MockModels.Index>(azure_m.Mocks.Mocks.index);
            ret.Data.ForEach(o =>
            {
                if (o.Average >= 1024&&o.Average<(1024*1024)) 
                { 
                    o.Average = o.Average / 1024; 
                }
                else if(o.Average>=(1024*1024)&&o.Average<(1024*1024*1024))
                {
                    o.Average = o.Average / (1024 * 1024);
                }
                else if(o.Average >= (1024*1024*1024))
                {
                    o.Average =o.Average/ (1024*1024*1024);
                }
            });
            Data = ret.Data;
        }
    }
}