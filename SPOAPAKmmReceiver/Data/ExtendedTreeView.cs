﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SPOAPAKmmReceiver.Data
{
    public class ExtendedTreeView : TreeView
    {
        public ExtendedTreeView() : base()
        {
            this.SelectedItemChanged += new RoutedPropertyChangedEventHandler<object>(___ICH);
        }

        private void ___ICH(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (SelectedItem != null)
                SetValue(SelectedItem_Property, SelectedItem);
        }

        public object SelectedItem_
        {
            get => (object)GetValue(SelectedItem_Property);
            set => SetValue(SelectedItem_Property, value);
        }

        public static readonly DependencyProperty SelectedItem_Property = DependencyProperty.Register("SelectedItem_", typeof(object), typeof(ExtendedTreeView), new UIPropertyMetadata(null));
    }
}