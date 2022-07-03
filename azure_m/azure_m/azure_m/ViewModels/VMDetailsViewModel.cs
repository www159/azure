#define DEBUG
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using azure_m.Models;
using azure_m.Models.RequestModels.VMRequestModels.CreateOrUpdate;
using Xamarin.Forms;
using System.Threading.Tasks;
using azure_m.Services;
using System.Diagnostics;

namespace azure_m.ViewModels
{
    public class VMDetailsViewModel : BaseViewModel
    {

        public Dictionary<string, string> subscribes { get; set; } 
        public List<string> subscribesNames { get; set; }
        public string subscribeID;
        public List<string> resourceGroups { get; set; }
        public CreateOrUpdateVMRequest vm = new CreateOrUpdateVMRequest();
        public VMDetailsViewModel()
        {
#if DEBUG
            subscribes = new Dictionary<string, string> { { "免费试用", "123" } };
            subscribesNames = subscribes.Keys.ToList();
            resourceGroups = new List<string>() { "wfpres" };
            Views.AddVmDetailsPage.SubscribeIndexChange += ChangeSubID;
#endif
        }

        private void ChangeSubID(object sender, int i)
        {
            subscribes.TryGetValue(subscribesNames[i], out subscribeID);
        }

        //ContentView basic, disk, net, manage, adv, tag, create;
        //public ObservableCollection<ContentView> pages { get; set; }
        //public void init()
        //{
        //    Title = "创建虚拟机";
        //    basic = new Views.VMDetails.Basic();
        //    disk = new Views.VMDetails.Disk();
        //    net = new Views.VMDetails.Net();
        //    manage = new Views.VMDetails.Manage();
        //    adv = new Views.VMDetails.Advance();
        //    tag = new Views.VMDetails.Tag();
        //    create = new Views.VMDetails.Create();
        //    pages = new ObservableCollection<ContentView>
        //    {
        //        basic, disk,
        //        net,
        //        manage, adv,
        //        tag,
        //        create
        //    };
        //}


    }
}
