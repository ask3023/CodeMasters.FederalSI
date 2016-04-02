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
using SatelliteMenu;
using System.Net;
using Android.Webkit;
using Android.Support.V7.Widget;
using CodeMasters.FederalSI.Shared.Service;
using CodeMasters.FederalSI.Shared.Model;
using CodeMasters.FederalSI.Droid.Adapters;

namespace CodeMasters.FederalSI.Droid.Activities
{
    [Activity(Label = "Dot Agile", MainLauncher = true, Icon = "@drawable/loadinganimated", Theme = "@style/FederalSITheme")]
    class SolutionMenu : Activity
    {

        RecyclerView mRecyclerView;
        RecyclerView.LayoutManager mLayoutManager;
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.SolutionMenu);

            string solutionJson = Intent.GetStringExtra("JsonSelectedSolutionString");
            var currentSolution = JsonHelper.Deserialize<Solution>(solutionJson);


            //recycler


            var button = FindViewById<SatelliteMenuButton>(Resource.Id.menu);

            button.AddItems(new[] {
        new SatelliteMenuButtonItem ((int)MenuItem.Overview, Resource.Drawable.ic_action_pin),
        new SatelliteMenuButtonItem ((int)MenuItem.Description, Resource.Drawable.ic_action_news),
        new SatelliteMenuButtonItem ((int)MenuItem.Contact, Resource.Drawable.ic_action_phone_start),
        new SatelliteMenuButtonItem ((int)MenuItem.InfoCard, Resource.Drawable.ic_action_lab),
        new SatelliteMenuButtonItem ((int)MenuItem.Pager, Resource.Drawable.ic_action_pie_chart)});

            button.MenuItemClick += MenuClick;

        }

        public  void MenuClick(object sender, SatelliteMenuItemEventArgs e)
        {

            //Load your content here dynamically

            
         
            var imageView = FindViewById<ImageView>(Resource.Id.dynamicImage1);
            var webview = FindViewById<WebView>(Resource.Id.webView1);
            //var cardview = FindViewById<CardView>(Resource.Id.card_view);

            webview.Visibility = ViewStates.Invisible;
            imageView.Visibility = ViewStates.Invisible;
            //cardview.Visibility = ViewStates.Invisible;


            if (e.MenuItem.Tag == (int)MenuItem.Contact)
            {
                //set visibility
                //cardview.Visibility = ViewStates.Visible;

                //var person_photo = FindViewById<ImageView>(Resource.Id.person_photo);
                //person_photo.SetImageResource(Resource.Drawable.BrianBreit);

                //var person_name = FindViewById<TextView>(Resource.Id.person_name);
                //person_name.Text = "Brian Breit";

                //var person_email = FindViewById<TextView>(Resource.Id.person_email);
                //person_email.Text = @"bbreit@deloitte.com";

                //var person_description = FindViewById<TextView>(Resource.Id.person_description);
                //person_description.Text = "Leads the Federal System Development capability, with 20+ years of experience focusing on large technology-enabled business transformations across Financial Services and Health-related clients in Federal, State, and Commercial.";

                string solutionJson = Intent.GetStringExtra("JsonSelectedSolutionString");
                var currentSolution = JsonHelper.Deserialize<Solution>(solutionJson);

                SetContentView(Resource.Layout.Recycler);
                mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);

                // Plug in the linear layout manager:
                mLayoutManager = new LinearLayoutManager(this);
                mRecyclerView.SetLayoutManager(mLayoutManager);

                var dotAgile = new Solution();

                dotAgile.Contacts.Add(new Pointofcontact { Name = "Brian Breit", Email = @"bbreit@deloitte.com", Designation = "Partner",
                    Description = "Leads the Federal System Development capability, with 20+ years of experience focusing on large technology-enabled business transformations across Financial Services and Health-related clients in Federal, State, and Commercial",
                    ImageURL= "BrianBreit" });
                dotAgile.Contacts.Add(new Pointofcontact { Name = "Azunna Anyanwu", Email = @"aanyanwu@deloitte.com", Designation = "Manager",
                    Description = "15+ years of experience delivering solutions to clients in Federal & State. Expert at applying Agile frameworks such as Scrum & Rapid Application Development (RAD). Certified Scrum Master (CSM) and PMI Agile Professional (PMI-ACP).",
                    ImageURL = "AzunnaAnyanwu" });
                dotAgile.Contacts.Add(new Pointofcontact { Name = "Jason Bowers", Email = @"Jbowers@deloitte.com", Designation = "Director",
                    Description = "Agile advocate with 15+ years in large-scale custom development. Leader in Agile practices to deliver across multiple technology platforms. Delivers solutions in Case Management and other collaborative, mission IT solutions.",
                    ImageURL = "JasonBowers" });


                // Plug in my adapter:
                var mAdapter = new ContactsAdapter(dotAgile.Contacts);
                mRecyclerView.SetAdapter(mAdapter);

            }

            if (e.MenuItem.Tag == (int)MenuItem.InfoCard)
            {
                //set visibility
                imageView.Visibility = ViewStates.Visible;

                imageView.SetImageResource(Resource.Drawable.solution1_InfoCard);
            }
            if (e.MenuItem.Tag == (int)MenuItem.Description)
            {
                //set visibility
                webview.Visibility = ViewStates.Visible;

                webview.SetWebChromeClient(new WebChromeClient());
                webview.Settings.AllowUniversalAccessFromFileURLs = true;
                webview.Settings.JavaScriptEnabled = true;
                webview.Settings.AllowContentAccess = true;
                //leverage browser view
                // TODO: URL needs to be replaced with Solution.PagerUrl property
                webview.LoadUrl("http://docs.google.com/gview?embedded=true&url=http://federalsi.azurewebsites.net/api/solution/1/pager");
            }
        }

        enum MenuItem
        {
            Overview =0,
            Description =1,
            Contact = 2,
            InfoCard =3,
            Pager=4 
        }
    }
}