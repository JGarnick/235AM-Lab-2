using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace HelloMultiScreen
{
    [Activity(Label = "SecondActivity", ParentActivity = typeof(FirstActivity))]
    //[MetaData(NavUtils.ParentActivity, Value = ".FirstActivity")]
    public class SecondActivity : Activity
    {
        int _counter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //Track number of times activity has been started

            if (savedInstanceState != null)
            {
                _counter = savedInstanceState.GetInt("created_count", 0);
            }
            _counter++;
            // Create your application here
            SetContentView(Resource.Layout.Second);
            ActionBar.SetDisplayShowHomeEnabled(true);

            var label = FindViewById<TextView>(Resource.Id.screen2Label);
            var firstData = Intent.GetBooleanExtra("Data", false);
            
            if (firstData == true)
            {
                label.Text = "Screen 1 poked you!";
            }
            else
                label.Text = Intent.GetStringExtra("Data") ?? "Data not available";
        }
        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutInt("created_count", _counter);
            
            base.OnSaveInstanceState(outState);
        }

        protected void OnPause(Bundle outState)
        {
            base.OnPause();
            OnSaveInstanceState(outState);
        }

        protected void OnStop(Bundle outState)
        {
            base.OnStop();
            OnSaveInstanceState(outState);
        }
    }
}