using SPOAPAKmmReceiver.Entities;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Markup;

namespace SPOAPAKmmReceiver.Extensions
{
    [ValueConversion(typeof(ObservableCollection<Organization>), typeof(ObservableCollection<Organization>))]
    public class SortConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((ObservableCollection<Organization>)value).OrderBy(o => o.Name);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((ObservableCollection<Organization>)value).OrderBy(o => o.Name);
        }
    }
}
