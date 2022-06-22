using System;
using System.Collections.Generic;
using System.ComponentModel;
using testJ.Models;
using testJ.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testJ.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}