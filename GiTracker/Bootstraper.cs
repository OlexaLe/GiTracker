using GiTracker.Database;
using GiTracker.Services.Api;
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
            Container.RegisterType<IDatabaseService, DatabaseService>();
            Container.RegisterType<IGitApiServiceFactory, GitApiServiceFactory>();
        }
    }
}

