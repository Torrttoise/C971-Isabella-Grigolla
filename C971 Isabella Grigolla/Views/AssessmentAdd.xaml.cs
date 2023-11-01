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
    public partial class AssessmentAdd : ContentPage
    {

        private readonly int _selectedCourseId;
        public AssessmentAdd()
        {
            InitializeComponent();
        }

        public AssessmentAdd(int CourseId)
        {
            InitializeComponent ();

            _selectedCourseId = CourseId;
        }

        private async void SaveAssessment_Clicked(object sender, EventArgs e)
        {
            decimal tossedDecimal;
            int tossedInt;

            if (string.IsNullOrWhiteSpace(AssessmentName.Text))
            {
                await DisplayAlert("Missing Name", "Please Enter a name for the Assessment.", "OK");
                return;
            }

            if (StartDatePicker.Date == EndDatePicker.Date)
            {
                await DisplayAlert("Start date and End date cannot be the same day.", "Please change the dates.", "Ok");
                return;
            }

            if (StartDatePicker.Date > EndDatePicker.Date)
            {
                await DisplayAlert("End date cannot be before Start date.", "Please change the dates.", "Ok");
                return;
            }

            await Databaseervice.AddAssessment(_selectedCourseId, AssessmentName.Text, AssessmentTypePicker.SelectedItem.ToString(), DateTime.Parse(StartDatePicker.Date.ToString()), DateTime.Parse(EndDatePicker.Date.ToString()), Notifications.IsToggled);

            await Navigation.PopAsync();


        }

        private async void CancellAssessment_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }













        private async void Home_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}