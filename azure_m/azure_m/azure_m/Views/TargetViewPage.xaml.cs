using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using azure_m.ViewModels;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace azure_m.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class TargetViewPage : ContentPage
    {

        int checkedIndex;

        List<bool> checks;

        StackLayout stackLayout;
        public TargetViewPage()
        {
            InitializeComponent();
            
            //Resource();
        }
        
        //public void Resource()
        //{
            
        //    stackLayout=new StackLayout 
        //    {
        //        Margin=new Thickness(0,140,0,0),
        //        BackgroundColor=Color.Red,
        //        VerticalOptions=LayoutOptions.Start,
        //        HorizontalOptions=LayoutOptions.Start,
        //        BindingContext=checks
        //    };
        //    StaticGrid.Children.Add(stackLayout);
        //    int index = 0;
        //    Sourses.ForEach(o =>
        //    {
        //        checks.Add(false);
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
        //    });
        //}


        private void ChooseTargetClicked(object sender, EventArgs e)
        {
            ChooseTarget.IsVisible = !ChooseTarget.IsVisible;
        }

        private void ApplyTargetClicked(object sender, EventArgs e)
        {     
            ChooseTarget.IsVisible = false;           
        }

        private void CancelTargetClicked(object sender, EventArgs e)
        {
            
            ChooseTarget.IsVisible = false;
        }
   

        private void Collection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChooseRange.Text = (Collection.SelectedItem as azure_m.ViewModels.Sourse).Name;
            ShowType.Text= (Collection.SelectedItem as azure_m.ViewModels.Sourse).SourseType;
            ChooseTarget.IsVisible = false;
            if(ShowType.Text=="虚拟机")
            {
                VirtualMachine.IsVisible = true;
            }
            if(ShowType.Text=="磁盘")
            {
                Disk.IsVisible= true;
            }
        }

        private void CcrClicked(object sender, EventArgs e)
        {
            VirtualMachine.IsVisible= false;
            CcrChart.IsVisible = true;
            CccChart.IsVisible = false;
            AmbChart.IsVisible = false;
        }

        private void CccClicked(object sender, EventArgs e)
        {
            VirtualMachine.IsVisible = false;
            CccChart.IsVisible = true;
            CcrChart.IsVisible = false;
            AmbChart.IsVisible = false;
        }

        private void AmbClicked(object sender, EventArgs e)
        {
            VirtualMachine.IsVisible = false;
            AmbChart.IsVisible = true;
            CccChart.IsVisible=false;
            CcrChart.IsVisible=false;
        }

        private void ValueChooseClicked(object sender,EventArgs e)
        {
            if (ShowType.Text == "虚拟机")
            {
                VirtualMachine.IsVisible = true;
            }
            if (ShowType.Text == "磁盘")
            {
                Disk.IsVisible = true;
            }
        }
    }
}