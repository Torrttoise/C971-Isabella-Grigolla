using C971_Isabella_Grigolla.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace C971_Isabella_Grigolla
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var mainDashboard = new CourseInfo();
            var mainNavPage = new NavigationPage(mainDashboard);
            MainPage = mainNavPage;
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
