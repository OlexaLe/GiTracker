using GiTracker.Services.Api;
using GiTracker.Services.Database;
using GiTracker.Services.Device;
using GiTracker.Services.DataLoader;
using GiTracker.Services.Dialogs;
using GiTracker.Services.Issues;
using GiTracker.Services.Progress;
using GiTracker.Services.Repos;
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

            Container.RegisterTypeForNavigation<RepoListPage, RepoListPageViewModel>();
            Container.RegisterTypeForNavigation<IssueListPage, IssueListPageViewModel>();
            Container.RegisterTypeForNavigation<IssueDetailsPage, IssueDetailsPageViewModel>();

            Container.RegisterType<ILoader, Loader>();
            Container.RegisterType<IRepoService, RepoService>();
            Container.RegisterType<IIssueService, IssueService>();
            Container.RegisterType<IDatabaseService, DatabaseService>();
            Container.RegisterType<IDialogService, DialogService>();
            Container.RegisterType<IRestService, RestService>();
            Container.RegisterType<IProgressService, ProgressService>();
            Container.RegisterType<IDeviceService, DeviceService>();

            Container.RegisterType<IGitApiProvider, GitHubApiProvider>();
        }
    }
}