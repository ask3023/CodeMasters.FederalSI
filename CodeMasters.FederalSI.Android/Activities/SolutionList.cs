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
using Android.Graphics;
using CodeMasters.FederalSI.Shared.Service;

namespace CodeMasters.FederalSI.Droid
{
    [Activity(Label = "SI Marketplace")]
    public class SolutionList : Activity
    {
        ListView solutionListView;
        Button btnTC, btnTest, btnSupport, btnCode, btnProject, btnPHM, btnRequirement, btnDeployment, btnKID;
        Color textDefaultColor = new Color(0, 0, 0);
        Color textHighlightColor = new Color(255, 255, 255);
        List<Solution> solutions;
        UIMode currentMode;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            string solutionsJson = Intent.GetStringExtra("JsonSolutionsString"); 

            solutions = JsonHelper.DeserializeSolutions(solutionsJson);

            // Build the UI
            SetContentView(Resource.Layout.SolutionList);
            solutionListView = FindViewById<ListView>(Resource.Id.listView1);

            // Get button controls
            btnTC = FindViewById<Button>(Resource.Id.btnTC);
            btnTest = FindViewById<Button>(Resource.Id.btnTest);
            btnSupport = FindViewById<Button>(Resource.Id.btnSupport);
            btnCode = FindViewById<Button>(Resource.Id.btnCode);
            btnProject = FindViewById<Button>(Resource.Id.btnProject);
            btnPHM = FindViewById<Button>(Resource.Id.btnPHM);
            btnRequirement = FindViewById<Button>(Resource.Id.btnRequirement);
            btnDeployment = FindViewById<Button>(Resource.Id.btnDeployment);
            btnKID = FindViewById<Button>(Resource.Id.btnKID);

            // Subscribe to events
            solutionListView.ItemClick += SolutionListView_ItemClick;
            solutionListView.ItemSelected += SolutionListView_ItemSelected;

            btnTC.Click += Btn_Click;
            btnSupport.Click += Btn_Click;
            btnRequirement.Click += Btn_Click;
            btnProject.Click += Btn_Click;
            btnPHM.Click += Btn_Click;
            btnKID.Click += Btn_Click;
            btnDeployment.Click += Btn_Click;
            btnCode.Click += Btn_Click;
            btnTest.Click += Btn_Click;

            solutionListView.ChoiceMode = ChoiceMode.Single;
            solutionListView.Adapter = new SolutionListAdapter(this, solutions);

            currentMode = UIMode.Solution;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            // Clear all buttons

            // Highlight the selected button

            // Get the EVDType

            // Related solutions

            // Update the List with new set of elemets

            // Put the UI in EVD mode
        }

        private void SolutionListView_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            // throw new NotImplementedException();
        }

        private void SolutionListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            e.View.Selected = true;

            // If the mode change happens fill the list with all solutions
            // Which list items to select when the mode changes

            UpdateControlSelections(e.Id);

            // Put the UI in solution mode
        }

        private void UpdateControlSelections(long itemId)
        {
            ClearExistingSelection();

            Solution selectedSolution = solutions.Find(s => s.Id == itemId);

            foreach(var relatedEVD in selectedSolution.EVDCollection)
            {
                SelectButton(EvdTypeToButton((EVDType)relatedEVD.Id));
            }

            // Maintain the current mode of view (Solution mode or EVD mode)
            // Based on the mode update the list selection or button highlights
        }

        private void ClearExistingSelection()
        {
            for (int evdId = 1; evdId <= 9; evdId++)
            {
                UnselectButton(EvdTypeToButton((EVDType)evdId));
            }
        }

        private void SelectButton(Button selectButton)
        {
            selectButton.SetTextColor(textHighlightColor);
            selectButton.SetBackgroundResource(Resource.Color.buttonHighlightBackground);
        }

        private void UnselectButton(Button unselectButton)
        {
            unselectButton.SetTextColor(textDefaultColor);
            unselectButton.SetBackgroundResource(Resource.Color.buttonDefaultBackground);
        }

        private Button EvdTypeToButton(EVDType evdType)
        {
            Button matchingButton = btnCode;

            switch(evdType)
            {
                case EVDType.Project:
                    matchingButton = btnProject;
                    break;

                case EVDType.Code:
                    matchingButton = btnCode;
                    break;

                case EVDType.Deployment:
                    matchingButton = btnDeployment;
                    break;

                case EVDType.KeyImpactDeliverables:
                    matchingButton = btnKID;
                    break;

                case EVDType.ProjectHealthMetrics:
                    matchingButton = btnPHM;
                    break;

                case EVDType.Requirement:
                    matchingButton = btnRequirement;
                    break;

                case EVDType.Support:
                    matchingButton = btnSupport;
                    break;

                case EVDType.Test:
                    matchingButton = btnTest;
                    break;

                case EVDType.TrainingAndChange:
                    matchingButton = btnTC;
                    break;
            }

            return matchingButton;
        }

    }

    public enum UIMode
    {
        Solution,

        EVD
    }
}