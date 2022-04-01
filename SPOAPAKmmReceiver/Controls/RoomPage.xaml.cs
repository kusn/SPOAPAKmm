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
using SPOAPAKmmReceiver.ViewModels;

namespace SPOAPAKmmReceiver.Controls
{
    /// <summary>
    /// Логика взаимодействия для RoomPage.xaml
    /// </summary>
    public partial class RoomPage : Page
    {
        public string Name_ { get; set; }
        public string? Description { get; set; }

        public RoomPage(MainWindowViewModel vm)
        {
            InitializeComponent();

            Name_ = vm.SelectedRoom.Name;
            Description = vm.SelectedRoom.Description;
        }
    }
}
