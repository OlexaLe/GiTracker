using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GiTracker.Models;
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

        public async Task<IComment> LogTimeAsync(string repo, int issueId, DateTime logDate, TimeSpan logTime,
            CancellationToken cancellationToken)
        {
            var request = _gitApiProvider.CreateCommentRequest(repo, issueId);
            var bodyString = string.Format(Constants.LogWorkFormat, logTime.Hours, logTime.Minutes, logDate.Day,
                logDate.Month);
            var body = new Dictionary<string, string> {{"body", bodyString}};

            var comment =
                await
                    _restService.PostAsync(request, body, cancellationToken)
                        .ConfigureAwait(false);
            return (IComment) comment;
        }
    }
}