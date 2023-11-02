using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SQLite;
using Xamarin.Essentials;
using C971_Isabella_Grigolla.Services;
using C971_Isabella_Grigolla.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.LocalNotifications;


namespace C971_Isabella_Grigolla.Services
{
    public static class Databaseervice
    {
        private static SQLiteAsyncConnection _datab;
        private static SQLiteConnection _databConnection;

        static async Task init()
        {
            if (_datab != null)
            {
                return;
            }

            var pathOfDataBase = Path.Combine(FileSystem.AppDataDirectory, "TermInfo.db");


            _datab = new SQLiteAsyncConnection(pathOfDataBase);
            _databConnection = new SQLiteConnection(pathOfDataBase);

            await _datab.CreateTableAsync<Term>();
            await _datab.CreateTableAsync<CourseView>();
            await _datab.CreateTableAsync<CourseAssessments>();



        }


        /////////////////// Beginning of Regions ///////////////////

       

        #region CourseView methods

        public static async Task AddCourse(int termId, string name, DateTime startDate, DateTime endDate, string status, string courseInstructorName, string courseInstructorPhone, string couseInstructorEmail, string notes, bool notifications)
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

        public static async Task<IEnumerable<CourseView>> GetCourses()
        {
            await init();

            var courses = await _datab.Table<CourseView>().ToListAsync();
            return courses;
        }


        public static async Task<IEnumerable<CourseView>> GetCourses(int termId)
        {
            await init();

            var courses = await _datab.Table<CourseView>().Where(i => i.TermId == termId).ToListAsync();
            return courses;
        }


        

        public static async Task UpdateCourses(int id, string name, DateTime startDate, DateTime endDate, string status, string courseInstructorName, string courseInstructorPhone, string courseInstructorEmail, string notes, bool notifications)
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


        public static async Task AddAssessment(int courseId, string name, string typeOfAssessment, DateTime startDate, DateTime endDate, bool notification)
        {
            await init();

            var assessment = new CourseAssessments()
            {
                CourseId = courseId,
                Name = name,
                TypeOfAssessment = typeOfAssessment,
                StartDate = startDate,
                EndDate = endDate,
                Notifications = notification
            };
            await _datab.InsertAsync(assessment);

            var id = assessment.Id;

        }

        public static async Task RemoveAssessment(int id)
        {
            await init();

            await _datab.DeleteAsync<CourseAssessments>(id);

        }

        public static async Task<IEnumerable<CourseAssessments>> GetAssessment()
        {
            await init();

            var assessment = await _datab.Table<CourseAssessments>().ToListAsync();
            return assessment;
        }

        public static async Task<IEnumerable<CourseAssessments>> GetAssessments(int courseId)
        {
            await init();

            var assessments = await _datab.Table<CourseAssessments>().Where(i => i.CourseId == courseId).ToListAsync();
            return assessments;

        }

        public static async Task UpdateAssessment(int id, string name, string typeOfAssessment, DateTime startDate, DateTime endDate, bool notification)
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
                assessmentUpdateQuery.Notifications = notification;

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
                StartDate = DateTime.Now.AddMonths(-4),
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
                        CourseInstructorPhone = "626-253-7474",
                        CourseInstructorEmail = "igrigol@wgu.edu"

                    };
                    await _datab.InsertAsync(course1);

                        CourseAssessments assessment1 = new CourseAssessments
                        {
                            CourseId = course1.Id,
                            Name = "Title of Practice Assessment",
                            TypeOfAssessment = "Perfomance Assessment",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddMonths(1)

                        };
                        await _datab.InsertAsync(assessment1);

                        CourseAssessments assessment2 = new CourseAssessments
                        {
                            CourseId = course1.Id,
                            Name = "Title of Objective Assessment",
                            TypeOfAssessment = "Objective Assessment",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddMonths(1)
                        };
                        await _datab.InsertAsync(assessment2);

            // _____________________________________

