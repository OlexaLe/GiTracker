using System;
using GiTracker.Services.Issues;
using Microsoft.Practices.Unity;

namespace GiTracker.Services.ServiceProvider
{
    class GitServiceProvider : IGitServiceProvider
    {
        readonly IUnityContainer _container;

        public GitServiceProvider(IUnityContainer unityContainer)
        {
            _container = unityContainer;
        }

        GitApiServiceType GetCurrentGitServiceType()
        {
            // TODO: get service type from some kind of settings later
            return GitApiServiceType.GitHub;
        }

        public IIssueService GetIssueService()
        {
            return GetIssueService(GetCurrentGitServiceType());
        }

        IIssueService GetIssueService(GitApiServiceType apiServiceType)
        {
            switch (apiServiceType)
            {
                case GitApiServiceType.GitHub:
                    return _container.Resolve<GitHubIssueService>();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
