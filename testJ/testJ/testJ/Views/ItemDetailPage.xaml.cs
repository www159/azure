using System.ComponentModel;
using testJ.ViewModels;
using Xamarin.Forms;

namespace testJ.Views
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