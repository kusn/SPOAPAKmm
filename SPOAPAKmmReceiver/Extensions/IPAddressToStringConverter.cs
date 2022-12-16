using System;
using System.Globalization;
using System.Net;
using System.Windows.Data;
using System.Windows.Markup;

namespace SPOAPAKmmReceiver.Extensions
{
    [ValueConversion(typeof(IPAddress), typeof(string))]
    public class IPAddressToStringConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return IPAddress.Parse(value.ToString());
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}