using GiTracker.Helpers;
using GiTracker.Services.Database;
using GiTracker.Services.Dialogs;
using GiTracker.Services.Issues;
using GiTracker.Services.Login;
using GiTracker.Services.Rest;
using GiTracker.Services.ServiceProvider;
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
            return Container.Resolve<LoginPage>();
        }

        protected override void RegisterTypes()
        {
            Container.RegisterInstance(Container);

            Container.RegisterTypeForNavigation<IssueList, IssueListViewModel>();
            Container.RegisterTypeForNavigation<IssueDetails, IssueDetailsViewModel>();

            Container.RegisterType<Loader>();
            Container.RegisterType<GitHubIssueService>();

            Container.RegisterType<IDatabaseService, DatabaseService>();
            Container.RegisterType<ILoginService, LoginService>();
            Container.RegisterType<IDialogService, DialogService>();
            Container.RegisterType<IRestService, RestService>();
            Container.RegisterType<IGitServiceProvider, GitServiceProvider>();
        }
    }
}