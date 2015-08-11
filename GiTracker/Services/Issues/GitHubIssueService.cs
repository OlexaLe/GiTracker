using GiTracker.Models;
using GiTracker.Services.ServiceProvider;
using GiTracker.Services.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GiTracker.Services.Issues
{
    class GitHubIssueService : IIssueService
    {
        readonly IRestService _restService;
        readonly IGitApiProvider _gitApiProvider = new GitHubApiProvider();

        public GitHubIssueService(IRestService restService)
        {
            _restService = restService;
        }

        public async Task<IEnumerable<IIssue>> GetIssuesAsync(CancellationToken cancellationToken)
        {
            var issues = await _restService.GetAsync<IEnumerable<GitHubIssue>>(
                _gitApiProvider.Host, _gitApiProvider.GetIssuesUrl, cancellationToken)
                .ConfigureAwait(false);

            return issues.Cast<IIssue>();
        }
    }
}
