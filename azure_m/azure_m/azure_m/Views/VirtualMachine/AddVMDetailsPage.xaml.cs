using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace azure_m.Views
{
    using ViewModels;
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddVMDetailsPage : CarouselPage
    {
        public AddVMDetailsPage()
        {
            BindingContext = new VMDetailsViewModel();
            InitializeComponent();
            ViewModels.VMDetailsViewModel.CreateFinishd += VMDetailsViewModel_CreateFinishd;
        }

        private void VMDetailsViewModel_CreateFinishd(object sender, int StatusCode)
        {
            if(StatusCode < 300 && StatusCode > 199)
            {
                Navigation.PopAsync();
                DisplayAlert($"虚拟机{(sender as ViewModels.VMDetailsViewModel).VMName}创建成功","","OK");
            }
            else
            {
                Xamarin.Essentials.Vibration.Vibrate(500);
                DisplayAlert($"虚拟机创建失败", "", "OK");
            }
        }

        private void valid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(valid.SelectedIndex == 0) { sshFrame.IsVisible =c_sshkey.IsVisible= true; pswdFrame.IsVisible = c_pswd.IsVisible=false; }
            else { sshFrame.IsVisible = c_sshkey.IsVisible = false; pswdFrame.IsVisible = c_pswd.IsVisible = true; }
        }

        private void UserName_Completed(object sender, EventArgs e)
        {

        }

        private void passwd_Completed(object sender, EventArgs e)
        {

        }

        public static EventHandler passwdComplete;
        private void passwd2_Completed(object sender, EventArgs e)
        {
            //if(valid)
            passwdComplete?.Invoke(sender, EventArgs.Empty);
        }

        public static event EventHandler ResourceGroupIndexChanged;
        private void resourcesGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResourceGroupIndexChanged?.Invoke(sender, EventArgs.Empty);
            c_resGroup.Text = resourcesGroup.SelectedItem.ToString();
        }

        public static event EventHandler<int> SubscribeIndexChange;
        private void subscribe_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubscribeIndexChange?.Invoke(sender, subscribe.SelectedIndex);
            c_subscribeName.Text = subscribe.SelectedItem.ToString();
        }

        public static event EventHandler AreaChanged;
        private void areas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (areas.SelectedIndex != -1) { AreaChanged?.Invoke(sender, EventArgs.Empty); }
        }

        public static event EventHandler accessIndexChanged;
        private void availabilty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (availabilty.SelectedIndex != -1) { accessIndexChanged?.Invoke(sender, EventArgs.Empty); }
        }
        
        private void safetymode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public static event EventHandler ImagesIndexChanged;
        private void images_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (images.SelectedIndex != -1) { ImagesIndexChanged?.Invoke (sender, EventArgs.Empty); }
        }

        public static event EventHandler vmSizeIndexChanged;
        private void vmSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(vmSize.SelectedIndex!=-1) { vmSizeIndexChanged?.Invoke(sender, EventArgs.Empty); }
        }

        private void openentryPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            port.IsVisible = openentryPort.SelectedIndex==0?false:true;
        }

        public static event EventHandler diskTypeIndexChanged;
        private void disk_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            diskTypeIndexChanged?.Invoke(sender, EventArgs.Empty);
        }

        private void delete_Clicked(object sender, EventArgs e)
        {
            allStack.Children.RemoveAt(1);

        }

        private void delete2_Clicked(object sender, EventArgs e)
        {

        }

        private void pluggin_Tapped(object sender, EventArgs e)
        {

        }
        private void vmapp_Tapped(object sender, EventArgs e)
        {

        }

        private void accessAreas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (accessAreas.SelectedItems.Count == 0) {
                c_have_zone.Text = "无";
                c_zone.IsVisible = false;
                return;
            }
            c_have_zone.Text = "选择区域";
            StringBuilder sb = new StringBuilder();
            foreach (var area in accessAreas.SelectedItems) { sb.Append(area.ToString()); sb.Append(" "); }
            c_zone.Text = sb.ToString();
        }

        private void port_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach(var port in port.SelectedItems) { sb.Append(port.ToString() + " "); }
            c_ports.Text = sb.ToString();
        }

        private void net_port_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public static event EventHandler vnetChanged;
        private void vnetworks_SelectedIndexChanged(object sender, EventArgs e)
        {
            c_vnet.Text = vnetworks.SelectedItem.ToString();
            vnetChanged?.Invoke(sender, EventArgs.Empty);
        }

        public static event EventHandler subnetChanged;
        private void subnet_SelectedIndexChanged(object sender, EventArgs e)
        {
            c_subnet.Text = subnet.SelectedItem.ToString();
            subnetChanged?.Invoke(sender, EventArgs.Empty);
        }

        public static event EventHandler publicIPChanged;
        private void publicIPs_SelectedIndexChanged(object sender, EventArgs e)
        {
            c_pubIP.Text = publicIPs.SelectedItem.ToString();
            publicIPChanged?.Invoke(sender, EventArgs.Empty);
        }

        public static event EventHandler DeleteOptionChanged;
        private void CascadDeleteNic_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            DeleteOptionChanged?.Invoke(sender, EventArgs.Empty);
        }

        private void view_clicked(object sender, EventArgs eventArgs)
        {
            CurrentPage = Create;
        }

    }
}