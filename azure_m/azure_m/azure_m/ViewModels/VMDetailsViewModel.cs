﻿using System;
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
    public class VMDetailsViewModel : BaseViewModel
    {

        ContentView basic, disk, net, manage, adv, tag, create;

        public ObservableCollection<ContentView> pages;

        public VMDetailsViewModel()
        {
            Title = "创建虚拟机";
            basic = new Views.VMDetails.Basic();
            disk = new Views.VMDetails.Disk();
            pages = new ObservableCollection<ContentView>
            {
                basic,
                disk
            };

        }


    }
}