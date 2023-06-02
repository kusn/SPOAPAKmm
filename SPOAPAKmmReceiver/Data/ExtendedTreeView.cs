using System.Windows;
using System.Windows.Controls;

namespace SPOAPAKmmReceiver.Data
{
    public class ExtendedTreeView : TreeView
    {
        public static readonly DependencyProperty SelectedItem_Property = DependencyProperty.Register("SelectedItem_",
            typeof(object), typeof(ExtendedTreeView), new UIPropertyMetadata(null));

        public ExtendedTreeView()
        {
            SelectedItemChanged += ___ICH;
        }

        public object SelectedItem_
        {
            get => GetValue(SelectedItem_Property);
            set => SetValue(SelectedItem_Property, value);
        }

        private void ___ICH(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (SelectedItem != null)
                SetValue(SelectedItem_Property, SelectedItem);
        }
    }
}