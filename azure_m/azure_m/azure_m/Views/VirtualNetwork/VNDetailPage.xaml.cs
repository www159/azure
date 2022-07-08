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
    public partial class VNDetailPage : ContentPage
    {
        private VNDetailViewModel viewModel;

        public VNDetailPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new VNDetailViewModel();

        }
    }
}