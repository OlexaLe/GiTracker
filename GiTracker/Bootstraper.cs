using System;
using Prism.Unity;
using GiTracker.Views;
using Microsoft.Practices.Unity;

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
        }
    }
}

