﻿using System.Collections.Specialized;
using System.Windows;
using System.Windows.Input;

namespace WpfAppTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ((INotifyCollectionChanged)chatList.Items).CollectionChanged
                += Messages_CollectionChanged;
        }

        private void Messages_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems == null)
                return;

            if (e.NewItems.Count > 0)
            {
                chatList.ScrollIntoView(chatList.Items[chatList.Items.Count - 1]);
            }
        }

        private void MessageBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var context = (MainViewModel)DataContext;
                context.SendCommand.Execute(null);
            }
        }
    }
}
