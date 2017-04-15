using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace HelloMultiScreen
{
    [Activity(Label = "HelloMultiScreen", MainLauncher = true, Icon = "@drawable/icon")]
    public class FirstActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            Intent second;
            base.OnCreate(bundle);
            //Use UI created in Main.axml
            SetContentView(Resource.Layout.Main);
            var pokeSecond = FindViewById<Button>(Resource.Id.pokeSecond);
            pokeSecond.Click += (sender, e) => {
                second = new Intent(this, typeof(SecondActivity));
                second.PutExtra("Data", true);
                StartActivity(second);
            };

            var hiToSecond = FindViewById<Button>(Resource.Id.hiToSecond);
            hiToSecond.Click += (sender, e) => {
                second = new Intent(this, typeof(SecondActivity));
                second.PutExtra("Data", "Hi from screen 1!");
                StartActivity(second);
            };
        }
    }
}

