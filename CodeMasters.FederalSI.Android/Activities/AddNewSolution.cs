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
using System.Threading;

namespace CodeMasters.FederalSI.Droid.Activities
{
    [Activity(Label = "Add New Solution",
        Icon = "@drawable/loadinganimated", Theme = "@style/FederalSITheme")]
    public class AddNewSolution : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AddNewSolution);
            // Create your application here
            Button addButton = FindViewById<Button>(Resource.Id.button);
            Button cancelButton = FindViewById<Button>(Resource.Id.buttonCancel);

            addButton.Click += (o, e) => {
                Toast.MakeText(this, "New Solution added Successfully.", ToastLength.Short).Show();
                this.Finish();
            };

            cancelButton.Click += (o, e) =>
            {
                this.Finish();
            };
        }
    }
}