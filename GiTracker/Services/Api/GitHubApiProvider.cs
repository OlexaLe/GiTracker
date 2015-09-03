using System;
using System.Collections.Generic;
using GiTracker.Models;
using GiTracker.Models.GitHub;

namespace GiTracker.Services.Api
{
    internal class GitHubApiProvider : IGitApiProvider
    {
        public string Host => "https://api.github.com/";
        public string GetIssuesUrl(string repository) => $"repos/{repository}/issues?state=all";
        public Type IssueType => typeof (GitHubIssue);
        public Type IssueListType => typeof (IEnumerable<GitHubIssue>);
        public Type UserType => typeof (GitHubUser);
    }
}