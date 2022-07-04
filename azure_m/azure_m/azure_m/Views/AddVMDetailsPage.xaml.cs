using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace azure_m.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddVmDetailsPage : CarouselPage
    {
        public AddVmDetailsPage()
        {
            InitializeComponent();
        }

        private void valid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(valid.SelectedIndex == 0) { sshFrame.IsVisible = true; pswdFrame.IsVisible = false; }
            else { sshFrame.IsVisible = false; pswdFrame.IsVisible = true; }
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
        }

        public static event EventHandler<int> SubscribeIndexChange;
        private void subscribe_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubscribeIndexChange?.Invoke(sender, subscribe.SelectedIndex);
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

        public static event EventHandler nicChanged;
        private void nic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (vnetworks.SelectedIndex != -1 && subnet.SelectedIndex != -1 && publicIPs.SelectedIndex != -1) { nicChanged?.Invoke(sender, EventArgs.Empty); }
        }

        private void delete_Clicked(object sender, EventArgs e)
        {
            allStack.Children.RemoveAt(1);

        }

        private void delete2_Clicked(object sender, EventArgs e)
        {

        }
    }
}