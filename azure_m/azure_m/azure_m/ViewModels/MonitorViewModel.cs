﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace azure_m.ViewModels
{
	public class MonitorViewModel : ContentView
{
    public MonitorViewModel()
    {
        Content = new StackLayout
        {
            Children = {
                    new Label { Text = "Welcome to Xamarin.Forms!" }
                }
        };
    }
}
}