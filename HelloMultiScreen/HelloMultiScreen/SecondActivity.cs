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
    public class SecondActivity : Activity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
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
                label.Text = Intent.GetStringExtra("Data") ?? "Data not available";        }
    }
}