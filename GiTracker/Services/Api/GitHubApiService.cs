using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GiTracker.Models;

namespace GiTracker.Services.Api
{
    class GitHubApiService : IGitApiService
    {
        public async Task<IEnumerable<IIssue>> GetIssuesAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(3000);

            return new List<GitHubIssue> { 
                new GitHubIssue
                {
                    Id = 1,
                    Number = 27,
                    Title="Issue 27",
                    Body="Issue 27 body",
                },
                new GitHubIssue
                {
                    Id = 2,
                    Number = 28,
                    Title="Issue 28",
                    Body="Issue 28 body",
                },
            }.Cast<IIssue>();
        }
    }
}
