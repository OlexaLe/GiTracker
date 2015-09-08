using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GiTracker.Services.WorkLog
{
    public interface IWorkLogService
    {
        Task<WorkLogItem> LogTimeAsync(string repo, int issueId, DateTime logDate, TimeSpan logTime,
            CancellationToken cancellationToken);

        Task<IEnumerable<WorkLogItem>> GetLogsAsync(string repo, int issueId, CancellationToken cancellationToken);
    }
}