using GiTracker.Helpers;
using GiTracker.Services.Api;
using GiTracker.Services.Database;
using GiTracker.Services.Dialogs;
using GiTracker.Services.Issues;
using GiTracker.Services.Rest;
using GiTracker.ViewModels;
using GiTracker.Views;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Xamarin.Forms;

namespace GiTracker
{
    public class Bootstraper : UnityBootstrapper
    {
        protected override Page CreateMainPage()
        {
            return Container.Resolve<MainPage>();
        }

        protected override void RegisterTypes()
        {
            Container.RegisterInstance(Container);

            Container.RegisterTypeForNavigation<IssueList, IssueListViewModel>();
            Container.RegisterTypeForNavigation<IssueDetails, IssueDetailsViewModel>();

            Container.RegisterType<Loader>();

            Container.RegisterType<IIssueService, IssueService>();
            Container.RegisterType<IDatabaseService, DatabaseService>();
            Container.RegisterType<IDialogService, DialogService>();
            Container.RegisterType<IRestService, RestService>();

            Container.RegisterType<IGitApiProvider, GitHubApiProvider>();
        }
    }
}