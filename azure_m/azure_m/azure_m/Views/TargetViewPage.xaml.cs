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
    public partial class TargetViewPage : ContentPage
    {
        public TargetViewPage()
        {
            InitializeComponent();
            
        }
        //创建新图表事件
        public void CreateNewChat(object obj,EventArgs e)
        {
            var layout = new StackLayout();
            MainLayout.Children.Add(layout);
            var entry = new Entry 
            { Text = "图表标题",
              FontSize=30
            };
            layout.Children.Add(entry);
            var grid = new Grid();
            layout.Children.Add(grid);
            //添加指标按钮（未写触发）
            var AddTargetbutton = new Button 
            {Text="添加指标", 
                TextColor=Color.Black, 
                FontSize=17, 
                BackgroundColor=Color.White, 
                HorizontalOptions=LayoutOptions.Start, 
                VerticalOptions=LayoutOptions.Start,
                WidthRequest=80,HeightRequest=40,
                Margin=new Thickness(10,0,0,0),
                Padding=new Thickness(0,6),
                BorderColor=Color.Black,
                BorderWidth=1
            };
            grid.Children.Add(AddTargetbutton);
            //图表选择器（未写触发）
            var ChartList = new List<string>();
            ChartList.Add("折线图");
            ChartList.Add("分区图");
            ChartList.Add("条形图");
            ChartList.Add("散点图");
            ChartList.Add("网格");
            var Chartpicker = new Picker 
            { Title = "图表类型", 
                TitleColor = Color.Red,
                FontSize=17,
                BackgroundColor=Color.White,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start,
                WidthRequest=80,
                HeightRequest=40,
                Margin = new Thickness(120, 0, 0, 0)
            };
            Chartpicker.ItemsSource =ChartList;
            grid.Children.Add(Chartpicker);
            //保存选择器（未写触发）
            var SaveList = new List<string>();
            SaveList.Add("固定到仪表盘");
            SaveList.Add("固定到grafna");
            SaveList.Add("发送到工作簿");
            var Savepicker = new Picker
            {
                Title = "保存到仪表盘",
                TitleColor = Color.Red,
                FontSize=17,
                BackgroundColor = Color.White,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start,
                WidthRequest = 110,
                HeightRequest = 40,
                Margin= new Thickness(210,0,0,0)
            };
            Savepicker.ItemsSource =SaveList;
            grid.Children.Add(Savepicker);
            //更多Button（未写触发）
            var ImageBtn = new ImageButton 
            { Source= "more4.png",
              BackgroundColor= Color.White,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start,
                WidthRequest = 40,
                HeightRequest = 40,
                Margin=new Thickness(340,0,0,0),
                Padding=new Thickness(0,6),
                BorderColor = Color.Black,
                BorderWidth = 1
            };
            grid.Children.Add(ImageBtn);
            //图表显示区
            var Chartlabel = new Label
            {
                Text = "这是视图产生区域",
                BackgroundColor=Color.Green,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start,
                WidthRequest = 370,
                HeightRequest = 300,
                Margin = new Thickness(10, 50, 0, 0),
            };
            grid.Children.Add(Chartlabel);
        }        
    }
}