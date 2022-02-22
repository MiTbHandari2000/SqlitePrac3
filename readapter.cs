using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlitePrac3
{
    public class readapter : RecyclerView.Adapter
    {
        public Seedata Seedata;
        public List<Student> Studentslist;
        studentdataholder dataholder;
        public readapter(Seedata seedata, List<Student> studentslist)
        {
            Seedata = seedata;
            Studentslist = studentslist;
        }

        public override int ItemCount => Studentslist.Count;



        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            dataholder = holder as studentdataholder;
            dataholder.Binddata(Studentslist[position]);
            //dataholder.container.Click += (s, e) =>
            //{

            //};
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.rowlayout, parent, false);
            return new studentdataholder(view);
        }
    }
    class studentdataholder : RecyclerView.ViewHolder
    {
        public TextView rollno, name, marks;
        public LinearLayout container;
        public studentdataholder(View itemView) : base(itemView)
        {
            rollno = itemView.FindViewById<TextView>(Resource.Id.rollans);
            name = itemView.FindViewById<TextView>(Resource.Id.nameans);
            marks = itemView.FindViewById<TextView>(Resource.Id.marksans);
            container = itemView.FindViewById<LinearLayout>(Resource.Id.container);
        }

        public void Binddata(Student student)
        {

            rollno.Text = student.rollno.ToString();
            name.Text = student.name.ToString();
            marks.Text = student.marks.ToString();
        }
    }

}