using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Markup;
using SPOAPAKmmReceiver.Entities;

namespace SPOAPAKmmReceiver.Extensions
{
    [ValueConversion(typeof(ObservableCollection<Organization>), typeof(ObservableCollection<Organization>))]
    public class SortConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((ObservableCollection<Organization>)value).OrderBy(o => o.Name);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((ObservableCollection<Organization>)value).OrderBy(o => o.Name);
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}