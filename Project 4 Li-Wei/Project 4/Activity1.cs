using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;

namespace Project_4
{
    [Activity(Label = "Project 4"
        , MainLauncher = true
        , Icon = "@drawable/icon"
        , Theme = "@style/Theme.Splash"
        , AlwaysRetainTaskState = true
        , LaunchMode = Android.Content.PM.LaunchMode.SingleInstance
        , ScreenOrientation = ScreenOrientation.FullUser
        , ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden | ConfigChanges.ScreenSize)]
    public class Activity1 : Microsoft.Xna.Framework.AndroidGameActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            var StartGame = new Game1();
            SetContentView((View)StartGame.Services.GetService(typeof(View)));
            StartGame.Run();
        }
    }
}

