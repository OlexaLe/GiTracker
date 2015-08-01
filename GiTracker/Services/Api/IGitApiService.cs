using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GiTracker.Models;

namespace GiTracker.Services.Api
{
    interface IGitApiService
    {
        Task<IEnumerable<GitHubIssue>> GetIssuesAsync(CancellationToken cancellationToken);
    }
}
