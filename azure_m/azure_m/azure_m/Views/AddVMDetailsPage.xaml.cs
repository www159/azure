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

        private void UserName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void passwd_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void passwd2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void resourcesGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public static event EventHandler<int> SubscribeIndexChange;
        private void subscribe_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubscribeIndexChange?.Invoke(sender, subscribe.SelectedIndex);
        }
    }
}