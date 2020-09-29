using System;
using System.Globalization;
using Xamarin.Forms;

namespace WAppClient.Views.ValueConverters
{
    public class InverterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool returnValue = false;

            if (value is bool)
                returnValue = !(bool)value;

            return returnValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
