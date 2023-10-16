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
            NotesFolders.Text = 


        }


        private void DeleteCourse_Clicked(object sender, EventArgs e)
        {

        }

        private void CancelCourse_Clicked(object sender, EventArgs e)
        {

        }

        private void SaveCourse_Clicked(object sender, EventArgs e)
        {

        }

        private void ShareButton_Clicked(object sender, EventArgs e)
        {

        }

        private void ShareURL_Clicked(object sender, EventArgs e)
        {

        }
    }
}