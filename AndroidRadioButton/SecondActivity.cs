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
using Java.Interop;

namespace AndroidRadioButton
{
    [Activity(Label = "Second")]
    public class SecondActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Second);

            var btnNext = FindViewById<Button>(Resource.Id.secnext);
            var btnPrev = FindViewById<Button>(Resource.Id.secprev);

            btnPrev.Click += (s, e) =>
            {
                Intent mainActivity = new Intent(this, typeof(MainActivity));
                StartActivity(mainActivity);
            };

            

            btnNext.Click += (s, e) =>
            {
                RadioGroup radioGroupOne= FindViewById<RadioGroup>(Resource.Id.radioGroup1);
                RadioButton checkedradiobutton1 = FindViewById<RadioButton>(radioGroupOne.CheckedRadioButtonId);
                RadioGroup radioGroupTwo = FindViewById<RadioGroup>(Resource.Id.radioGroup2);
                RadioButton checkedradiobutton2 = FindViewById<RadioButton>(radioGroupTwo.CheckedRadioButtonId);
                RadioGroup radioGroupThree = FindViewById<RadioGroup>(Resource.Id.radioGroup3);
                RadioButton checkedradiobutton3 = FindViewById<RadioButton>(radioGroupThree.CheckedRadioButtonId);
                Intent thirdActivity = new Intent(this, typeof(ThirdActivity));
                thirdActivity.PutExtra("firstans", checkedradiobutton1.Text);
                thirdActivity.PutExtra("secondans", checkedradiobutton2.Text);
                thirdActivity.PutExtra("thirdans", checkedradiobutton3.Text);
                StartActivity(thirdActivity);

            };           
        }

        //[Export("radioButton_OnClick")]
        //public void radioButton_OnClick(View v)
        //{
        //    RadioGroup radioGroup = FindViewById<RadioGroup>(Resource.Id.radioGroup1);
        //    RadioButton checkedradiobutton = FindViewById<RadioButton>(radioGroup.CheckedRadioButtonId);
        //    switch (v.Id)
        //    {
        //        case Resource.Id.secone1:
        //            Toast.MakeText(this, checkedradiobutton.Text, ToastLength.Short).Show();
        //            break;
        //        case Resource.Id.sectwo1:
        //            Toast.MakeText(this, checkedradiobutton.Text, ToastLength.Short).Show();
        //            break;
        //        case Resource.Id.secthree1:
        //            Toast.MakeText(this, checkedradiobutton.Text, ToastLength.Short).Show();
        //            break;
        //        case Resource.Id.secfour1:
        //            Toast.MakeText(this, checkedradiobutton.Text, ToastLength.Short).Show();
        //            break;
        //        case Resource.Id.secfive1:
        //            Toast.MakeText(this, checkedradiobutton.Text, ToastLength.Short).Show();
        //            break;
        //    }
        //}
    }
}