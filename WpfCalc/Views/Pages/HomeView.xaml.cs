using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.ViewModels;
using СalculatorLib.ViewModels;

namespace WpfCalc.Views.Pages
{
    [MvxViewFor(typeof(HomeViewModel))]
    public partial class HomeView : MvxWpfView
    {
        public HomeView() => InitializeComponent();
    }
}
