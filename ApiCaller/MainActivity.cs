using System;
using System.IO;
using System.Json;
using System.Net;
using System.Threading.Tasks;
using Android.App;
using Android.Widget;
using Android.OS;
//https://developer.xamarin.com/recipes/android/web_services/consuming_services/call_a_rest_web_service/
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
            _button1.Click += async (sender, e) => {

                // Get the latitude and longitude entered by the user and create a query.
                string url = "http://192.168.42.76/api/Reservation";

                // Fetch the weather information asynchronously, 
                // parse the results, then update the screen:
                JsonValue json = await FetchWeatherAsync(url);
                _textView1.Text = json.ToString();
                // ParseAndDisplay (json);
            };
            _textView1 = FindViewById<TextView>(Resource.Id.textView1);
        }
        private async Task<JsonValue> FetchWeatherAsync(string url)
        {
            // Create an HTTP web request using the URL:
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = "GET";

            // Send the request to the server and wait for the response:
            using (WebResponse response = await request.GetResponseAsync())
            {
                // Get a stream representation of the HTTP web response:
                using (Stream stream = response.GetResponseStream())
                {
                    // Use this stream to build a JSON document object:
                    JsonValue jsonDoc = await Task.Run(() => JsonObject.Load(stream));
                    Console.Out.WriteLine("Response: {0}", jsonDoc.ToString());

                    // Return the JSON document:
                    return jsonDoc;
                }
            }
        }
    }
}

