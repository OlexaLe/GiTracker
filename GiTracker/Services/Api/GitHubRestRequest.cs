using System;
using System.Collections.Generic;
using GiTracker.Models.GitHub;
using GiTracker.Services.Credential;
using GiTracker.Services.Rest;

namespace GiTracker.Services.Api
{
    public class GitHubRestRequest : IRestRequest
    {
        private const string UserAgent = "XamarinGarage";

        private readonly ICredentialsService _credentialsService;

        public GitHubRestRequest(ICredentialsService credentialsService)
        {
            _credentialsService = credentialsService;
        }

        public Type ReturnValueType { get; set; }
        public Type ErrorType => typeof (GitHubError);
        public string Host => "https://api.github.com/";
        public string RelativeUrl { get; set; }
        public Dictionary<string, string> UrlParameters { get; set; }

        public Dictionary<string, string> DefaultHeaders => new Dictionary<string, string>
        {
            ["Authorization"] = $"Basic {_credentialsService.BasicAuthenticationToken}",
            ["User-Agent"] = UserAgent,
            ["Accept"] = "application/json"
        };
    }
}