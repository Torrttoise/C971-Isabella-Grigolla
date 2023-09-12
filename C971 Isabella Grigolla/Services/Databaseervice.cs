using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SQLite;
using Xamarin.Essentials;
using C971_Isabella_Grigolla.Models;
using Xamarin.Forms;

namespace C971_Isabella_Grigolla.Services
{
    public static class Databaseervice
    {
        private static SQLiteAsyncConnection _datab;
        private static SQLiteConnection _databConnection;

        static async Task init()
        {
            if (_datab == null)
            {
                return;
            }

            var pathOfDataBase = Path.Combine(FileSystem.AppDataDirectory, "C971_Services.db");


            _datab = new SQLiteAsyncConnection(pathOfDataBase);
            _databConnection = new SQLiteConnection(pathOfDataBase);


            await _datab.CreateTableAsync<CourseNotes>();
            await _datab.CreateTableAsync<CourseView>();
            await _datab.CreateTableAsync<Term>();
            await _datab.CreateTableAsync<CourseAssessments>();



        }




        #region CourseNotes methods


        public static async Task AddNotes(string title, string description)
        {
            await init();
        }

        public static async Task RemoveNotes(int id)
        {
            await init();
        }


        public static async Task GetNotes()
        {
            await init();
        }


        public static async Task UpdateNotes(int id, string title, string description)
        {
            await init();
        }



        #endregion


        #region CourseView methods

        public static async Task AddCourse(int termId, string name, DateTime startDate, DateTime endDate, Picker status, string courseInstructorName, int courseInstructorPhone, string couseInstructorEmail)
        {
            await init();
            var course = new CourseView
            {
                TermId = termId,
                Name = name,
                StartDate = startDate,
                EndDate = endDate,
                Status = status,
                CourseInstructorName = courseInstructorName,
                CourseInstructorPhone = courseInstructorPhone,
                CourseInstructorEmail = couseInstructorEmail
            };

            await _datab.InsertAsync(course);

            var id = course.Id;

        }

        public static async Task RemoveCourse(int id)
        {
            await init();
        }


        public static async Task GetCourses()
        {
            await init();
        }

        public static async Task UpdateCourses(int id, string name, DateTime startDate, DateTime endDate, Picker status, string courseInstructorName, int courseInstructorPhone, string couseInstructorEmail)
        {
            await init();
        }




        #endregion



        #region TermOverview methods

        public static async Task AddTerm(string name, DateTime startDate, DateTime endDate)
        {
            await init();

            var term = new Term()
            {
                Name = name,
                StartDate = startDate,
                EndDate = endDate,
            };
            await _datab.InsertAsync(term);

            var id = term.Id;

        }

        public static async Task RemoveTerm(int id)
        {
            await init();


            await _datab.DeleteAsync<Term>(id);
        }

        public static async Task<IEnumerable<Term>> GetTerms()
        {
            await init();

            var terms = await _datab.Table<Term>().ToListAsync();
            return terms;
        }

        public static async Task UpdateTerm(int id, string name, DateTime startDate, DateTime endDate)
        {
            await init();

            var termUpdateQuery = await _datab.Table<Term>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();


            if (termUpdateQuery != null)
            {
                termUpdateQuery.Id = id;
                termUpdateQuery.Name = name;
                termUpdateQuery.StartDate = startDate;
                termUpdateQuery.EndDate = endDate;

                await _datab.UpdateAsync(termUpdateQuery);
            }


        }

        #endregion


        #region CourseAssessment methods


        public static async Task AddAssessment(int courseId, string name, Picker typeOfAssessment, DateTime startDate, DateTime endDate)
        {
            await init();
        }
       

        public static async Task RemoveAssessment(int id)
        {
            await init();
        }


        public static async Task GetAssessments()
        {
            await init();
        }


        public static async Task UpdateAssessment(int id, int courseId, string name, Picker typeOfAssessment, DateTime startDate, DateTime endDate)
        {
            await init();
        }
         

        #endregion


    }
}
