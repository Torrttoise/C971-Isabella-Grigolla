using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace C971_Isabella_Grigolla.Models
{
    public static class TSettings
    {
        public static bool FirstRun
        {
            get => Preferences.Get(nameof(FirstRun), true);
            set => Preferences.Set(nameof(FirstRun), value);
        }
    }
}
