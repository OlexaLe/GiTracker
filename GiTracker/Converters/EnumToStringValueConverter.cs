using System;
using System.Globalization;
using System.Resources;
using GiTracker.Resources.Strings;
using Xamarin.Forms;

namespace GiTracker.Converters
{
    public class EnumToStringValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null ? new ResourceManager(typeof (Enums)).GetString(value.ToString()) : Enums.Unknown;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}