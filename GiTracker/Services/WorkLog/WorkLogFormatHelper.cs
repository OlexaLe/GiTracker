using System;
using System.Text.RegularExpressions;
using GiTracker.Models;

namespace GiTracker.Services.WorkLog
{
    public static class WorkLogFormatHelper
    {
        private static string LogWorkFormat { get; } = "{0}h {1}m logged on {2}/{3}/{4} via #GiTracker";
        private static Regex LogWorkFormatRegEx { get; } = new Regex(@"\d+h \d+m logged on \d+/\d+/\d+ via #GiTracker");
        private static Regex HoursRegEx { get; } = new Regex(@"\d+(?=h)");
        private static Regex MinutesRegEx { get; } = new Regex(@"\d+(?=m)");
        private static Regex DayRegEx { get; } = new Regex(@"(?<= )\d+(?=/)");
        private static Regex MonthRegEx { get; } = new Regex(@"(?<=/)\d+(?=/)");
        private static Regex YearRegEx { get; } = new Regex(@"(?<=/)\d+(?= )");

        public static string GetCommentBody(DateTime logDate, TimeSpan logTime)
            => string.Format(LogWorkFormat, logTime.Hours, logTime.Minutes, logDate.Day, logDate.Month, logDate.Year);

        public static bool IsWorkLog(IComment comment) => LogWorkFormatRegEx.IsMatch(comment.Body);

        public static WorkLogItem ExtractWorkLogItem(IComment comment)
        {
            var hours = int.Parse(HoursRegEx.Match(comment.Body).Value);
            var minutes = int.Parse(MinutesRegEx.Match(comment.Body).Value);
            var day = int.Parse(DayRegEx.Match(comment.Body).Value);
            var month = int.Parse(MonthRegEx.Match(comment.Body).Value);
            var year = int.Parse(YearRegEx.Match(comment.Body).Value);

            return new WorkLogItem
            {
                Date = new DateTime(year, month, day),
                Time = new TimeSpan(0, hours, minutes, 0),
                Creator = comment.Author
            };
        }
    }
}