using MvvmCross.IoC;
using MvvmCross.ViewModels;
using СalculatorLib.ViewModels.Pages;

namespace СalculatorLib
{
    public class MyApp : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<HomeViewModel>();
        }
    }
}