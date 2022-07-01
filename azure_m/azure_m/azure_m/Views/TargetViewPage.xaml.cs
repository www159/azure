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
        int i = 0;
        public TargetViewPage()
        {
            InitializeComponent();
            //this.BindingContext = new TargetViewModel();
            //SfChart chart = new SfChart 
            //{ VerticalOptions=LayoutOptions.Start,
            //  Margin = new Thickness(0,180,0,0)
            //};
            //chart.Title.Text = "Chart";

            ////Initializing primary axis
            //CategoryAxis primaryAxis = new CategoryAxis();
            //primaryAxis.Title.Text = "Name";
            //chart.PrimaryAxis = primaryAxis;

            ////Initializing secondary Axis
            //NumericalAxis secondaryAxis = new NumericalAxis();
            //secondaryAxis.Title.Text = "Height (in cm)";
            //chart.SecondaryAxis = secondaryAxis;

            ////Initializing column series
            //ColumnSeries series = new ColumnSeries();
            //series.SetBinding(ChartSeries.ItemsSourceProperty, "Data");
            //series.XBindingPath = "TimeStamp";
            //series.YBindingPath = "Average";
            //series.Label = "MiB";

            //series.DataMarker = new ChartDataMarker();
            //series.EnableTooltip = true;

            //LineSeries Lseries = new LineSeries();
            //Lseries.SetBinding(ChartSeries.ItemsSourceProperty, "Data");
            //Lseries.XBindingPath = "TimeStamp";
            //Lseries.YBindingPath = "Average";
            //Lseries.Label = "MiB";

            //Lseries.DataMarker = new ChartDataMarker();
            //Lseries.EnableTooltip = true;

            //Chart.Series.Add(series);             
            //grid.Children.Add(chart);
        }

        private void ChooseTargetClicked(object sender, EventArgs e)
        {
            ChooseTarget.IsVisible= !ChooseTarget.IsVisible;
        }

        private void ApplyTargetClicked(object sender, EventArgs e)
        {
            ChooseTarget.IsVisible = false;
        }

        private void CancelTargetClicked(object sender, EventArgs e)
        {
            ChooseTarget.IsVisible = false;
        }
       
        
        

        //创建新图表事件
        //public void CreateNewChat(object obj,EventArgs e)
        //{
        //    var layout = new StackLayout();
        //    MainLayout.Children.Add(layout);
        //    var entry = new Entry 
        //    { Placeholder = "图表标题",
        //      FontSize=30
        //    };
        //    layout.Children.Add(entry);
        //    var grid = new Grid();
        //    layout.Children.Add(grid);
        //    var scrollview = new ScrollView
        //    {
        //        Orientation = ScrollOrientation.Horizontal,
        //        VerticalOptions = LayoutOptions.Start,
        //        HorizontalOptions=LayoutOptions.Start,
        //        HeightRequest=40
        //    };
        //    grid.Children.Add(scrollview);
        //    var layout2 = new StackLayout { Orientation = StackOrientation.Horizontal };
        //    scrollview.Content = layout2;
        //    //添加指标按钮（未写触发）
        //    var AddTargetbutton = new Button 
        //    {Text="添加指标", 
        //        TextColor=Color.White, 
        //        FontSize=17, 
        //        BackgroundColor= Test.BackgroundColor, 
        //        HorizontalOptions =LayoutOptions.Start, 
        //        VerticalOptions=LayoutOptions.Start,
        //        HeightRequest=40,
        //        Padding=new Thickness(0,6),                
        //    };
        //    layout2.Children.Add(AddTargetbutton);
        //    //
        //    var AddChoosebutton = new Button
        //    {
        //        Text = "添加筛选器",
        //        TextColor = Color.White,
        //        FontSize = 17,
        //        BackgroundColor = Test.BackgroundColor,
        //        HorizontalOptions = LayoutOptions.Start,
        //        VerticalOptions = LayoutOptions.Start,
        //        HeightRequest = 40,
        //        Padding = new Thickness(0, 6),
        //    };
        //    layout2.Children.Add(AddChoosebutton);
        //    //
        //    var Applybutton = new Button
        //    {
        //        Text = "应用拆分",
        //        TextColor = Color.White,
        //        FontSize = 17,
        //        BackgroundColor = Test.BackgroundColor,
        //        HorizontalOptions = LayoutOptions.Start,
        //        VerticalOptions = LayoutOptions.Start,
        //        HeightRequest = 40,
        //        Padding = new Thickness(0, 6),
        //    };
        //    layout2.Children.Add(Applybutton);
        //    //图表选择器（未写触发）
        //    var ChartList = new List<string>();
        //    ChartList.Add("折线图");
        //    ChartList.Add("分区图");
        //    ChartList.Add("条形图");
        //    ChartList.Add("散点图");
        //    ChartList.Add("网格");
        //    var Chartpicker = new Picker 
        //    { Title = "图表类型", 
        //        TitleColor = Color.White,
        //        TextColor = Color.White,
        //        FontSize=17,
        //        BackgroundColor=Test.BackgroundColor,
        //        HorizontalOptions = LayoutOptions.Start,
        //        VerticalOptions = LayoutOptions.Start,
        //        HeightRequest=40,                
        //    };
        //    Chartpicker.ItemsSource =ChartList;
        //    layout2.Children.Add(Chartpicker);
        //    //
        //    var CheckLogbutton = new Button
        //    {
        //        Text = "深入查看日志",
        //        TextColor = Color.White,
        //        FontSize = 17,
        //        BackgroundColor = Test.BackgroundColor,
        //        HorizontalOptions = LayoutOptions.Start,
        //        VerticalOptions = LayoutOptions.Start,
        //        HeightRequest = 40,
        //        Padding = new Thickness(0, 6),
        //    };
        //    layout2.Children.Add(CheckLogbutton);
        //    //
        //    var Warnbutton = new Button
        //    {
        //        Text = "新建警报规则",
        //        TextColor = Color.White,
        //        FontSize = 17,
        //        BackgroundColor = Test.BackgroundColor,
        //        HorizontalOptions = LayoutOptions.Start,
        //        VerticalOptions = LayoutOptions.Start,
        //        HeightRequest = 40,
        //        Padding = new Thickness(0, 6),
        //    };
        //    layout2.Children.Add(Warnbutton);
        //    //保存选择器（未写触发）
        //    var SaveList = new List<string>();
        //    SaveList.Add("固定到仪表盘");
        //    SaveList.Add("固定到grafana");
        //    SaveList.Add("发送到工作簿");
        //    var Savepicker = new Picker
        //    {
        //        Title = "保存到仪表盘",
        //        TitleColor = Color.White,
        //        FontSize=17,
        //        BackgroundColor = Test.BackgroundColor,
        //        HorizontalOptions = LayoutOptions.Start,
        //        VerticalOptions = LayoutOptions.Start,
        //        HeightRequest = 40,
        //    };
        //    Savepicker.ItemsSource =SaveList;
        //    layout2.Children.Add(Savepicker);
        //    //更多Button（未写触发）
        //    var ImageBtn = new ImageButton 
        //    { Source= "more4.png",
        //      BackgroundColor=Test.BackgroundColor,
        //        HorizontalOptions = LayoutOptions.Start,
        //        VerticalOptions = LayoutOptions.Start,
        //        HeightRequest = 40,
        //        Padding=new Thickness(0,6),

        //    };
        //    layout2.Children.Add(ImageBtn);
        //    //图表显示区
        //    var Chartlabel = new Label
        //    {
        //        Text = "这是视图产生区域",
        //        BackgroundColor=Color.Green,
        //        HorizontalOptions = LayoutOptions.Start,
        //        VerticalOptions = LayoutOptions.Start,
        //        WidthRequest = 370,
        //        HeightRequest = 300,
        //        Margin = new Thickness(10, 50, 0, 0),
        //    };
        //    grid.Children.Add(Chartlabel);
        //}        
    }
}