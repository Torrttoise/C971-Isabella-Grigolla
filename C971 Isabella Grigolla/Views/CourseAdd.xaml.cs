﻿using C971_Isabella_Grigolla.Models;
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
            decimal tossedDecimal;
            int tossedInt;

            if (string.IsNullOrWhiteSpace(ClassName.Text))
            {
                await DisplayAlert("Missing Name", "Please Enter a name for the Course.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(ClassStatusPicker.SelectedItem.ToString()))
            {
                await DisplayAlert("Missing Status", "Please select a value", "OK");
                return;
            }

            if(string.IsNullOrWhiteSpace(CourseInstructorName.Text))
            {
                await DisplayAlert("Missing Course Instructor Name", "Please Enter a name for your course Instructor.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(CourseInstructorPhone.Text))
            {
                await DisplayAlert("Missing Course Instructor Phone Number", "Please Enter a number for your course Instructor.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(CourseInstructorEmail.Text))
            {
                await DisplayAlert("Missing Course Instructor Email", "Please Enter an email address for your course Instructor.", "OK");
                return;
            }

            await Databaseervice.UpdateTerm(Int32.Parse(TermID.Text), ClassName.Text, DateTime.Parse(StartDatePicker.Date.ToString()), DateTime.Parse(EndDatePicker.Date.ToString()));

            await Navigation.PopAsync();
        }

        private void CancelCourse_Clicked(object sender, EventArgs e)
        {

        }

        private void Home_Clicked(object sender, EventArgs e)
        {

        }
    }
}