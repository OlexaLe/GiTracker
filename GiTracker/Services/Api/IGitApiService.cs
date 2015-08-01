using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GiTracker.Models;

namespace GiTracker.Services.Api
{
    public interface IGitApiService
    {
        Task<IEnumerable<GitHubIssue>> GetIssuesAsync(CancellationToken cancellationToken);
    }
}
