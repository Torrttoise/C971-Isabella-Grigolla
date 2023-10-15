using C971_Isabella_Grigolla.Models;
using C971_Isabella_Grigolla.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.LocalNotifications;

namespace C971_Isabella_Grigolla.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TermEdit : ContentPage
	{

		private readonly int _selectedTermId;

		protected override async void OnAppearing()
		{
			base.OnAppearing();


			int countCourses = await Databaseervice.GetCourseCountAsync(_selectedTermId);

			CountLabel.Text = countCourses.ToString();

			ClassCollectionView.ItemsSource = await Databaseervice.GetCourses(_selectedTermId);


		}


		public TermEdit()
		{
			InitializeComponent();
		}

		private void ClassCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		public TermEdit(Term term)
		{
			InitializeComponent();

			_selectedTermId = term.Id;

			TermID.Text = term.Id.ToString();
			TermName.Text = term.Name;
			StartDatePicker.Date = term.StartDate;
			EndDatePicker.Date = term.EndDate;


		}

		async void SaveTerm_OnClicked(object sender, EventArgs e)
		{
			decimal tossedDecimal;
			int tossedInt;

			if (string.IsNullOrWhiteSpace(TermName.Text))
			{
				await DisplayAlert("Missing Name", "Please Enter a name for the Term.", "OK");
				return;
			}

			await Databaseervice.UpdateTerm(Int32.Parse(TermID.Text), TermName.Text, DateTime.Parse(StartDatePicker.Date.ToString()), DateTime.Parse(EndDatePicker.Date.ToString()));

			await Navigation.PopAsync();

		}

		async void CancelTerm_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}

		async void DeleteTerm_Clicked(object sender, EventArgs e)
		{
			var answer = await DisplayAlert("Delete Term and Associated Classes?", "Confirm Delete?", "Yes", "No");

			if (answer == true)
			{
				var id = int.Parse(TermID.Text);

				await Databaseervice.RemoveTerm(id);

				await DisplayAlert("Term Deleted", "OK");


			}

			else
			{
				await DisplayAlert("Deletion Cancelled", "Ok");
			}

			await Navigation.PopAsync();

		}

		async void AddCourse_OnClicked(Object sender, EventArgs e)
		{
			var termId = Int32.Parse(TermID.Text);

			await Navigation.PushAsync(new CourseAdd(termId));
		}

        async void CourseCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
			var course = (CourseView)e.CurrentSelection.FirstOrDefault();

			if (e.CurrentSelection != null) 
			{
				await Navigation.PushAsync((new CourseEdit(course)));
			}
        }
    }
}