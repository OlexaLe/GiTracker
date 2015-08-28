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
            if (parameter == null || (!"White".Equals(parameter.ToString()) && !"Colored".Equals(parameter.ToString())))
                parameter = "Colored";

            if (value == null) return $"Octicon_Issue_Unknown_{parameter}.png";

            switch ((IssueStatus) value)
            {
                case IssueStatus.OpenPullRequest:
                case IssueStatus.ClosedPullRequest:
                    return $"Octicon_PullRequest_{parameter}.png";
                case IssueStatus.Closed:
                    return $"Octicon_Issue_Closed_{parameter}.png";
                case IssueStatus.Open:
                    return $"Octicon_Issue_Open_{parameter}.png";
                default:
                    return $"Octicon_Issue_Unknown_{parameter}.png";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}