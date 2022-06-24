using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using azure_m.ViewModels;

namespace azure_m.Views
{
    public partial class AllResourcesPage : ContentPage
    {

        ResourceViewModel resourceViewModel;

        //public pDis = 

        public AllResourcesPage()
        {
            InitializeComponent();
            BindingContext = resourceViewModel = new ResourceViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            resourceViewModel.OnAppearing();

        }
    }   
}