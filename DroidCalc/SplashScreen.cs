using Android.App;
using Android.Content.PM;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;

namespace DroidCalc
{
    [Activity
        (
        Label = "DroidCalc", 
        MainLauncher = true, 
        NoHistory = true, 
        ScreenOrientation = ScreenOrientation.Portrait
        )
    ]
    public class SplashScreen : MvxSplashScreenActivity<MvxAndroidSetup<СalculatorLib.MyApp>, СalculatorLib.MyApp>
    {
        public SplashScreen() : base(Resource.Layout.SplashScreen) { }
    }
}
