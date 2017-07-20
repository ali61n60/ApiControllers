using Android.App;
using Android.Widget;
using Android.OS;

namespace ApiCaller
{
    [Activity(Label = "ApiCaller", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button _button1;
        private TextView _textView1;
        private int _numberOfClicks;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            initFields();
        }

        private void initFields()
        {
            _button1 = FindViewById<Button>(Resource.Id.button1);
            _button1.Click += (sender, args) =>
            {
                _numberOfClicks++;
                _textView1.Text = "Number of clicks: " + _numberOfClicks;
            };
            _textView1 = FindViewById<TextView>(Resource.Id.textView1);
        }
    }
}

