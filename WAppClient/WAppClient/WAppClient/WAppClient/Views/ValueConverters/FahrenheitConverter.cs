using System;
using System.Globalization;
using Xamarin.Forms;

namespace WAppClient.Views.ValueConverters
{
    public class FahrenheitConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            value += "f";
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
