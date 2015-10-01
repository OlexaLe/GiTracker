using GiTracker.Events;
using GiTracker.Services.Api;
using GiTracker.Services.Credential;
using GiTracker.Services.Database;
using GiTracker.Services.DataLoader;
using GiTracker.Services.Device;
using GiTracker.Services.Dialogs;
using GiTracker.Services.Issues;
using GiTracker.Services.Login;
using GiTracker.Services.Progress;
using GiTracker.Services.Repos;
using GiTracker.Services.Rest;
using GiTracker.Services.Settings;
using GiTracker.Services.WorkLog;
using GiTracker.ViewModels;
using GiTracker.Views;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Unity;
using Xamarin.Forms;

namespace GiTracker
{
    public class Bootstraper : UnityBootstrapper
    {
        private void ShowLoginPage(string obj)
        {
            App.MainPage = Container.Resolve<LoginPage>();
        }

        private void ShowMainPage(string obj)
        {
            App.MainPage = Container.Resolve<MainPage>();
        }

        protected override Page CreateMainPage()
        {
            var credentialsService = Container.Resolve<ICredentialsService>();
            return credentialsService.HasCredentials
                ? (Page) Container.Resolve<MainPage>()
                : Container.Resolve<LoginPage>();
        }

        protected override void RegisterTypes()
        {
            Container.RegisterInstance(Container);

            Container.RegisterTypeForNavigation<RepoListPage, RepoListPageViewModel>();
            Container.RegisterTypeForNavigation<IssueListPage, IssueListPageViewModel>();
            Container.RegisterTypeForNavigation<IssueDetailsPage, IssueDetailsPageViewModel>();
            Container.RegisterTypeForNavigation<LogWorkPage, LogWorkPageViewModel>();
            Container.RegisterTypeForNavigation<WorkLogsPage, WorkLogsPageViewModel>();

            Container.RegisterType<ILoader, Loader>();
            Container.RegisterType<IRepoService, RepoService>();
            Container.RegisterType<IIssueService, IssueService>();
            Container.RegisterType<IDatabaseService, DatabaseService>();
            Container.RegisterType<IDialogService, DialogService>();
            Container.RegisterType<IRestService, RestService>();
            Container.RegisterType<IProgressService, ProgressService>();
            Container.RegisterType<IDeviceService, DeviceService>();
            Container.RegisterType<ILoginService, LoginService>();
            Container.RegisterType<IWorkLogService, WorkLogService>();
            Container.RegisterType<IGitApiProvider, GitHubApiProvider>();
            Container.RegisterType<ISettingsManager, SettingsManager>();
            Container.RegisterType<ICredentialsService, CredentialsService>();

            var eventCgr = Container.Resolve<IEventAggregator>();
            eventCgr.GetEvent<LoginEvent>().Subscribe(ShowMainPage);
            eventCgr.GetEvent<LogoutEvent>().Subscribe(ShowLoginPage);
        }
    }
}