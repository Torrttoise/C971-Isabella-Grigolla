using SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace C971_Isabella_Grigolla.Models
{
    public class CourseAssessments
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }
        public int CourseId { get; set;}
        public string Name { get; set; }
        public Picker TypeOfAssessment { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        //public DateTime StartDatePA { get; set; }
        //public DateTime EndDatePA { get; set;}



    }
}
