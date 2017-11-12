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

namespace AndroidRadioButton
{
    [Activity(Label = "Third")]
    public class ThirdActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Third);
            string firstans = Intent.GetStringExtra("firstans" ?? "Not Received");
            string secondans = Intent.GetStringExtra("secondans" ?? "Not Received");
            string thirdans = Intent.GetStringExtra("thirdans" ?? "Not Received");

            var btnNext = FindViewById<Button>(Resource.Id.thirdnext);
            var btnPrev = FindViewById<Button>(Resource.Id.thirdprev);

            btnPrev.Click += (s, e) =>
            {
                Intent secondActivity = new Intent(this, typeof(SecondActivity));
                StartActivity(secondActivity);
            };

            btnNext.Click += (s, e) =>
            {
                RadioGroup radioGroupFour = FindViewById<RadioGroup>(Resource.Id.radioGroup4);
                RadioButton checkedradiobutton4 = FindViewById<RadioButton>(radioGroupFour.CheckedRadioButtonId);
                RadioGroup radioGroupFive = FindViewById<RadioGroup>(Resource.Id.radioGroup5);
                RadioButton checkedradiobutton5 = FindViewById<RadioButton>(radioGroupFive.CheckedRadioButtonId);
                RadioGroup radioGroupSix = FindViewById<RadioGroup>(Resource.Id.radioGroup6);
                RadioButton checkedradiobutton6 = FindViewById<RadioButton>(radioGroupSix.CheckedRadioButtonId);
                Intent fourthActivity = new Intent(this, typeof(FourthActivity));
                fourthActivity.PutExtra("firstans", firstans);
                fourthActivity.PutExtra("secondans", secondans);
                fourthActivity.PutExtra("thirdans", thirdans);
                fourthActivity.PutExtra("fourthans", checkedradiobutton4.Text);
                fourthActivity.PutExtra("fifthans", checkedradiobutton5.Text);
                fourthActivity.PutExtra("sixthans", checkedradiobutton6.Text);
                StartActivity(fourthActivity);
            };
        }
    }
}