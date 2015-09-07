using System;
using System.Threading;
using System.Threading.Tasks;

namespace GiTracker.Services.WorkLog
{
    public interface IWorkLogService
    {
        Task LogTimeAsync(string repo, int issueId, DateTime logDate, TimeSpan logTime,
            CancellationToken cancellationToken);
    }
}