using Xamarin.Forms;

namespace GiTracker
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();

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

