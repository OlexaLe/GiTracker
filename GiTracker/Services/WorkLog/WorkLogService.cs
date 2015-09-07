using System;
using System.Threading;
using System.Threading.Tasks;
using GiTracker.Services.Api;
using GiTracker.Services.Rest;

namespace GiTracker.Services.WorkLog
{
    internal class WorkLogService : IWorkLogService
    {
        private readonly IGitApiProvider _gitApiProvider;
        private readonly IRestService _restService;

        public WorkLogService(IRestService restService, IGitApiProvider gitApiProvider)
        {
            _restService = restService;
            _gitApiProvider = gitApiProvider;
        }

        public async Task LogTimeAsync(string repo, int issueId, DateTime logDate, TimeSpan logTime,
            CancellationToken cancellationToken)
        {
            var issues =
                await
                    _restService.GetAsync(_gitApiProvider.CreateCommentRequest(repo, issueId), cancellationToken)
                        .ConfigureAwait(false);
        }
    }
}