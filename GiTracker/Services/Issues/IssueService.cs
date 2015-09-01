using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GiTracker.Models;
using GiTracker.Services.Api;
using GiTracker.Services.Rest;

namespace GiTracker.Services.Issues
{
    internal class IssueService : IIssueService
    {
        private readonly IGitApiProvider _gitApiProvider;
        private readonly IRestService _restService;

        public IssueService(IRestService restService, IGitApiProvider gitApiProvider)
        {
            _restService = restService;
            _gitApiProvider = gitApiProvider;
        }

        public async Task<IEnumerable<IIssue>> GetIssuesAsync(string repository, CancellationToken cancellationToken)
        {
            var issues =
                await
                    _restService.GetAsync(_gitApiProvider.Host, _gitApiProvider.GetIssuesUrl(repository),
                        new Dictionary<string, string> {{"state", "all"}},
                        _gitApiProvider.IssueListType, cancellationToken)
                        .ConfigureAwait(false);

            return issues as IEnumerable<IIssue>;
        }
    }
}