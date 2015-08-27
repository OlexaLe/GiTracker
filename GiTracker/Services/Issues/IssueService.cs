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

        public async Task<IEnumerable<IIssue>> GetIssuesAsync(CancellationToken cancellationToken, string repository, IssueStatus? statusFilter = null)
        {
            var url = _gitApiProvider.GetIssuesUrl;
            if (statusFilter.HasValue)
                switch(statusFilter)
                {
                    case IssueStatus.Open:
                        url = _gitApiProvider.GetOpenIssuesUrl;
                        break;
                    case IssueStatus.Closed:
                        url = _gitApiProvider.GetClosedIssuesUrl;
                        break;
                }

            var issues = await _restService.GetAsync(_gitApiProvider.Host, string.Format(url, repository), _gitApiProvider.IssueListType, cancellationToken)
                .ConfigureAwait(false);

            return issues as IEnumerable<IIssue>;
        }
    }
}