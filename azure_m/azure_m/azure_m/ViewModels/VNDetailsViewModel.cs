using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using azure_m.Models;
using Xamarin.Forms;
using System.Threading.Tasks;
using azure_m.Services;
using System.Diagnostics;


namespace azure_m.ViewModels
{
    public class VNDetailsViewModel : BaseViewModel
    {

        ContentView basic, ipAddress, security, tag, checkAndCreate;

        public ObservableCollection<ContentView> pages { get; set; }

        public VNDetailsViewModel()
        {
            Title = "创建虚拟网络";
            basic = new Views.VNDetails.Basic();
            ipAddress = new Views.VNDetails.IPAddress();
            security = new Views.VNDetails.Security();
            tag = new Views.VNDetails.Tag();
            checkAndCreate = new Views.VNDetails.CheckAndCreate();
            pages = new ObservableCollection<ContentView>
            {
                basic, ipAddress, security, tag, checkAndCreate
                //net, 
                //manage, adv, tag, create
            };

        }


    }
}
