using System;
using SimpleInjector;
using Turnverein;
using Turnverein.Views;
using Wettkampf.Models;
using Wettkampf.Services;
using Wettkampf.Views;
using Xamarin.Forms;
using SimpleInjector;
using Xamarin.Forms.Xaml;
using Wettkampf.Core;

namespace Wettkampf
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            var loginPage = new LoginPage();
            var navigationPage = new NavigationPage(loginPage);

            //Services.RegisterSingleton<IDataStore<Verein>, VereinMockDataStore>();
            Services.RegisterWettkampfServices();
            Services.RegisterInstance<Page>(navigationPage);
            //Services.RegisterSingleton<IDialogService, DialogService>();

            var datastore = Services.GetInstance<IDataStore<Verein>>();
            datastore.Initialize();

            MainPage = navigationPage;
        }
        public static Container Services { get; private set; } = ContainerExtensions.CreateContainer();



        //DependencyService.Register<VereinMockDataStore>();

        //MainPage = new NavigationPage(new LoginPage());
    

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
