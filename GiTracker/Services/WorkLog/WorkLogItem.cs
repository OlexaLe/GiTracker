using System;
using GiTracker.Models;

namespace GiTracker.Services.WorkLog
{
    public class WorkLogItem
    {
        public IUser Creator { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
    }
}