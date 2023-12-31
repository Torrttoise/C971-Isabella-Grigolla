﻿using SQLite;
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
        //public List<string> Status { get; set; }
        public string Status { get; set; }

        /*
        public void pickerSource()
        {
            var pickerList = new List<string>();
            pickerList.Add("In Progress");
            pickerList.Add("Planned");
            pickerList.Add("Completed");

            Status = pickerList;
        }
        */
        public int CourseInstructorId { get; set; }
        public string CourseInstructorName { get; set; }
        public string CourseInstructorPhone { get; set; }
        public string CourseInstructorEmail { get; set; }
        public string Notes { get; set; }
        public bool Notifications { get; set; }
        public DateTime DateofCreation { get; set; }

        //private static SQLiteAsyncConnection _datab;

    }

}
  