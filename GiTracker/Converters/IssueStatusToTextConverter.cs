using System;
using System.Globalization;
using System.Resources;
using GiTracker.Models;
using GiTracker.Resources.Strings;
using Xamarin.Forms;

namespace GiTracker.Converters
{
    internal class IssueStatusToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return IssueDetails.Unknown;

            return
                new ResourceManager(typeof (IssueDetails)).GetString(
                    $"{typeof (IssueStatus).Name}_{value}");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}