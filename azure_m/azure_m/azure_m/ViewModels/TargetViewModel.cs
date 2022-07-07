using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using azure_m.Services;
using Xamarin.Forms;
using azure_m.Views;

namespace azure_m.ViewModels
{
    public class TargetViewModel : BaseViewModel
    {
        public List<Sourse> Sourses { get; set; }

        public string targetName { get; set; }

        public static int _checkedIndex { get; set; }

        
        
        public List<Models.MockModels.Data> Ccr { get; set; }
        public List<Models.MockModels.Data> Ccc { get; set; }
        public List<Models.MockModels.Data> Amb { get; set; }
        public List<Models.MockModels.Data> Dobo { get; set; }
        public TargetViewModel()
        {
            var ccr = Utils.readMock<azure_m.Models.MockModels.Index>(azure_m.Mocks.Mocks.ccr);
            var ccc = Utils.readMock<azure_m.Models.MockModels.Index>(azure_m.Mocks.Mocks.ccc);
            var amb = Utils.readMock<azure_m.Models.MockModels.Index>(azure_m.Mocks.Mocks.amb);
            var dobo = Utils.readMock<azure_m.Models.MockModels.Index>(azure_m.Mocks.Mocks.dobo);
            ccr.Data.ForEach(o =>
            {
                o.Average = o.Average / (1024 * 1024);
            });
            ccc.Data.ForEach(o =>
            {
                o.Average = o.Average / (1024 * 1024);
            });
            amb.Data.ForEach(o =>
            {                    
                o.Average = o.Average / (1024 * 1024);
            });
            dobo.Data.ForEach(o =>
            {
                o.Average = o.Average / (1024 * 1024);
            });
            Ccr = ccr.Data;
            Ccc = ccc.Data;
            Amb = amb.Data;
            Dobo = dobo.Data;

            Sourses = new List<Sourse>()
            {
               new Sourse{Name="Vm",SourseType="虚拟机"},
               new Sourse{Name="Disc",SourseType="磁盘"},
            };            
    }
       

      

    }
    public class Sourse
    {
        public string Name { get; set; }
        public string SourseType { get; set; }
    }
}