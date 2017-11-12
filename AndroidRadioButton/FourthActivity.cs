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
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;

namespace AndroidRadioButton
{
    [Activity(Label = "Fourth")]
    public class FourthActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Fourth);

            var btnPrev = FindViewById<Button>(Resource.Id.fourthprev);
            var btnsubmit = FindViewById<Button>(Resource.Id.submit);

            btnPrev.Click += (s, e) =>
            {
                Intent thirdActivity = new Intent(this, typeof(ThirdActivity));
                StartActivity(thirdActivity);
            };

            btnsubmit.Click += async (sender, e) =>
            {
                string firstans = Intent.GetStringExtra("firstans" ?? "Not Received");
                string secondans = Intent.GetStringExtra("secondans" ?? "Not Received");
                string thirdans = Intent.GetStringExtra("thirdans" ?? "Not Received");
                string fourthans = Intent.GetStringExtra("fourthans" ?? "Not Received");
                string fifthans = Intent.GetStringExtra("fifthans" ?? "Not Received");
                string sixthans = Intent.GetStringExtra("sixthans" ?? "Not Received");
                RadioGroup radioGroupSeven = FindViewById<RadioGroup>(Resource.Id.radioGroup7);
                RadioButton checkedradiobutton7 = FindViewById<RadioButton>(radioGroupSeven.CheckedRadioButtonId);
                string seventhans = checkedradiobutton7.Text;
                string json = await SubmitQuestions(firstans, secondans, thirdans, fourthans, fifthans, sixthans, seventhans);

                Intent mainActivity = new Intent(this, typeof(MainActivity));
                StartActivity(mainActivity);
            };

        }

        public async Task<string> SubmitQuestions(string firstans, string secondans, string thirdans, string fourthans, string fifthans, string sixthans, string seventhans)
        {
            object userInfos = new {
                QuestionOne = firstans,
                QuestionTwo = secondans,
                QuestionThree = thirdans,
                QuestionFour = fourthans,
                QuestionFive = fifthans,
                QuestionSix = sixthans,
                QuestionSeven = seventhans
            };

            var jsonObj = JsonConvert.SerializeObject(userInfos);
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(jsonObj.ToString(), Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                //you can add headers                
                //request.Headers.Add("key", "value");
                try
                {
                    string uri = "http://10.0.2.2/WebAPI/api/Answers";
                    response = await client.PostAsync(uri, content);
                    response.EnsureSuccessStatusCode();
                    Toast.MakeText(this, "Submited Successfully. Thank You!", ToastLength.Short).Show();
                }

                catch(Exception ex)
                {
                    if (response == null)
                    {
                        response = new HttpResponseMessage();
                    }

                    response.StatusCode = HttpStatusCode.InternalServerError;
                    response.ReasonPhrase = string.Format("RestHttpClient.SendRequest failed: {0}", ex);

                    Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
                }

                return response.ToString();
            }
        }
    }
}