                    CourseView course2 = new CourseView
                    {
                        TermId = term1.Id,
                        Name = "Course 2",
                        StartDate = DateTime.Now.AddMonths(2),
                        EndDate = DateTime.Now.AddMonths(3),
                        Status = "Upcoming",
                        CourseInstructorId = 3,
                        CourseInstructorName = "Isabella Grigolla",
                        CourseInstructorPhone = "626-253-7474",
                        CourseInstructorEmail = "igrigol@wgu.edu"

                    };
                    await _datab.InsertAsync(course2);

                        CourseAssessments assessment3 = new CourseAssessments
                        {
                            CourseId = course2.Id,
                            Name = "Title of Practice Assessment",
                            TypeOfAssessment = "PA",
                            StartDate = DateTime.Now.AddMonths(2),
                            EndDate = DateTime.Now.AddMonths(3)

                        };
                        await _datab.InsertAsync(assessment3);

                        CourseAssessments assessment4 = new CourseAssessments
                        {
                            CourseId = course2.Id,
                            Name = "Title of Objective Assessment",
                            TypeOfAssessment = "OA",
                            StartDate = DateTime.Now.AddMonths(2),
                            EndDate = DateTime.Now.AddMonths(3)
                        };
                        await _datab.InsertAsync(assessment4);
             // _____________________________________

                    CourseView course3 = new CourseView
                    {
                        TermId = term1.Id,
                        Name = "Course 3",
                        StartDate = DateTime.Now.AddMonths(-2),   ////Test of negative addition to add months.
                        EndDate = DateTime.Now.AddMonths(-3),
                        Status = "Completed",
                        CourseInstructorId = 3,
                        CourseInstructorName = "Isabella Grigolla",
                        CourseInstructorPhone = "626-253-7474",
                        CourseInstructorEmail = "igrigol@wgu.edu"

                    };
                    await _datab.InsertAsync(course3);

                           CourseAssessments assessment5 = new CourseAssessments
                        {
                            CourseId = course3.Id,
                            Name = "Title of Practice Assessment",
                            TypeOfAssessment = "Perfomance Assessment",
                            StartDate = DateTime.Now.AddMonths(-2),
                            EndDate = DateTime.Now.AddMonths(-3)

                        };
                        await _datab.InsertAsync(assessment5);

                        CourseAssessments assessment6 = new CourseAssessments
                        {
                            CourseId = course3.Id,
                            Name = "Title of Objective Assessment",
                            TypeOfAssessment = "Objective Assessment",
                            StartDate = DateTime.Now.AddMonths(-2),
                            EndDate = DateTime.Now.AddMonths(-3)
                        };
                        await _datab.InsertAsync(assessment6);
           // _____________________________________
                    CourseView course4 = new CourseView
                    {
                        TermId = term1.Id,
                        Name = "Course 4",
                        StartDate = DateTime.Now.AddMonths(-3) ,   ////Test of negative addition to add months.
                        EndDate = DateTime.Now.AddMonths(-4),
                        Status = "Completed",
                        CourseInstructorId = 3,
                        CourseInstructorName = "Isabella Grigolla",
                        CourseInstructorPhone = "626-253-7474",
                        CourseInstructorEmail = "igrigol@wgu.edu"

                    };
                    await _datab.InsertAsync(course4);
                             CourseAssessments assessment7 = new CourseAssessments
                        {
                                 CourseId = course4.Id,
                                 Name = "Title of Practice Assessment",
                                 TypeOfAssessment = "Practice Assessment",
                                 StartDate = DateTime.Now.AddMonths(-3),
                                 EndDate = DateTime.Now.AddMonths(-4)

                             };
                        await _datab.InsertAsync(assessment7);

