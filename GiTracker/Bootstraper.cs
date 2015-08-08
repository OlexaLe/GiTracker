using GiTracker.Database;
using GiTracker.Helpers;
using GiTracker.Services.Api;
using GiTracker.Services.Dialogs;
using GiTracker.Services.Rest;
using GiTracker.ViewModels;
using GiTracker.Views;
using Microsoft.Practices.Unity;
using Prism.Unity;

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
            Container.RegisterTypeForNavigation<IssueList, IssueListViewModel>();
            Container.RegisterTypeForNavigation<IssueDetails, IssueDetailsViewModel>();

			Container.RegisterType<Loader>();
			Container.RegisterType<IDatabaseService, DatabaseService>();
            Container.RegisterType<IDialogService, DialogService>();
            Container.RegisterType<IRestService, RestService>();
            Container.RegisterType<IGitApiServiceFactory, GitApiServiceFactory>();
        }
    }
}

