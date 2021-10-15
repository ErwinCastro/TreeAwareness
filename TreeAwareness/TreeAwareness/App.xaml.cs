using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


using TreeAwareness.Services;

namespace TreeAwareness
{
    public partial class App : Application
    {
        iAuth auth;
        public App()
        {
            InitializeComponent();
            auth = DependencyService.Get<iAuth>();

            if (auth.IsSignIn())
            {
                MainPage = new NavigationPage(new Views.Dashboard());
            }
            else
            {
                MainPage = new MainPage();
            }
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
