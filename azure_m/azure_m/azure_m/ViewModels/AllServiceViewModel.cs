using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
namespace azure_m.ViewModels
{
    public class AllServiceViewModel : BaseViewModel
    {
        public AllServiceViewModel(bool isClicked)
        {
            IsClicked = isClicked;
        }
        public bool IsClicked { get; set; }
    }
}