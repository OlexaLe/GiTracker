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
        private readonly ICredentialService _credentialService;

        private readonly Type _issueListType = typeof (IEnumerable<GitHubIssue>);
        private readonly Type _reposListType = typeof (IEnumerable<GitHubRepo>);
        private readonly Type _userType = typeof (GitHubUser);

        public GitHubApiProvider(ICredentialService credentialService)
        {
            _credentialService = credentialService;
        }

        public IRestRequest GetIssuesRequest(string repository)
        {
            return new GitHubRestRequest(_credentialService)
            {
                ReturnValueType = _issueListType,
                RelativeUrl = $"repos/{repository}/issues",
                UrlParameters = new Dictionary<string, string> {{"state", "all"}}
            };
        }

        public IRestRequest GetUserRepositoriesRequest()
        {
            return new GitHubRestRequest(_credentialService)
            {
                ReturnValueType = _reposListType,
                RelativeUrl = "users/foxanna/repos"
            };
        }

        public IRestRequest GetCreateCommentRequest(string repository, int issueId)
        {
            return new GitHubRestRequest(_credentialService)
            {
                ReturnValueType = _commentType,
                RelativeUrl = $"repos/{repository}/issues/{issueId}/comments"
            };
        }

        public IRestRequest GetLoadCommentsRequest(string repository, int issueId)
        {
            return new GitHubRestRequest(_credentialService)
            {
                ReturnValueType = _commentsListType,
                RelativeUrl = $"repos/{repository}/issues/{issueId}/comments"
            };
        }

        public IRestRequest GetUserRequest()
        {
            return new GitHubRestRequest(_credentialService)
            {
                ReturnValueType = _userType,
                RelativeUrl = "user"
            };
        }
    }
}