using System;
using System.Collections.Generic;
using System.Text;
using GiTracker.Models.GitHub;
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
        private readonly Type ReposListType = typeof (IEnumerable<GitHubRepo>);
        private readonly Type UserType = typeof (GitHubUser);

        private string _basicAuthentication;

        public RestRequest GetLoginRequest(string username, string password)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes($"{username}:{password}");
            _basicAuthentication = Convert.ToBase64String(plainTextBytes);
            DefaultHeaders["Authorization"] = $"Basic {_basicAuthentication}";
            return new RestRequest
            {
                ReturnValueType = UserType,
                Host = Host,
                RelativeUrl = "user",
                DefaultHeaders = DefaultHeaders
            };
        }

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
    }
}