                        CourseAssessments assessment8 = new CourseAssessments
                        {
                            CourseId = course4.Id,
                            Name = "Title of Objective Assessment",
                            TypeOfAssessment = "Objective Assessment",
                            StartDate = DateTime.Now.AddMonths(-3),
                            EndDate = DateTime.Now.AddMonths(-4)
                        };
                        await _datab.InsertAsync(assessment8);
           // _____________________________________

            
                    CourseView course5 = new CourseView
                    {
                        TermId = term1.Id,
                        Name = "Course 5",
                        StartDate = DateTime.Now.AddMonths(2) ,
                        EndDate = DateTime.Now.AddMonths(3),
                        Status = "Upcoming",
                        CourseInstructorId = 3,
                        CourseInstructorName = "Isabella Grigolla",
                        CourseInstructorPhone = "626-253-7474",
                        CourseInstructorEmail = "igrigol@wgu.edu"

                    };
                    await _datab.InsertAsync(course5);
                    CourseAssessments assessment9 = new CourseAssessments
                        {
                                 CourseId = course5.Id,
                                 Name = "Title of Practice Assessment",
                                 TypeOfAssessment = "Practice Assessment",
                                 StartDate = DateTime.Now.AddMonths(2),
                                 EndDate = DateTime.Now.AddMonths(3)

                             };
                        await _datab.InsertAsync(assessment9);

                        CourseAssessments assessment10 = new CourseAssessments
                        {
                            CourseId = course5.Id,
                            Name = "Title of Objective Assessment",
                            TypeOfAssessment = "Objective Assessment",
                            StartDate = DateTime.Now.AddMonths(2),
                            EndDate = DateTime.Now.AddMonths(3)
                        };
                        await _datab.InsertAsync(assessment10);
            //__________________________________________________


            CourseView course6 = new CourseView
            {
                TermId = term1.Id,
                Name = "Course 6",
                StartDate = DateTime.Now.AddMonths(3),
                EndDate = DateTime.Now.AddMonths(3),
                Status = "Upcoming",
                CourseInstructorId = 3,
                CourseInstructorName = "Isabella Grigolla",
                CourseInstructorPhone = "626-253-7474",
                CourseInstructorEmail = "igrigol@wgu.edu"

            };
            await _datab.InsertAsync(course6);

            CourseAssessments assessment11 = new CourseAssessments
            {
                CourseId = course5.Id,
                Name = "Title of Practice Assessment",
                TypeOfAssessment = "Practice Assessment",
                StartDate = DateTime.Now.AddMonths(3),
                EndDate = DateTime.Now.AddMonths(3)

            };
            await _datab.InsertAsync(assessment11);

            CourseAssessments assessment12 = new CourseAssessments
            {
                CourseId = course5.Id,
                Name = "Title of Objective Assessment",
                TypeOfAssessment = "Objective Assessment",
                StartDate = DateTime.Now.AddMonths(3),
                EndDate = DateTime.Now.AddMonths(3)
            };
            await _datab.InsertAsync(assessment12);

        }

        public static async Task WipeSampleData()
        {
            await init();

            await _datab.DropTableAsync<Term>();
            await _datab.DropTableAsync<CourseView>();
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

        public static async Task<int> GetAssessmentCountAsync(int selectedCourseId)
        {
            int assessmentCounts = await _datab.ExecuteScalarAsync<int>($"Select Count(*) from CourseAssessments where CourseId = ?", selectedCourseId);

            return assessmentCounts;
        }



        #endregion



        #region   Loop

        public static async void loopTermTable()
        {
            await init();

            var atermRecord = _databConnection.Query<Term>("SELECT * FROM Term");
            foreach(var termR in atermRecord)
            {
                Console.WriteLine("Name " + termR.Name);
            }

        }

        public static async Task<List<Term>> GetNotifTermAsync()
        {
            await init();

            var record = _databConnection.Query<Term>("Select * FROM Term");

            return record;

        }


        public static async Task<IEnumerable<Term>> GetTermNotification()
        {
            await init();

            var allTerms = _databConnection.Query<Term>("SELECT * FROM Term");

            return allTerms;



        }


        #endregion


        /////////////////// End of Regions ///////////////////

    }
}
