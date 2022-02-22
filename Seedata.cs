using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AndroidX.RecyclerView.Widget;
namespace SqlitePrac3
{
    [Activity(Label = "Seedata")]
    public class Seedata : Activity
    {
        readapter read;
        RecyclerView.LayoutManager myLayoutmanager;
        database datae;
        RecyclerView recyclerView;
        List<Student> studentslist;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.seelayout);
            datae = new database(this);
            studentall();
            recyclerView = FindViewById<RecyclerView>(Resource.Id.recycler);
            myLayoutmanager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(myLayoutmanager);
            read = new readapter(this, studentslist);
            recyclerView.SetAdapter(read);

        }

        public List<Student> studentall()
        {
            datae = new database(this);
            var student = datae.alldata();
            studentslist = new List<Student>();
            studentslist.AddRange(student);
            return studentslist;
        }
    }
}