using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using Android.Content;

namespace SqlitePrac3
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText name, roll, marks;
        Button Add, viewall, view, modify, delete;
        database dat;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            name = FindViewById<EditText>(Resource.Id.namedit);
            roll = FindViewById<EditText>(Resource.Id.rolledit);
            marks = FindViewById<EditText>(Resource.Id.marksedit);
            Add = FindViewById<Button>(Resource.Id.addbutton);
            viewall = FindViewById<Button>(Resource.Id.viewallbutton);
            view = FindViewById<Button>(Resource.Id.viewbutton);
            modify = FindViewById<Button>(Resource.Id.modifybutton);
            delete = FindViewById<Button>(Resource.Id.deletebutton);
            dat = new database(this);
            viewall.Click += Viewall_Click;
            Add.Click += Add_Click;
            view.Click += View_Click;
            dat.createtable();

        }

        private void View_Click(object sender, System.EventArgs e)
        {
            string nam = name.Text;
            string rol = roll.Text;
            string mar = marks.Text;
            if (nam == string.Empty && rol == string.Empty && mar == string.Empty)
            {
                Toast.MakeText(this, "fields cant be empty", ToastLength.Short).Show();
            }
            else
            {
                Student onestd = dat.GetByRollno(int.Parse(rol));
                string na = onestd.name;
                string ro = onestd.rollno.ToString();
                string ma = onestd.marks.ToString();
                Intent intent = new Intent(this, typeof(showone));
                intent.PutExtra("name", na);
                intent.PutExtra("roll", ro);
                intent.PutExtra("mark", ma);
                StartActivity(intent);
            }
        }

        private void Viewall_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Seedata));
            StartActivity(intent);
        }

        private void Add_Click(object sender, System.EventArgs e)
        {
            Student student = new Student();
            student.name = name.Text;
            student.marks = int.Parse(marks.Text);
            student.rollno = int.Parse(roll.Text);
            bool result = dat.insert(student);

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}