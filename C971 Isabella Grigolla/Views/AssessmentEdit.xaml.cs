using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using C971_Isabella_Grigolla.Models;
using C971_Isabella_Grigolla.Services;
using C971_Isabella_Grigolla.Views;
using Xamarin.Essentials;

namespace C971_Isabella_Grigolla.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssessmentEdit : ContentPage
    {
        public AssessmentEdit()
        {
            InitializeComponent();
        }

        public AssessmentEdit(CourseAssessments selectedAssessment)
        {
            InitializeComponent();


            AssessmentId.Text = selectedAssessment.Id.ToString();
            AssessmentName.Text = selectedAssessment.Name;
            AssessmentTypePicker.SelectedItem = selectedAssessment.TypeOfAssessment;
            StartDatePicker.Date = selectedAssessment.StartDate;
            EndDatePicker.Date = selectedAssessment.EndDate;

        }

        private async void SaveAssessment_Clicked(object sender, EventArgs e)
        {
            decimal tossedDecimal;
            int tossedInt;
            //tossedDecimal = 0;
            //int cIP2;


            if (string.IsNullOrWhiteSpace(AssessmentName.Text))
            {
                await DisplayAlert("Missing Assessment Name", "Please enter a name for this assessment.", "Ok");
                return;
            }

            if (string.IsNullOrWhiteSpace(AssessmentTypePicker.SelectedItem.ToString()))
            {
                await DisplayAlert("Missing Assessment Type", "Please select a type for this Assessment.", "Ok");
                return;
            }

           
            if (StartDatePicker.Date == EndDatePicker.Date)
            {
                await DisplayAlert("Start date and End date cannot be the same day.", "Please change the dates.", "Ok");
                return;
            }

            if (EndDatePicker.Date  > StartDatePicker.Date)
            {
                await DisplayAlert("End date cannot be before Start date.", "Please change the dates.", "Ok");
                return;
            }

            await Databaseervice.UpdateAssessment(Int32.Parse(AssessmentId.Text), AssessmentName.Text, AssessmentTypePicker.SelectedItem.ToString(), StartDatePicker.Date, EndDatePicker.Date);

            await Navigation.PopAsync();
        }

        private async void CancelAssessment_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void DeleteAssessment_Clicked(object sender, EventArgs e)
        {
            var selected = await DisplayAlert("Delete this assessment?", "Are you sure?", "Yes", "No");

            if (selected == true)
            {
                var id = int.Parse(AssessmentId.Text);

                await Databaseervice.RemoveCourse(id);

                await DisplayAlert("Assessment has been deleted.", "Assessment has been deleted.", "Ok");

            }

            else
            {
                await DisplayAlert("Deletion Cancelled", "Assessment has not been deleted.", "Ok");
            }

            await Navigation.PopAsync();
        }
    }
}