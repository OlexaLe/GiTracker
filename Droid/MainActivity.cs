using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace GiTracker.Droid
{
    [Activity(Label = "GiTracker",
        Icon = "@drawable/icon",
        MainLauncher = true,
        Theme = "@style/GiTrackerTheme",
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Forms.Init(this, bundle);

            if (UserDialogs.Instance == null)
            {
                UserDialogs.Init(this);
            }

            LoadApplication(new App());
        }
    }
}