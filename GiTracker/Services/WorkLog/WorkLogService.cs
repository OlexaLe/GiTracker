using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<WorkLogItem> LogTimeAsync(string repo, int issueNumber, DateTime logDate, TimeSpan logTime,
            CancellationToken cancellationToken)
        {
            var request = _gitApiProvider.GetCreateCommentRequest(repo, issueNumber);
            var bodyString = WorkLogFormatHelper.GetCommentBody(logDate, logTime);
            var body = new Dictionary<string, string> {{"body", bodyString}};

            var comment =
                await
                    _restService.PostAsync(request, body, cancellationToken)
                        .ConfigureAwait(false) as IComment;

            return new WorkLogItem {Creator = comment.Author, Date = logDate, Time = logTime};
        }

        public async Task<IEnumerable<WorkLogItem>> GetLogsAsync(string repo, int issueNumber,
            CancellationToken cancellationToken)
        {
            var request = _gitApiProvider.GetLoadCommentsRequest(repo, issueNumber);
            var comments =
                await _restService.GetAsync(request, cancellationToken).ConfigureAwait(false) as IEnumerable<IComment>;
            var workLogs = comments.Where(WorkLogFormatHelper.IsWorkLog).Select(WorkLogFormatHelper.ExtractWorkLogItem);
            return workLogs;
        }
    }
}