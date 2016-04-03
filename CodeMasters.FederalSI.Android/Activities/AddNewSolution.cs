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
    [Activity(MainLauncher = true,Label = "Add New Solution",
        Icon = "@drawable/loadinganimated", Theme = "@style/FederalSITheme")]
    public class AddNewSolution : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AddNewSolution);
            // Create your application here
            Button buttonSaveSolution = FindViewById<Button>(Resource.Id.buttonSaveSolution);
            Button buttonCan = FindViewById<Button>(Resource.Id.buttonCancel);
            buttonSaveSolution.Click += (o, e) => {
                Toast.MakeText(this, "New Solution added Successfully.", ToastLength.Short).Show();
            };

            buttonCan.Click += (o, e) => {
                Finish();
            };
        }
    }
}