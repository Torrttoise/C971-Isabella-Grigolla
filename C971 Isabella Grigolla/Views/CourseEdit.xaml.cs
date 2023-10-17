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
	public partial class CourseEdit : ContentPage
	{
		public CourseEdit ()
		{
			InitializeComponent ();
		}

        public CourseEdit(CourseView selectedCourse)
        { 
            InitializeComponent();

            long cIP = Convert.ToInt64(CourseInstructorPhone);

            CourseID.Text = selectedCourse.Id.ToString();
            CourseName.Text = selectedCourse.Name;
            CourseStatusPicker.SelectedItem = selectedCourse.Status;
            StartDatePicker.Date = selectedCourse.StartDate;
            EndDatePicker.Date = selectedCourse.EndDate;
            CourseInstructorName.Text = selectedCourse.CourseInstructorName;
            cIP = selectedCourse.CourseInstructorPhone;
            CourseInstructorEmail.Text = selectedCourse.CourseInstructorEmail;
            NotesFolders.Text = selectedCourse.Notes;
            Notifications.IsToggled = selectedCourse.Notifications;

        }


        private void DeleteCourse_Clicked(object sender, EventArgs e)
        {

        }

        private void CancelCourse_Clicked(object sender, EventArgs e)
        {

        }

        private async void SaveCourse_Clicked(object sender, EventArgs e)
        {

            decimal tossedDecimal;
            int tossedInt;
            //tossedDecimal = 0;


            if (string.IsNullOrWhiteSpace(CourseName.Text))
            {
                await DisplayAlert("Missing Course Name", "Please enter a name for this course.", "Ok");
                return;
            }

            if (string.IsNullOrWhiteSpace(CourseStatusPicker.SelectedItem.ToString()))
            {
                await DisplayAlert("Missing Course Status", "Please select a status for this course.", "Ok");
                return;
            }


            if(string.IsNullOrWhiteSpace(CourseInstructorName.Text)) 
            {
                await DisplayAlert("Missing Course Insructor Name", "Please enter a name for your course instructor.", "Ok");
                return;
            }


            if (string.IsNullOrWhiteSpace(CourseInstructorPhone.Text)) // check if this works due to string/int
            {
                await DisplayAlert("Missing Course Insructor Number", "Please enter a number for your course instructor.", "Ok");
                return;
            }

            if (string.IsNullOrWhiteSpace(CourseInstructorEmail.Text))
            {
                await DisplayAlert("Missing Course Insructor Email", "Please enter an email for your course instructor.", "Ok");
                return;
            }

            


        }
            

        }

        private void ShareButton_Clicked(object sender, EventArgs e)
        {

        }

        private void ShareURL_Clicked(object sender, EventArgs e)
        {

        }
    }
}