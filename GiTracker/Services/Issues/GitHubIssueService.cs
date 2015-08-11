using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GiTracker.Models;
using GiTracker.Services.Api;
using GiTracker.Services.Rest;

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

            return issues;
        }
    }
}
