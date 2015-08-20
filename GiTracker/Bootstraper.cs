using GiTracker.Helpers;
using GiTracker.Services.Database;
using GiTracker.Services.Dialogs;
using GiTracker.Services.Issues;
using GiTracker.Services.Rest;
using GiTracker.Services.ServiceProvider;
using GiTracker.ViewModels;
using GiTracker.Views;
using Microsoft.Practices.Unity;
using Prism.Unity;
using GiTracker.Services.HttpClientProvider;

namespace GiTracker
{
    public class Bootstraper : UnityBootstrapper
    {
        protected override Xamarin.Forms.Page CreateMainPage ()
        {
            return Container.Resolve<MainPage> ();
        }

        protected override void RegisterTypes ()
		{
            Container.RegisterInstance(Container);

            Container.RegisterTypeForNavigation<IssueList, IssueListViewModel>();
            Container.RegisterTypeForNavigation<IssueDetails, IssueDetailsViewModel>();

			Container.RegisterType<Loader>();
            Container.RegisterType<GitHubIssueService>();

            Container.RegisterType<IDatabaseService, DatabaseService>();
            Container.RegisterType<IDialogService, DialogService>();
            Container.RegisterType<IRestService, RestService>();
            Container.RegisterType<IGitServiceProvider, GitServiceProvider>();

            Container.RegisterType<IGitsProvider, GithubProvider> ();
        }
    }
}

