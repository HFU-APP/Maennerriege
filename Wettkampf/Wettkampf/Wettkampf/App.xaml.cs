using System;
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

            DependencyService.Register<ItemMockDataStore>();
            DependencyService.Register<AlbumMockDataStore>();

            MainPage = new MainPage();
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
