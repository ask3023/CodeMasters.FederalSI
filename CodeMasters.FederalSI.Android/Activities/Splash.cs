using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace CodeMasters.FederalSI.Android
{
    [Activity(Label = "SIMarketplace.Android", MainLauncher = true, // Icon = "@drawable/icon",
                NoHistory=true,
                Theme = "@style/SITheme.Splash")]
    public class Splash : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Load the data asynchronously

            // Show loading indicator

            // Launch new activity with loaded data
        }
    }
}

