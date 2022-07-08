﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using azure_m.ViewModels;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace azure_m.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class TargetViewPage : ContentPage
    {

        public TargetViewPage()
        {
            InitializeComponent();
            
        }



        private void ChooseTargetClicked(object sender, EventArgs e)
        {
            ChooseTarget.IsVisible = !ChooseTarget.IsVisible;
        }

        private void ApplyTargetClicked(object sender, EventArgs e)
        {     
            ChooseTarget.IsVisible = false;           
        }

        private void CancelTargetClicked(object sender, EventArgs e)
        {
            
            ChooseTarget.IsVisible = false;
        }
   

        private void Collection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ChooseRange.Text = (Collection.SelectedItem as azure_m.ViewModels.Sourse).Name;
            //ShowType.Text= (Collection.SelectedItem as azure_m.ViewModels.Sourse).SourseType;
            ChooseTarget.IsVisible = false;
            if (ShowType.Text == "虚拟机")
            {
                VirtualMachine.IsVisible = true;
                Disk.IsVisible = false;
                ValueChoose.Text = "度量值";
                CcrChart.IsVisible = false;
            }
            if (ShowType.Text == "磁盘")
            {
                VirtualMachine.IsVisible = false;
                Disk.IsVisible = true;
                ValueChoose.Text = "度量值";
                CcrChart.IsVisible = false;
            }
        }

        private void CcrClicked(object sender, EventArgs e)
        {
            VirtualMachine.IsVisible= false;
            ValueChoose.Text = "Ccr";
            CcrChart.IsVisible = true;

        }

        private void ValueChooseClicked(object sender,EventArgs e)
        {
            if (ShowType.Text == "虚拟机")
            {
                VirtualMachine.IsVisible = !VirtualMachine.IsVisible;
                Disk.IsVisible = false;
            }
            if (ShowType.Text == "磁盘")
            {
                Disk.IsVisible = !Disk.IsVisible;
                VirtualMachine.IsVisible = false;
            }
        }
    }
}