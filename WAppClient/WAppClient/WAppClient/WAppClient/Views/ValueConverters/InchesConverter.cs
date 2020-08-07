using System;
using System.Globalization;
using Xamarin.Forms;

namespace WAppClient.Views.ValueConverters
{
    public class InchesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            value += "in";
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
