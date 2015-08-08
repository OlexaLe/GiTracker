using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GiTracker.Models;
using GiTracker.Services.Rest;

namespace GiTracker.Services.Api
{
    class GitHubApiService : IGitApiService
    {
        const string _hostName = "https://api.github.com/";
        const string _userAgent = "XamarinGarage";

        readonly IRestService _restService;

        public GitHubApiService(IRestService restService)
        {
            _restService = restService;
        }

        public async Task<IEnumerable<IIssue>> GetIssuesAsync(CancellationToken cancellationToken)
        {
            var issues = await _restService.GetAsync<IEnumerable<GitHubIssue>>(
                // TODO: just an example
                new RequestSettings(_hostName, "repos/XamarinGarage/GiTracker/issues") { UserAgent = _userAgent }, cancellationToken)
                .ConfigureAwait(false);

            return issues.Cast<IIssue>();
        }
    }
}
