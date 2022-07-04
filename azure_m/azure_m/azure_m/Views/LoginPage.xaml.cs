using azure_m.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using azure_m.Services;
using Xamarin.Forms.StyleSheets;

namespace azure_m.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();           
        }

        public event EventHandler LoginComplete;

        private async void Btn_Clicked(object sender,EventArgs e)
        {
            try
            {
                await QueryInfo.getTokenAsync();
                LoginComplete?.Invoke(this, EventArgs.Empty);
            }
            catch(Exception ex)
            {
                Utils.error(ex);
            }
        }
        
        public event EventHandler<string> LoginCompleted;

        private void Button_Clicked(object sender, EventArgs e)
        {
            var loginCompleted = LoginCompleted;
            if(loginCompleted != null)
            {
                loginCompleted(this, "funck");
            }
        }
    }
}