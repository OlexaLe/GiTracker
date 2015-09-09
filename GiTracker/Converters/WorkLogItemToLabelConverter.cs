using System;
using System.Globalization;
using GiTracker.Resources.Strings;
using GiTracker.Services.WorkLog;
using Xamarin.Forms;

namespace GiTracker.Converters
{
    internal class WorkLogItemToLabelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var workLog = value as WorkLogItem;
            if (workLog == null) return null;

            return string.Format(WorkLogs.Logged, workLog.Creator.Login,
                workLog.Time.ToString($@"h\{LogWork.Hours}\ mm\{LogWork.Minutes}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}