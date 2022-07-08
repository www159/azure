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
    public partial class VMDetailPage : ContentPage
    {

        private VMDetailViewModel viewModel;
        public VMDetailPage()
        {
            BindingContext = viewModel = new VMDetailViewModel();
            InitializeComponent();
            //vnlbl.Text = (viewModel)?.RGName + "-vnet/default";
        }
    }
}