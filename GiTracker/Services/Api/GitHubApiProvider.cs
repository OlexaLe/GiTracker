using System;
using System.Collections.Generic;
using GiTracker.Models;
using GiTracker.Services.Rest;

namespace GiTracker.Services.Api
{
    internal class GitHubApiProvider : IGitApiProvider
    {
        private const string UserAgent = "XamarinGarage";
        private const string Host = "https://api.github.com/";

        private readonly Dictionary<string, string> DefaultHeaders =
            new Dictionary<string, string>
            {
                {"User-Agent", UserAgent},
                {"Accept", "application/json"}
            };

        private readonly Type IssueListType = typeof (IEnumerable<GitHubIssue>);

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
    }
}