using C971_Isabella_Grigolla.Models;
using C971_Isabella_Grigolla.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace C971_Isabella_Grigolla.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TermAdd : ContentPage
	{
		public TermAdd ()
		{
			InitializeComponent ();
		}

        async void SaveTerm_Clicked(object sender, EventArgs e)
        {
            decimal tossedDecimal;
            int tossedInt;

            if (string.IsNullOrWhiteSpace(TermName.Text))
            {
                await DisplayAlert("Missing Name", "Please Enter a name for the Term.", "OK");
                return;
            }

            await Databaseervice.AddTerm(TermName.Text, DateTime.Parse(StartDatePicker.Date.ToString()), DateTime.Parse(EndDatePicker.Date.ToString()));

            await Navigation.PopAsync();
        }

        async void CancelTerm_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}