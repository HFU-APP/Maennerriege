using System;
using SimpleInjector;
using Turnverein;
using Turnverein.Views;
using Wettkampf.Models;
using Wettkampf.Services;
using Wettkampf.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wettkampf
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            var loginPage = new LoginPage();
            var navigationPage = new NavigationPage(loginPage);

            Services.RegisterSingleton<IDataStore<Verein>, VereinMockDataStore>();
            Services.RegisterInstance<Page>(navigationPage);
            Services.RegisterSingleton<IDialogService, DialogService>();

            MainPage = navigationPage;
        }

        public static Container Services { get; } = CreateContainer();

        private static Container CreateContainer()
        {
            return new Container()
            {
                Options =
                {
                    ResolveUnregisteredConcreteTypes = true
                }
            };

            //DependencyService.Register<VereinMockDataStore>();

            //MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
