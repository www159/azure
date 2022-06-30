using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

using azure_m.defined_exceptions;

namespace azure_m.Views.VMDetails
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Basic : ContentView
    {
        public Basic()
        {
            InitializeComponent();
        }

        private void valid_SelectedIndexChanged(object sender, EventArgs e)
        {
            pswdFrame.IsVisible = !pswdFrame.IsVisible;
            sshFrame.IsVisible = !sshFrame.IsVisible;
        }

        public event EventHandler<string> UserName_TextChange;
        public event EventHandler<string> passwd2_TextChange;
        public event EventHandler<string> passwd_TextChange;
        private void UserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            //不为空，长度在1-64，包含字母数字连字符下划线，不能以连字符或数字开头
            if (UserName.Text.Length < 1 || UserName.Text.Length > 64/*||!regex.Match(UserName.Text,fmt)*/)
            {
                Task.Run(() => { }) ;
            }
        }

        private void passwd2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void passwd_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}