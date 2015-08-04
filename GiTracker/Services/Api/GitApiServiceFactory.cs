using System;
using Prism.Services;

namespace GiTracker.Services.Api
{
    class GitApiServiceFactory : IGitApiServiceFactory
    {
        readonly GitHubApiService _gitHubApiService;

        // TODO: obtain GitHubApiService instance when really nesessary in GetApiService
        public GitApiServiceFactory(GitHubApiService gitHubApiService)
        {
            _gitHubApiService = gitHubApiService;
        }

        public IGitApiService GetApiService()
        {
            // TODO: get service type from some kind of settings later

            return GetApiService(GitApiServiceType.GitHub);
        }

        public IGitApiService GetApiService(GitApiServiceType apiServiceType)
        {
            switch(apiServiceType)
            {
                case GitApiServiceType.GitHub:
                    return _gitHubApiService;
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
