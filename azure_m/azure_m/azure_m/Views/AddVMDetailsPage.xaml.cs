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
    }
}