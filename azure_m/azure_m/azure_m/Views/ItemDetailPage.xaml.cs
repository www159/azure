using azure_m.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace azure_m.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}