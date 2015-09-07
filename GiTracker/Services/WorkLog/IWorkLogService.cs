using System;
using System.Threading;
using System.Threading.Tasks;
using GiTracker.Models;

namespace GiTracker.Services.WorkLog
{
    public interface IWorkLogService
    {
        Task<IComment> LogTimeAsync(string repo, int issueId, DateTime logDate, TimeSpan logTime,
            CancellationToken cancellationToken);
    }
}