using MvvmCross.Core;
using MvvmCross.Platforms.Wpf.Core;
using MvvmCross.Platforms.Wpf.Views;

namespace WpfCalc
{
    public partial class App : MvxApplication
    {
        public App() => this.RegisterSetupType<MvxWpfSetup<СalculatorLib.MyApp>>();
    }
}