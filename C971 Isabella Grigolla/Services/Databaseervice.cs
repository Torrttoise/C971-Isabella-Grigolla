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


        /////////////////// Beginning of Regions ///////////////////

        #region CourseNotes methods


        public static async Task AddNotes(string title, int courseId, string description)
        {
            await init();
            var course = new CourseNotes
            {
                Title = title,
                CourseId = courseId,
                Description = description

            };

            await _datab.InsertAsync(course);

            var id = course.Id;

        }

        public static async Task RemoveNotes(int id)
        {
            await init();

            await _datab.DeleteAsync<CourseNotes>(id);
        }


        public static async Task<IEnumerable<CourseNotes>> GetNotes(int courseId)
        {
            await init();

            var notes = await _datab.Table<CourseNotes>().Where(i => i.CourseId == courseId).ToListAsync();
            return notes;
        }


        public static async Task UpdateNotes(int id, int courseId, string title, string description)
        {
            await init();

            var notesUpdateQuery = await _datab.Table<CourseNotes>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();

            if (notesUpdateQuery != null)
            {
                notesUpdateQuery.Id = id;
                notesUpdateQuery.Title = title;
                notesUpdateQuery.Description = description;

                await _datab.UpdateAsync(notesUpdateQuery);

            };

            
                    
        }



        #endregion


        #region CourseView methods

        public static async Task AddCourse(int termId, string name, DateTime startDate, DateTime endDate, string status, string courseInstructorName, int courseInstructorPhone, string couseInstructorEmail, string notes, bool notifications)
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
                CourseInstructorEmail = couseInstructorEmail,
                Notes = notes,
                Notifications = notifications
            };

            await _datab.InsertAsync(course);

            var id = course.Id;

        }

        public static async Task RemoveCourse(int id)
        {
            await init();

            await _datab.DeleteAsync<CourseView>(id);

        }


        public static async Task<IEnumerable<CourseView>> GetCourses(int termId)
        {
            await init();

            var courses = await _datab.Table<CourseView>().Where(i => i.TermId == termId).ToListAsync();
            return courses;
        }

        public static async Task UpdateCourses(int id, string name, DateTime startDate, DateTime endDate, string status, string courseInstructorName, int courseInstructorPhone, string courseInstructorEmail, string notes, bool notifications)
        {
            await init();

            var courseUpdateQuery = await _datab.Table<CourseView>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();

            if (courseUpdateQuery != null)
            {
                courseUpdateQuery.Id = id;
                courseUpdateQuery.Name = name;
                courseUpdateQuery.StartDate = startDate;
                courseUpdateQuery.EndDate = endDate;
                courseUpdateQuery.Status = status;
                courseUpdateQuery.CourseInstructorName = courseInstructorName;
                courseUpdateQuery.CourseInstructorPhone = courseInstructorPhone;
                courseUpdateQuery.CourseInstructorEmail = courseInstructorEmail;
                courseUpdateQuery.Notes = notes;
                courseUpdateQuery.Notifications = notifications;

                await _datab.UpdateAsync(courseUpdateQuery);
            }
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


        public static async Task AddAssessment(int courseId, string name, string typeOfAssessment, DateTime startDate, DateTime endDate)
        {
            await init();

            var assessment = new CourseAssessments()
            {
                CourseId = courseId,
                Name = name,
                TypeOfAssessment = typeOfAssessment,
                StartDate = startDate,
                EndDate = endDate
            };
            await _datab.InsertAsync(assessment);

            var id = assessment.Id;

        }
       

        public static async Task RemoveAssessment(int id)
        {
            await init();

            await _datab.DeleteAsync<CourseAssessments>(id);

        }


        public static async Task<IEnumerable<CourseAssessments>> GetAssessments(int courseId)
        {
            await init();

            var assessments = await _datab.Table<CourseAssessments>().Where(i => i.CourseId == courseId).ToListAsync();
            return assessments;

        }


        public static async Task UpdateAssessment(int id, int courseId, string name, string typeOfAssessment, DateTime startDate, DateTime endDate)
        {
            await init();

            var assessmentUpdateQuery = await _datab.Table<CourseAssessments>()
               .Where(i => i.Id == id)
               .FirstOrDefaultAsync();


            if (assessmentUpdateQuery != null)
            {
                assessmentUpdateQuery.Id = id;
                assessmentUpdateQuery.Name = name;
                assessmentUpdateQuery.TypeOfAssessment = typeOfAssessment;
                assessmentUpdateQuery.StartDate = startDate;
                assessmentUpdateQuery.EndDate = endDate;

                await _datab.UpdateAsync(assessmentUpdateQuery);
            }


        }


        #endregion


        #region Demo Information

        public static async void LoadSampleData()
        {
            await init();


            Term term1 = new Term
            {

                Name = "Term 1",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(4),
            };

            await _datab.InsertAsync(term1);

                    CourseView course1 = new CourseView
                    {
                        TermId = term1.Id,
                        Name = "Course 1",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddMonths(1),
                        Status = "In Progress",
                        CourseInstructorId = 3,
                        CourseInstructorName = "Isabella Grigolla",
                        CourseInstructorPhone = 626-253-7474,
                        CourseInstructorEmail = "igrigol@wgu.edu"

                    };
                
                        CourseNotes notes1 = new CourseNotes
                        {
                            CourseId = course1.Id,
                            Title = "Steps on continuing towards progress.",
                            Description = "1.Test /n 2.Knowledge /n 3.Marriage /n"
                        };

                        CourseAssessments assessment1 = new CourseAssessments
                        {
                            CourseId = course1.Id,
                            Name = "Title of Practice Assessment",
                            TypeOfAssessment = "PA",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddMonths(1)

                        };

                        CourseAssessments assessment2 = new CourseAssessments
                        {
                            CourseId = course1.Id,
                            Name = "Title of Objective Assessment",
                            TypeOfAssessment = "OA",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddMonths(1)
                        };

                    CourseView course2 = new CourseView
                    {
                        TermId = term1.Id,
                        Name = "Course 2",
                        StartDate = DateTime.Now.AddMonths(2),
                        EndDate = DateTime.Now.AddMonths(3),
                        Status = "Planned",
                        CourseInstructorId = 3,
                        CourseInstructorName = "Isabella Grigolla",
                        CourseInstructorPhone = 626 - 253 - 7474,
                        CourseInstructorEmail = "igrigol@wgu.edu"

                    };

                        CourseNotes notes2 = new CourseNotes
                        {
                            CourseId = course2.Id,
                            Title = "I am a note from the future.",
                            Description = "October 25th 1985."
                        };

                        CourseAssessments assessment3 = new CourseAssessments
                        {
                            CourseId = course2.Id,
                            Name = "Title of Practice Assessment",
                            TypeOfAssessment = "PA",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddMonths(1)

                        };

                        CourseAssessments assessment4 = new CourseAssessments
                        {
                            CourseId = course2.Id,
                            Name = "Title of Objective Assessment",
                            TypeOfAssessment = "OA",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddMonths(1)
                        };


                    CourseView course3 = new CourseView
                    {
                        TermId = term1.Id,
                        Name = "Course 3",
                        StartDate = DateTime.Now.AddMonths(-2),   ////Test of negative addition to add months.
                        EndDate = DateTime.Now.AddMonths(-3),
                        Status = "Completed",
                        CourseInstructorId = 3,
                        CourseInstructorName = "Isabella Grigolla",
                        CourseInstructorPhone = 626 - 253 - 7474,
                        CourseInstructorEmail = "igrigol@wgu.edu"

                    };

            /*
                    CourseView course4 = new CourseView
                    {
                        TermId = term1.Id,
                        Name = "Course 4",
                        StartDate = DateTime.Now.AddMonths(-2) ,   ////Test of negative addition to add months.
                        EndDate = DateTime.Now.AddMonths(-3),
                        Status = "Completed",
                        CourseInstructorId = 3,
                        CourseInstructorName = "Isabella Grigolla",
                        CourseInstructorPhone = 626 - 253 - 7474,
                        CourseInstructorEmail = "igrigol@wgu.edu"

                    };
            */

        }

        public static async Task WipeSampleData()
        {
            await init();

            await _datab.DropTableAsync<Term>();
            await _datab.DropTableAsync<CourseView>();
            await _datab.DropTableAsync<CourseNotes>();
            await _datab.DropTableAsync<CourseAssessments>();

            _datab = null;

            _databConnection = null;

        }

        /*
        public static async void LoadSampleDataSql()
        {

        }
        */

        #endregion



        #region Counts

        public static async Task<int> GetCourseCountAsync(int selectedTermId)
        {
            int courseCounts = await _datab.ExecuteScalarAsync<int>($"Select Count(*) from CourseView where TermId = ?", selectedTermId);

            return courseCounts;
        }



        #endregion

        /////////////////// End of Regions ///////////////////

    }
}
