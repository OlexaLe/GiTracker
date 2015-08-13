using Android.App;
using Android.Content.PM;
using Android.OS;

namespace GiTracker.Droid
{
    [Activity (Label = "GiTracker", 
        Icon = "@drawable/icon", 
        MainLauncher = true, 
        // TODO: check whether this works on Android 4+
        Theme = "@android:style/Theme.Material.Light.DarkActionBar",
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);

            Xamarin.Forms.Forms.Init (this, bundle);

            LoadApplication (new App ());
        }
    }
}

