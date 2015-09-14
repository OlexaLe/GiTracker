using System;
using System.Collections.Generic;
using GiTracker.Models.GitHub;
using GiTracker.Services.Credential;
using GiTracker.Services.Rest;

namespace GiTracker.Services.Api
{
    internal class GitHubApiProvider : IGitApiProvider
    {
        private const string UserAgent = "XamarinGarage";
        private const string Host = "https://api.github.com/";
        private readonly Type _commentsListType = typeof (IEnumerable<GitHubComment>);
        private readonly Type _commentType = typeof (GitHubComment);
        private readonly ICredentialService _credentialService;

        private readonly Type _issueListType = typeof (IEnumerable<GitHubIssue>);
        private readonly Type _reposListType = typeof (IEnumerable<GitHubRepo>);
        private readonly Type _userType = typeof (GitHubUser);

        public GitHubApiProvider(ICredentialService credentialService)
        {
            _credentialService = credentialService;
        }

        public RestRequest GetIssuesRequest(string repository)
        {
            return new RestRequest
            {
                ReturnValueType = _issueListType,
                Host = Host,
                RelativeUrl = $"repos/{repository}/issues",
                DefaultHeaders = DefaultHeaders(),
                UrlParameters = new Dictionary<string, string> {{"state", "all"}}
            };
        }

        public RestRequest GetUserRepositoriesRequest()
        {
            return new RestRequest
            {
                ReturnValueType = _reposListType,
                Host = Host,
                RelativeUrl = "users/foxanna/repos",
                DefaultHeaders = DefaultHeaders()
            };
        }

        public RestRequest GetCreateCommentRequest(string repository, int issueId)
        {
            return new RestRequest
            {
                ReturnValueType = _commentType,
                Host = Host,
                RelativeUrl = $"repos/{repository}/issues/{issueId}/comments",
                DefaultHeaders = DefaultHeaders()
            };
        }

        public RestRequest GetLoadCommentsRequest(string repository, int issueId)
        {
            return new RestRequest
            {
                ReturnValueType = _commentsListType,
                Host = Host,
                RelativeUrl = $"repos/{repository}/issues/{issueId}/comments",
                DefaultHeaders = DefaultHeaders()
            };
        }

        public RestRequest GetUserRequest()
        {
            return new RestRequest
            {
                ReturnValueType = _userType,
                Host = Host,
                RelativeUrl = "user",
                DefaultHeaders = DefaultHeaders()
            };
        }

        private Dictionary<string, string> DefaultHeaders()
        {
            var credentialHeaders = _credentialService.Credential();
            credentialHeaders["User-Agent"] = UserAgent;
            credentialHeaders["Accept"] = "application/json";
            return credentialHeaders;
        }
    }
}