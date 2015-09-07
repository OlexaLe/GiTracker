using System;
using System.Collections.Generic;
using GiTracker.Models.GitHub;
using GiTracker.Services.Rest;

namespace GiTracker.Services.Api
{
    internal class GitHubApiProvider : IGitApiProvider
    {
        private const string UserAgent = "XamarinGarage";
        private const string Host = "https://api.github.com/";

        private readonly Type _commentType = typeof (GitHubComment);

        private readonly Dictionary<string, string> DefaultHeaders =
            new Dictionary<string, string>
            {
                {"User-Agent", UserAgent},
                {"Accept", "application/json"}
            };

        private readonly Type IssueListType = typeof (IEnumerable<GitHubIssue>);

        private readonly Type ReposListType = typeof (IEnumerable<GitHubRepo>);

        public RestRequest GetIssuesRequest(string repository)
        {
            return new RestRequest
            {
                ReturnValueType = IssueListType,
                Host = Host,
                RelativeUrl = $"repos/{repository}/issues",
                DefaultHeaders = DefaultHeaders,
                UrlParameters = new Dictionary<string, string> {{"state", "all"}}
            };
        }

        public RestRequest GetUserRepositoriesRequest()
        {
            return new RestRequest
            {
                ReturnValueType = ReposListType,
                Host = Host,
                RelativeUrl = "users/foxanna/repos",
                DefaultHeaders = DefaultHeaders
            };
        }

        public RestRequest CreateCommentRequest(string repository, int issueId)
        {
            return new RestRequest
            {
                ReturnValueType = _commentType,
                Host = Host,
                RelativeUrl = $"repos/{repository}/issues/{issueId}/comments",
                DefaultHeaders = DefaultHeaders
            };
        }
    }
}