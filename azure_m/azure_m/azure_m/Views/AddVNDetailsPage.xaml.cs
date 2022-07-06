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
    public partial class AddVNDetailsPage : CarouselPage
    {
        public AddVNDetailsPage()
        {
            InitializeComponent();
        }

        public static event EventHandler<int> SubscribeIndexChange;
        private void subscribe_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubscribeIndexChange?.Invoke(sender, subscribe.SelectedIndex);
            c_subscribeName.Text = subscribe.SelectedItem.ToString();
        }

        public static event EventHandler ResourceGroupIndexChanged;
        private void resourcesGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResourceGroupIndexChanged?.Invoke(sender, EventArgs.Empty);
            c_resGroup.Text = resourcesGroup.SelectedItem.ToString();
        }

        public static event EventHandler AreaChanged;
        private void areas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (areas.SelectedIndex != -1) { AreaChanged?.Invoke(sender, EventArgs.Empty); }
            c_areas.Text = areas.SelectedItem.ToString();
        }

    }
}