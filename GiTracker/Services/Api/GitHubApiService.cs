using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GiTracker.Models;

namespace GiTracker.Services.Api
{
    class GitHubApiService : IGitApiService
    {
        public Task<IEnumerable<GitHubIssue>> GetIssuesAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
