using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System;
using System.Json;
using System.Collections.Generic;
using static Android.Provider.SyncStateContract;

namespace AndroidRadioButton
{
    [Activity(Label = "AndroidRadioButton", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var firstans = FindViewById<RadioGroup>(Resource.Id.radioGroup1);
            var secans = FindViewById<RadioGroup>(Resource.Id.radioGroup2);
            var thirdans = FindViewById<RadioGroup>(Resource.Id.radioGroup3);

            var btnStart = FindViewById<Button>(Resource.Id.btnstart);
            btnStart.Click += (s, e) =>
            {
                Intent secondActivity = new Intent(this, typeof(SecondActivity));
                //secondActivity.PutExtra("firstans");
                StartActivity(secondActivity);
            };
        }

        public class Questions
        {
            int Id { get; set; }
            string Question1 { get; set; }
            string Question2 { get; set; }
            string Question3 { get; set; }
            string Question4 { get; set; }
            string Question5 { get; set; }
            string Question6 { get; set; }
            string Question7 { get; set; }
        }

        public async Task<string> GetItems()
        {
            var client = new HttpClient();

            var result = await client.GetStringAsync("http://10.0.2.2/WebAPI/api/Answers");

            return result;
        }
    }
}

