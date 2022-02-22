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

namespace SqlitePrac3
{
    [Activity(Label = "showone")]
    public class showone : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.showone);
            if (Intent.Extras != null)
            {

                string name = Intent.Extras.GetInt(key: "name", 0);

                if (message != 0)
                {


                }
            }
        }
    }
}