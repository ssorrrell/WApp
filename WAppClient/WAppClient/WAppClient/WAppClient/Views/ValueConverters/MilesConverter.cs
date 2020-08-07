using System;
using System.Globalization;
using Xamarin.Forms;

namespace WAppClient.Views.ValueConverters
{
    public class MilesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            value += "mi";
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
