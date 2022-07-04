using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace azure_m.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogViewPage : ContentPage
    {
        //public List<azure_m.ViewModels.Sourse> Sourses { get; set; }
        public LogViewPage()
        {
            InitializeComponent();
        }
        //public void Resource()
        //{
        //    Sourses = new List<Sourse>()
        //    {
        //       new Sourse{Name="Vm",SourseType="虚拟机"},
        //       new Sourse{Name="Disk",SourseType="磁盘"},
        //    };
        //    var stackLayout = new StackLayout
        //    {
        //        Margin = new Thickness(0, 140, 0, 0),
        //        BackgroundColor = Color.Red,
        //        VerticalOptions = LayoutOptions.Start,
        //        HorizontalOptions = LayoutOptions.Start,                
        //    };
        //    StaticGrid.Children.Add(stackLayout);
        //    Sourses.ForEach(o =>
        //    {              
        //        var radioBtn = new RadioButton { GroupName = "Same", };
        //        // grid = new Grid();
        //        var RadioGrid = new Grid();
        //        var label = new Label { Text = o.Name, Margin = new Thickness(20, 0, 0, 0) };
        //        var TypeLabel = new Label { Text = o.SourseType, Margin = new Thickness(200, 0, 0, 0) };
        //        //stackLayout.Children.Add(grid);
        //        //grid.Children.Add(radioBtn);
        //        radioBtn.Content = RadioGrid;
        //        RadioGrid.Children.Add(label);
        //        RadioGrid.Children.Add(TypeLabel);
        //        var button = new Button();
        //    });
        //}

        private void Button_Clicked(object sender, EventArgs e)
        {
            ChooseTarget.IsVisible=!ChooseTarget.IsVisible;
        }



        //private void TMP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    tmp3.Text = (TMP.SelectedItem as azure_m.ViewModels.Sourse).SourseType;
            
        //}
    }
}