using C971_Isabella_Grigolla.Models;
using C971_Isabella_Grigolla.Services;
using Plugin.LocalNotifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace C971_Isabella_Grigolla.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermOverview : ContentPage
    {
        public TermOverview()
        {
            InitializeComponent();
        }
        private async void AddTerm_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TermAdd());
            //this.refresh();
        }

        //private readonly int _selectedTerm;

        protected override async void OnAppearing()
        {
            base.OnAppearing();


            if (SettingC971.FirstTimeRunning)
            {
                DS.LoadSampleContent();
                SettingC971.FirstTimeRunning = false;



                await Navigation.PopToRootAsync();

            }

            Terms.ItemsSource = await DS.GetTerms();

            var classList = await DS.GetCourses();
            var notifyR = new Random();
            var notifyId = notifyR.Next(1000);

            foreach (CourseView courseR in classList)
            {
                if (courseR.Notifications == true)
                {
                    if (courseR.StartDate == DateTime.Today)
                    {
                        CrossLocalNotifications.Current.Show("WGU Notification", $"{courseR.Name} begins today.", notifyId);
                    }

                    if (courseR.EndDate == DateTime.Today)
                    {
                        CrossLocalNotifications.Current.Show("WGU Notification", $"{courseR.Name} ends today.", notifyId);
                    }
                }
            }

            
            var assessmentList = await DS.GetAssessment();
            var notifyRA = new Random();
            var notifyIdR = notifyRA.Next(1000);

            foreach (CourseAssessments assessmentsR in assessmentList)
            {
                if (assessmentsR.Notifications == true)
                {
                    if (assessmentsR.StartDate == DateTime.Today)
                    {
                        CrossLocalNotifications.Current.Show("WGU Notification", $"{assessmentsR.Name} begins today!", notifyIdR);
                    }
                    if (assessmentsR.EndDate == DateTime.Today)
                    {
                        CrossLocalNotifications.Current.Show("WGU Notification", $"{assessmentsR.Name} ends today!", notifyIdR);
                    }
                }
            }
            


        }

        private async void Settings_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AppSettings());
        }

        private async void TermOverview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                Term term = (Term)e.CurrentSelection.FirstOrDefault();
                await Navigation.PushAsync(new TermEdit(term));
            }
        }
    }

}
