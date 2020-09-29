using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace WAppClient.Views.ValueConverters
{
    public class ForecastTextConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var result = false;
            if (values == null ||
                !targetType.IsAssignableFrom(typeof(bool)) ||
                (values.Count() == 0) ||
                (values.Count() == 1 && values[0] == null) ||
                (values.Count() == 2 && values[0] == null && values[1] == null)
                )
            {
                result = false;
                // Alternatively, return BindableProperty.UnsetValue to use the binding FallbackValue
            }
            else
            {
                Dictionary<string, bool> expandedItems = values[0] as Dictionary<string, bool>;
                string name = values[1] as string;

                if (!string.IsNullOrEmpty(name) && expandedItems != null && expandedItems.ContainsKey(name))
                    result = expandedItems[name];    
            }

            return result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
