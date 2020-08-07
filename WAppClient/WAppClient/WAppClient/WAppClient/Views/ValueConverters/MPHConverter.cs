using System;
using System.Globalization;
using Xamarin.Forms;

namespace WAppClient.Views.ValueConverters
{
    public class MPHConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            value += "mph";
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
