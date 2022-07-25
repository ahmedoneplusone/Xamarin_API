using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinTesting.Services;
using XamarinTesting.Views;

namespace XamarinTesting
{
    public partial class App : Application
    {

        public App()
        {
            DependencyService.Register<ProfileService>();
            InitializeComponent();
            MainPage = new AppShell();
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
