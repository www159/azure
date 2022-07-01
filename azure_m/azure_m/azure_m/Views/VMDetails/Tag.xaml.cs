using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace azure_m.Views.VMDetails
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tag : ContentView
    {
        public Tag()
        {
            InitializeComponent();
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