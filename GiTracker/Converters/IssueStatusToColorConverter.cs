using System;
using System.Globalization;
using GiTracker.Models;
using Xamarin.Forms;

namespace GiTracker.Converters
{
    public class IssueStatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return Color.Gray;

            switch ((IssueStatus) value)
            {
                case IssueStatus.Open:
                    return Color.Green;
                case IssueStatus.Closed:
                    return Color.Red;
                default:
                    return Color.Gray;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}