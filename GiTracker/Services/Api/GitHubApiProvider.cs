using System;
using System.Collections.Generic;
using GiTracker.Models.GitHub;
using GiTracker.Services.Credential;
using GiTracker.Services.Rest;

namespace GiTracker.Services.Api
{
    internal class GitHubApiProvider : IGitApiProvider
    {
        private readonly Type _commentsListType = typeof (IEnumerable<GitHubComment>);
        private readonly Type _commentType = typeof (GitHubComment);
        private readonly ICredentialsService _credentialsService;

        private readonly Type _issueListType = typeof (IEnumerable<GitHubIssue>);
        private readonly Type _reposListType = typeof (IEnumerable<GitHubRepo>);
        private readonly Type _userType = typeof (GitHubUser);

        public GitHubApiProvider(ICredentialsService credentialsService)
        {
            _credentialsService = credentialsService;
        }

        public IRestRequest GetIssuesRequest(string repository)
        {
            return new GitHubRestRequest(_credentialsService)
            {
                ReturnValueType = _issueListType,
                RelativeUrl = $"repos/{repository}/issues",
                UrlParameters = new Dictionary<string, string> {{"state", "all"}}
            };
        }

        public IRestRequest GetUserRepositoriesRequest()
        {
            return new GitHubRestRequest(_credentialsService)
            {
                ReturnValueType = _reposListType,
                RelativeUrl = "users/foxanna/repos"
            };
        }

        public IRestRequest GetCreateCommentRequest(string repository, int issueNumber)
        {
            return new GitHubRestRequest(_credentialsService)
            {
                ReturnValueType = _commentType,
                RelativeUrl = $"repos/{repository}/issues/{issueNumber}/comments"
            };
        }

        public IRestRequest GetLoadCommentsRequest(string repository, int issueNumber)
        {
            return new GitHubRestRequest(_credentialsService)
            {
                ReturnValueType = _commentsListType,
                RelativeUrl = $"repos/{repository}/issues/{issueNumber}/comments"
            };
        }

        public IRestRequest GetUserRequest()
        {
            return new GitHubRestRequest(_credentialsService)
            {
                ReturnValueType = _userType,
                RelativeUrl = "user"
            };
        }
    }
}