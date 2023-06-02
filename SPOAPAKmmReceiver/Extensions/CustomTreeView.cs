using System.Windows;
using System.Windows.Controls;
using SPOAPAKmmReceiver.Entities.Base;

namespace SPOAPAKmmReceiver.Extensions
{
    public class CustomTreeView : TreeView
    {
        public static DependencyProperty SelectedNode_Property =
            DependencyProperty.Register(
                "SelectedCustomThing",
                typeof(Entity),
                typeof(CustomTreeView),
                new FrameworkPropertyMetadata(
                    null,
                    FrameworkPropertyMetadataOptions.None,
                    SelectedNodeChanged));

        public CustomTreeView()
        {
            SelectedItemChanged += SelectedItemChanged_CustomHandler;
        }

        public Entity SelectedCustomThing
        {
            get => (Entity)GetValue(SelectedNode_Property);
            set
            {
                SetValue(SelectedNode_Property, value);
                if (value != null)
                {
                    value.IsSelected = true;
                    value.IsExpanded = true;
                }
            }
        }

        private void SelectedItemChanged_CustomHandler(object sender, RoutedPropertyChangedEventArgs<object> e)
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