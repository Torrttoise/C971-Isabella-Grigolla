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

namespace C971_Isabella_Grigolla.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private readonly int _selectedTerm;
        
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            TermOverview.ItemsSource = await Databaseervice.GetTerms();
        }
        
        

        private async void TermOverview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection!=null)
            {
                Term term = (Term)e.CurrentSelection.FirstOrDefault();
                //await Navigation.PushAsync(new TermEdit(term));
            }
        }
    }
}