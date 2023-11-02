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
using Xamarin.Essentials;

namespace C971_Isabella_Grigolla.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CourseEdit : ContentPage
	{

        private readonly int _selectedCourseId;


        protected override async void OnAppearing()
        {
            base.OnAppearing();


            int countAssessments = await DS.GetAssessmentCountAsync(_selectedCourseId);

            //string totalAssessments = countAssessments.ToString();

            AssessmentCollectionView.ItemsSource = await DS.GetAssessments(_selectedCourseId);




        }
        public CourseEdit ()
		{
			InitializeComponent ();
        }

        public CourseEdit(CourseView selectedCourse)
        { 
            InitializeComponent();

            //long cIP = Convert.ToInt64(CourseInstructorPhone);

            _selectedCourseId = selectedCourse.Id;

            CourseID.Text = selectedCourse.Id.ToString();
            CourseName.Text = selectedCourse.Name;
            CourseStatusPicker.SelectedItem = selectedCourse.Status;
            StartDatePicker.Date = selectedCourse.StartDate;
            EndDatePicker.Date = selectedCourse.EndDate;
            CourseInstructorName.Text = selectedCourse.CourseInstructorName;
            CourseInstructorPhone.Text = selectedCourse.CourseInstructorPhone;
            CourseInstructorEmail.Text = selectedCourse.CourseInstructorEmail;
            NotesFolders.Text = selectedCourse.Notes;
            Notifications.IsToggled = selectedCourse.Notifications;

        }


        async void DeleteCourse_Clicked(object sender, EventArgs e)
        {
            var selected = await DisplayAlert("Delete this course?", "Are you sure?", "Yes", "No");

            if (selected == true)
            {
                var id = int.Parse(CourseID.Text);

                await DS.RemoveCourse(id);

                await DisplayAlert("Course has been deleted.", "Course has been deleted.", "Ok");

            }

            else 
            {
                await DisplayAlert("Deletion Cancelled", "Course has not been deleted.", "Ok");
            }

            await Navigation.PopAsync();

        }

        async void CancelCourse_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void SaveCourse_Clicked(object sender, EventArgs e)
        {

            


            if (string.IsNullOrWhiteSpace(CourseName.Text))
            {
                await DisplayAlert("Missing Course Name", "Please enter a name for this course.", "Ok");
                return;
            }

            
            if (CourseStatusPicker.SelectedItem == null)
            {
                await DisplayAlert("Missing Status", "Please select a value", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(CourseInstructorName.Text)) 
            {
                await DisplayAlert("Missing Course Insructor Name", "Please enter a name for your course instructor.", "Ok");
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
                await DisplayAlert("Missing Course Insructor Email", "Please enter an email for your course instructor.", "Ok");
                return;
            }

            if (StartDatePicker.Date > EndDatePicker.Date)
            {
                await DisplayAlert("End date cannot be before Start date.", "Please change the dates.", "Ok");
                return;
            }

            

            await DS.UpdateCourses(Int32.Parse(CourseID.Text), CourseName.Text, StartDatePicker.Date, EndDatePicker.Date, CourseStatusPicker.SelectedItem.ToString(), CourseInstructorName.Text, CourseInstructorPhone.Text, CourseInstructorEmail.Text, NotesFolders.Text, Notifications.IsToggled);

            await Navigation.PopAsync();


        }
            

        

        async void ShareButton_Clicked(object sender, EventArgs e)
        {
            //var sharingText = CourseName.Text;
            var notes = NotesFolders.Text;

            await Share.RequestAsync(new ShareTextRequest
            {
                Text = notes,


                Title = "Share course notes"
            });

        }

        

        async void AddAssessment_Clicked(object sender, EventArgs e)
        {
            int countAssessments = await DS.GetAssessmentCountAsync(_selectedCourseId);

            //string totalAssessments = countAssessments.ToString();


            if (countAssessments == 2)
            {
                await DisplayAlert("Maximum number of assessments reached", "Please delete or edit the current assessments.", "Ok");
                return;
            }
            var courseId = Int32.Parse(CourseID.Text);

            await Navigation.PushAsync(new AssessmentAdd(courseId));
        }

        private async void AssessmentCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var assessment = (CourseAssessments)e.CurrentSelection.FirstOrDefault();
            if (e.CurrentSelection != null)
            {
                await Navigation.PushAsync((new AssessmentEdit(assessment)));
            }
        }
        /*
private void ShareURL_Clicked(object sender, EventArgs e)
{

}
*/
    }
}