using System;
using System.Collections.Generic;
using GiTracker.Models;

namespace GiTracker.Services.Api
{
    internal class GitHubApiProvider : IGitApiProvider
    {
        public string Host => "https://api.github.com/";
        // TODO: just an example
        public string GetIssuesUrl => "repos/XamarinGarage/GiTracker/issues";
        public Type IssueType => typeof (GitHubIssue);
        public Type IssueListType => typeof (IEnumerable<GitHubIssue>);
        public Type UserType => typeof (GitHubUser);
    }
}