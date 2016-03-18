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
using CodeMasters.FederalSI.Shared.Model;

namespace CodeMasters.FederalSI.Android
{
    [Activity(Label = "SI Marketplace")]
    public class SolutionList : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            List<Solution> solutions = JsonHelper.DeserializeSolutions(Intent.GetStringExtra("JsonSolutionsString"));

            // Build the UI
        }
    }
}