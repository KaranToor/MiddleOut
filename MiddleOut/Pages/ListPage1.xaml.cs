﻿using FirstFloor.ModernUI.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MiddleOut
{
    /// <summary>
    /// Interaction logic for ListPage1.xaml
    /// </summary>
    public partial class ListPage1 : UserControl
    {
        public ListPage1()
        {
            InitializeComponent();
            ListPageHome.Height = MaxHeight - MaxHeight /10;
            ListPageHome.Width = MaxWidth - MaxWidth / 10;

        }
    }
}
