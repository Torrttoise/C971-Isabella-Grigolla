using SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace C971_Isabella_Grigolla.Models
{
    public class CourseView
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }
        public int TermId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Picker Status { get; set; }
        public int CourseInstructorId { get; set; }
        public string CourseInstructorName { get; set; }
        public int CourseInstructorPhone { get; set; }
        public string CourseInstructorEmail { get; set; }





    }
}
