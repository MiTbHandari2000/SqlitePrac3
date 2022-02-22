using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Environment = System.Environment;

namespace SqlitePrac3
{
    public class database
    {
        Context _context;
        public static string DBname = "SQLite.db4";
        public static string DBPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), DBname);

        SQLiteConnection sqliteConnection;
        public database(Context context)
        {
            _context = context;
            sqliteConnection = new SQLiteConnection(DBPath);
            Console.WriteLine("Succefully Database Created!....");
        }
        public void createtable()
        {
            try
            {
                var created = sqliteConnection.CreateTable<Student>();
                Console.WriteLine("Table created successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception causede" + ex.Message);
            }
        }
        public bool insert(Student student)
        {
            long res = sqliteConnection.Insert(student);
            if (res == -1)
            {
                Toast.MakeText(_context, res.ToString(), ToastLength.Short).Show();
                return false;
            }
            else
            {
                Toast.MakeText(_context, "Data inserted", ToastLength.Short).Show();
                return true;
            }
        }
        public List<Student> alldata()
        {
            try
            {
                var list = sqliteConnection.Table<Student>().ToList();
                return list;
            }
            catch (Exception ex)
            {
                Toast.MakeText(_context, ex.Message, ToastLength.Short).Show();
                return null;
            }
        }

        public Student GetByRollno(int roll)
        {
            var userId = sqliteConnection.Table<Student>().Where(u => u.rollno == roll).FirstOrDefault();

            return userId;

        }

    }
}