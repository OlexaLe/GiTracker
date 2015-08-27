using System;
using System.Collections.Generic;
using GiTracker.Models;

namespace GiTracker.Services.Api
{
    internal class GitHubApiProvider : IGitApiProvider
    {
        private readonly string _getIssues = "repos/{0}/issues?state=";
        public string Host => "https://api.github.com/";
        public string GetIssuesUrl => _getIssues + "all";
        public string GetOpenIssuesUrl => _getIssues + "open";
        public string GetClosedIssuesUrl => _getIssues + "closed";
        public Type IssueType => typeof (GitHubIssue);
        public Type IssueListType => typeof (IEnumerable<GitHubIssue>);
        public Type UserType => typeof (GitHubUser);
    }
}