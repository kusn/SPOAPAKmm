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
using System.Windows.Shapes;

namespace SPOAPAKmmReceiver.Views
{
    /// <summary>
    /// Логика взаимодействия для DevicesWindow.xaml
    /// </summary>
    public partial class DevicesWindow : Window
    {
        bool? _result;

        public DevicesWindow()
        {
            InitializeComponent();            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.DialogResult = true;            
        }
    }
}