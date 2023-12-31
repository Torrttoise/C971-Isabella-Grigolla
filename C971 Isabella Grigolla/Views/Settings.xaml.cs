﻿using C971_Isabella_Grigolla.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace C971_Isabella_Grigolla.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppSettings : ContentPage
    {
        public AppSettings()
        {
            InitializeComponent();
        }

        private void ClearSettings_Clicked(object sender, EventArgs e)
        {
            Preferences.Clear();
        }

        private async void LoadSampleContent_Clicked(object sender, EventArgs e)
        {

            if (SettingC971.FirstTimeRunning)
            {
               DS.LoadSampleContent();
               SettingC971.FirstTimeRunning = false;



                await Navigation.PopToRootAsync();

            }

        }

        private async void WipeSampleContent_Clicked(object sender, EventArgs e)
        {




            await DS.WipeSampleData();
        }

       
    }
}