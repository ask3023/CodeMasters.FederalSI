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

namespace CodeMasters.FederalSI.Droid.Activities
{
    [Activity(Label = "Add New Solution",
        Icon = "@drawable/solution", Theme = "@style/FederalSITheme")]
    public class AddNewSolution : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AddNewSolution);
            // Create your application here
            Button buttonSaveSolution = FindViewById<Button>(Resource.Id.buttonSaveSolution);
            var textDisplay = FindViewById<TextView>(Resource.Id.textDisplay);
            Button buttonCan = FindViewById<Button>(Resource.Id.buttonCancel);
            buttonSaveSolution.Click += (o, e) => {
                //Toast.MakeText(this, "New Solution submitted for review Successfully and being processed.\n The Solution reference number is: 72837837837",ToastLength.Long).Show();
                textDisplay.Text = "New Solution is submitted successfully for review and being processed.The reference #: 72837837837.";
                textDisplay.Visibility = ViewStates.Visible;
            };

            buttonCan.Click += (o, e) => {
                Finish();
            };
        }
    }
}