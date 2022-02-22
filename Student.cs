using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SqlitePrac3
{
    [Table("student_tab")]
    public class Student
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [Column("Student_name")]
        public string name { get; set; }
        [Column("Student_age")]
        public int age { get; set; }
        [Column("Student_marks")]
        public int marks { get; set; }
        [Column("Student_roll")]
        public int rollno { get; set; }

    }
}