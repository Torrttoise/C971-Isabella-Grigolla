using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace C971_Isabella_Grigolla.Services
{
    public static class SettingC971
    {
        public static bool FirstTimeRunning
        {
            get => Preferences.Get(nameof(FirstTimeRunning), true);
            set => Preferences.Set(nameof(FirstTimeRunning), value);
        }

    }
}
