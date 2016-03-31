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
using CodeMasters.FederalSI.Droid.Activities;

namespace CodeMasters.FederalSI.Droid
{
    [Activity(Label = "Available Solutions", Icon = "@drawable/solution" //, Theme = "@style/FederalSITheme"
        )]  //, Theme = "@style/ListTheme"
    public class SolutionList : Activity
    {
        ListView solutionListView;
        Button btnTC, btnTest, btnSupport, btnCode, btnProject, btnPHM, btnRequirement, btnDeployment, btnKID;
        Color textDefaultColor = new Color(0, 153, 255);
        Color textHighlightColor = new Color(255, 255, 255);
        List<Solution> solutions;
        UIMode currentMode;
        long selectionItemId;
        View selectedItemView;
        SolutionListAdapter listAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            string solutionsJson = Intent.GetStringExtra("JsonSolutionsString"); 

            solutions = JsonHelper.Deserialize<List<Solution>>(solutionsJson);

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

            btnTC.Click += BtnTC_Click;
            btnSupport.Click += BtnSupport_Click;
            btnRequirement.Click += BtnRequirement_Click;
            btnProject.Click += BtnProject_Click;
            btnPHM.Click += BtnPHM_Click;
            btnKID.Click += BtnKID_Click;
            btnDeployment.Click += BtnDeployment_Click;
            btnCode.Click += BtnCode_Click;
            btnTest.Click += BtnTest_Click;

            solutionListView.ChoiceMode = ChoiceMode.Single;
            listAdapter = new SolutionListAdapter(this, solutions);
            solutionListView.Adapter = listAdapter;

            currentMode = UIMode.Solution;
        }

        #region Button handlers

        private void BtnTest_Click(object sender, EventArgs e)
        {
            Btn_Click(sender, e);
        }

        private void BtnCode_Click(object sender, EventArgs e)
        {
            Btn_Click(sender, e);
        }

        private void BtnDeployment_Click(object sender, EventArgs e)
        {
            Btn_Click(sender, e);
        }

        private void BtnKID_Click(object sender, EventArgs e)
        {
            Btn_Click(sender, e);
        }

        private void BtnPHM_Click(object sender, EventArgs e)
        {
            Btn_Click(sender, e);
        }

        private void BtnProject_Click(object sender, EventArgs e)
        {
            Btn_Click(sender, e);
        }

        private void BtnRequirement_Click(object sender, EventArgs e)
        {
            Btn_Click(sender, e);
        }

        private void BtnSupport_Click(object sender, EventArgs e)
        {
            Btn_Click(sender, e);
        }

        private void BtnTC_Click(object sender, EventArgs e)
        {
            Btn_Click(sender, e);
        }

        #endregion button handlers

        private void Btn_Click(object sender, EventArgs e)
        {
            // Check for mode change
            if(currentMode == UIMode.Solution)
            {
                currentMode = UIMode.EVD;
                selectionItemId = 0;
                selectedItemView = null;
            }

            // Clear all buttons
            ClearExistingSelection();

            // Highlight the selected button
            EVDType selectedEvdType = ButtonIdToEvdType(((Button)sender).Id);
            SelectButton(EvdTypeToButton(selectedEvdType));

            // Related solutions
            List<Solution> filteredList = solutions.FindAll(s => s.EVDCollection.Exists(evd => evd.Id == (int)selectedEvdType));

            // Update the List with new set of elemets
            solutionListView.Adapter = new SolutionListAdapter(this, filteredList);
        }

        private void SolutionListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            // Check for mode change
            if (currentMode == UIMode.EVD)
            {
                // Fill the entire list
                solutionListView.Adapter = new SolutionListAdapter(this, solutions);

                ClearExistingSelection();

                currentMode = UIMode.Solution;

                selectionItemId = 0;
                selectedItemView = null;
            }
            else
            {
                // If same items is clicked...navigate to details activity
                if (selectionItemId == e.Id)
                {
                    // Launch new activity for Solution details
                    var solutionDetailIntent = new Intent(this, typeof(SolutionMenu));
                    Solution selectedSolution = solutions.Find(sol => sol.Id == selectionItemId);
                    string solutionJson = JsonHelper.Serialize<Solution>(selectedSolution);
                    solutionDetailIntent.PutExtra("JsonSelectedSolutionString", solutionJson);
                    StartActivity(solutionDetailIntent);
                }
                else
                {
                    if(selectedItemView != null)
                    {
                        selectedItemView.FindViewById<ImageView>(Resource.Id.listItemImage).Visibility = ViewStates.Invisible;
                        selectedItemView.FindViewById<TextView>(Resource.Id.SolName).SetTextColor(textDefaultColor);
                    }

                    selectionItemId = e.Id;
                    selectedItemView = e.View;
                    selectedItemView.FindViewById<ImageView>(Resource.Id.listItemImage).Visibility = ViewStates.Visible;
                    selectedItemView.FindViewById<TextView>(Resource.Id.SolName).SetTextColor(textHighlightColor);

                    UpdateControlSelections(e.Id);
                }

                e.View.Selected = true;
            }
        }

        private void UpdateControlSelections(long itemId)
        {
            ClearExistingSelection();

            Solution selectedSolution = solutions.Find(s => s.Id == itemId);

            foreach(var relatedEVD in selectedSolution.EVDCollection)
            {
                SelectButton(EvdTypeToButton((EVDType)relatedEVD.Id));
            }
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

        private EVDType ButtonIdToEvdType(int buttonId)
        {
            EVDType evdType = EVDType.Code;

            switch (buttonId)
            {
                case Resource.Id.btnCode:
                    evdType = EVDType.Code;
                    break;

                case Resource.Id.btnDeployment:
                    evdType = EVDType.Deployment;
                    break;
                case Resource.Id.btnKID:
                    evdType = EVDType.KeyImpactDeliverables;
                    break;
                case Resource.Id.btnPHM:
                    evdType = EVDType.ProjectHealthMetrics;
                    break;
                case Resource.Id.btnProject:
                    evdType = EVDType.Project;
                    break;

                case Resource.Id.btnRequirement:
                    evdType = EVDType.Requirement;
                    break;
                case Resource.Id.btnSupport:
                    evdType = EVDType.Support;
                    break;
                case Resource.Id.btnTC:
                    evdType = EVDType.TrainingAndChange;
                    break;
                case Resource.Id.btnTest:
                    evdType = EVDType.Test;
                    break;
            }

            return evdType;
        }

    }

    public enum UIMode
    {
        Solution,

        EVD
    }
}