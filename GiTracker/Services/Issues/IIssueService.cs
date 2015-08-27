using GiTracker.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GiTracker.Services.Issues
{
    public interface IIssueService
    {
        Task<IEnumerable<IIssue>> GetIssuesAsync(CancellationToken cancellationToken, string repository, IssueStatus? statusFilter = null);
    }
}
