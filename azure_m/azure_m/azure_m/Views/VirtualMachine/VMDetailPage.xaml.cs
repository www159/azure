using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace azure_m.Views
{
    using azure_m.ViewModels;
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VMDetailPage : ContentPage
    {
        public VMDetailPage()
        {
            BindingContext = new VMDetailViewModel();
            InitializeComponent();
            vnlbl.Text = (BindingContext as VMDetailViewModel)?.RGName + "-vnet/default";
        }
    }
}