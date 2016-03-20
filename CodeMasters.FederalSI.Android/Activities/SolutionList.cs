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

namespace CodeMasters.FederalSI.Droid
{
    [Activity(Label = "SI Marketplace")]
    public class SolutionList : Activity
    {
        ListView solutionListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            string solutionsJson = Intent.GetStringExtra("JsonSolutionsString"); 

            List<Solution> solutions = JsonHelper.DeserializeSolutions(solutionsJson);

            // Build the UI
            SetContentView(Resource.Layout.SolutionList);
            solutionListView = FindViewById<ListView>(Resource.Id.listView1);

            solutionListView.Adapter = new SolutionListAdapter(this, solutions);
            solutionListView.FastScrollEnabled = true;

        }
    }
}