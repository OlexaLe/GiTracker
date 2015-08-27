using System;
using System.Globalization;
using GiTracker.Models;
using Xamarin.Forms;

namespace GiTracker.Converters
{
    internal class IssueStatusToIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return "Octicon_IssueOpened.png";

            switch ((IssueStatus) value)
            {
                case IssueStatus.Open:
                    return "Octicon_IssueOpened.png";
                case IssueStatus.Closed:
                    return "Octicon_IssueClosed.png";
                default:
                    return "Octicon_IssueOpened.png";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}