using System;
using Xamarin.Forms;

namespace GiTracker
{
    public partial class App : Application
    {
		public static Application Instance;

        public App ()
        {
            InitializeComponent();

			Instance = this;

            var bs = new Bootstraper ();
            bs.Run (this);
        }

        protected override void OnStart ()
        {
            // Handle when your app starts
        }

        protected override void OnSleep ()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume ()
        {
            // Handle when your app resumes
        }
    }
}

