using azure_m.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;


namespace azure_m.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(async (object obj) => await OnLoginClicked(obj));
        }

        private async Task OnLoginClicked(object obj)
        {
           
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            //await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }
    }
}
