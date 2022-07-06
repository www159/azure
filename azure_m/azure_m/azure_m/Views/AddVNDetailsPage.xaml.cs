using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace azure_m.Views
{
    using ViewModels;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddVNDetailsPage : CarouselPage
    {
        private VNDetailsViewModel viewModel;
        public AddVNDetailsPage()
        {
            BindingContext = viewModel = new VNDetailsViewModel();
            InitializeComponent();

            // viewModel
        }

    }
}