﻿using System;
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

namespace MiddleOut.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();

        }
        /// <summary>
        /// Interaction logic for Home.xaml
        /// @Author: Charlton Smith
        /// Whenever the user comes to page, reload.
        /// </summary>
        private void Image_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            User user = mainWindow.getUser();
            userInfo.Text = "Hello, " + user.getName();
            Console.WriteLine(user.getServices().Count);
            services.Text = "You have " + user.getServices().Count + " service(s).\n";
            for (int i = 0; i < user.getServices().Count; i++)
            {
                Console.WriteLine(user.getServices()[i].ToString());
                services.Text += user.getServices()[i].ToString();
            }
        }
    }
}
