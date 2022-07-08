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
            InitializeComponent();
            BindingContext = new VMDetailViewModel();
            vnlbl.Text = (BindingContext as VMDetailViewModel)?.RGName + "-vnet/default";
        }
    }
}