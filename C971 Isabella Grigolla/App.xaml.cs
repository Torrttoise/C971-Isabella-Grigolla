using C971_Isabella_Grigolla.Services;
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




            if(SettingC971.FirstTimeRunning) 
            { 
                DS.LoadSampleContent();
                SettingC971.FirstTimeRunning = false;
            }

            var mainDashboard = new TermOverview(); //Change "TermOverview" to change the first page to load.
            var mainNavPage = new NavigationPage(mainDashboard);
            MainPage = mainNavPage;
        }
    }
}
