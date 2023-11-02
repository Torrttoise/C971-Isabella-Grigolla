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
	public partial class CourseAdd : ContentPage
	{

        private readonly int _selectedTermId;

		public CourseAdd ()
		{
			InitializeComponent ();
		}

        public CourseAdd(int TermId)
        {
            InitializeComponent ();

            _selectedTermId = TermId;
        }



        private async void SaveCourse_Clicked(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(ClassName.Text))
            {
                await DisplayAlert("Missing Name", "Please Enter a name for the Course.", "OK");
                return;
            }

            if (ClassStatusPicker.SelectedItem == null)
            {
                await DisplayAlert("Missing Status", "Please select a value", "OK");
                return;
            }

            if(string.IsNullOrWhiteSpace(CourseInstructorName.Text))
            {
                await DisplayAlert("Missing Course Instructor Name", "Please Enter a name for your course Instructor.", "OK");
                return;
            }
            /*

            if (CourseInstructorPhone == null)
            {
                await DisplayAlert("Missing Course Instructor Phone Number", "Please Enter a number for your course Instructor.", "OK");
                return;
            }
            */

            if (string.IsNullOrWhiteSpace(CourseInstructorPhone.Text))
            {
                await DisplayAlert("Missing Course Instructor Phone Number", "Please Enter a number for your course Instructor.", "OK");
                return;
            }

            if (StartDatePicker.Date == EndDatePicker.Date)
            {
                await DisplayAlert("Start date and End date cannot be the same day.", "Please change the dates.", "Ok");
                return;
            }
            if (string.IsNullOrWhiteSpace(CourseInstructorEmail.Text))
            {
                await DisplayAlert("Missing Course Instructor Email", "Please Enter an email address for your course Instructor.", "OK");
                return;
            }

            if (StartDatePicker.Date > EndDatePicker.Date)
            {
                await DisplayAlert("End date cannot be before Start date.", "Please change the dates.", "Ok");
                return;
            }

            await DS.AddCourse(_selectedTermId, ClassName.Text, DateTime.Parse(StartDatePicker.Date.ToString()), DateTime.Parse(EndDatePicker.Date.ToString()), ClassStatusPicker.SelectedItem.ToString(), CourseInstructorName.Text, CourseInstructorPhone.Text, CourseInstructorEmail.Text, NotesFolders.Text, Notifications.IsToggled);

            await Navigation.PopAsync();
        }

        private async void CancelCourse_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        
    }
}