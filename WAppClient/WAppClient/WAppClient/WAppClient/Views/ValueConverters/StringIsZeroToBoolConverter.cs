using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace WAppClient.Views.ValueConverters
{
    public class StringIsZeroToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool result = false;
            try
            {
                var s = value.ToString();
                result = !s.Equals("0");
            }
            catch { }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Debug.WriteLine("StringIsEmptyToBool.ConvertBack");
            return value;
        }
    }
}
