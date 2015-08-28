using System;
using System.Globalization;
using GiTracker.Models;
using Xamarin.Forms;

namespace GiTracker.Converters
{
    internal class IssueStatusToWhiteIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return "Octicon_Issue_Unknown_White.png";

            switch ((IssueStatus) value)
            {
                case IssueStatus.OpenPullRequest:
                case IssueStatus.ClosedPullRequest:
                    return "Octicon_PullRequest_White.png";
                case IssueStatus.Closed:
                    return "Octicon_Issue_Closed_White.png";
                case IssueStatus.Open:
                    return "Octicon_Issue_Open_White.png";
                default:
                    return "Octicon_Issue_Unknown_White.png";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}