using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SQLite;
using C971_Isabella_Grigolla.Services;
using C971_Isabella_Grigolla.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using C971_Isabella_Grigolla.Views;
using Plugin.LocalNotifications;
using Xamarin.Forms.Xaml;

namespace C971_Isabella_Grigolla.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            InitializeComponent();
        }
    }
}