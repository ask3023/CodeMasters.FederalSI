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

            solutionListView.ItemClick += SolutionListView_ItemClick;
            solutionListView.ItemSelected += SolutionListView_ItemSelected;
            solutionListView.NothingSelected += SolutionListView_ItemSelectionCleared;

            solutionListView.SetSelector(Resource.Color.cellbackSelected);

        }

        private void SolutionListView_ItemSelectionCleared(object sender, EventArgs e)
        {
            // throw new NotImplementedException();
        }

        private void SolutionListView_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            // throw new NotImplementedException();
        }

        private void SolutionListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            // solutionListView.SetSelection(e.Position);
            // throw new NotImplementedException();
        }
    }
}