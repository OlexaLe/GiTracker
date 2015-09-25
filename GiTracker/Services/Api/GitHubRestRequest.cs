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

        private readonly ICredentialService _credentialService;

        public GitHubRestRequest(ICredentialService credentialService)
        {
            _credentialService = credentialService;
        }

        public Type ReturnValueType { get; set; }
        public Type ErrorType => typeof (GitHubError);
        public string Host => "https://api.github.com/";
        public string RelativeUrl { get; set; }
        public Dictionary<string, string> UrlParameters { get; set; }

        public Dictionary<string, string> DefaultHeaders
        {
            get
            {
                var credentialHeaders = _credentialService.Credential();
                credentialHeaders["User-Agent"] = UserAgent;
                credentialHeaders["Accept"] = "application/json";
                return credentialHeaders;
            }
        }
    }
}