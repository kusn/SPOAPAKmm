using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using SPOAPAKmmReceiver.Entities.Base;

namespace WpfAppTest
{
    public class CustomTreeView : TreeView
    {
        public Entity SelectedCustomThing
        {
            get
            {
                return (Entity)GetValue(SelectedNode_Property);
            }
            set
            {
                SetValue(SelectedNode_Property, value);
                if (value != null) value.IsSelected = true;
            }
        }

        public static DependencyProperty SelectedNode_Property =
            DependencyProperty.Register(
                "SelectedCustomThing",
                typeof(Entity),
                typeof(CustomTreeView),
                new FrameworkPropertyMetadata(
                    null,
                    FrameworkPropertyMetadataOptions.None,
                    SelectedNodeChanged));

        public CustomTreeView() : base()
        {
            this.SelectedItemChanged += new RoutedPropertyChangedEventHandler<object>(SelectedItemChanged_CustomHandler);
        }

        void SelectedItemChanged_CustomHandler(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            SetValue(SelectedNode_Property, SelectedItem);
        }

        private static void SelectedNodeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var treeView = d as CustomTreeView;
            var newNode = e.NewValue as Entity;

            treeView.SelectedCustomThing = (Entity)e.NewValue;
        }
    }
}
