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
using AndroidHUD;

namespace CodeMasters.FederalSI.Droid.Activities
{
    [Activity(Label = "Solution Detail", //MainLauncher = true,
        Icon = "@drawable/loadinganimated", Theme = "@style/FederalSITheme")]
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

            this.Title = currentSolution.Name;

            var overViewLayout = FindViewById<LinearLayout>(Resource.Id.overViewMainText);

            SetOverViewForCurrentSolution(currentSolution, overViewLayout);

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
            string solutionJson = Intent.GetStringExtra("JsonSelectedSolutionString");
            var currentSolution = JsonHelper.Deserialize<Solution>(solutionJson);


            var imageView = FindViewById<ImageView>(Resource.Id.dynamicImage1);
            var webview = FindViewById<WebView>(Resource.Id.webView1);
            //var cardview = FindViewById<CardView>(Resource.Id.card_view);
            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            var overViewLayout = FindViewById<LinearLayout>(Resource.Id.overViewMainText);

            webview.Visibility = ViewStates.Invisible;
            imageView.Visibility = ViewStates.Invisible;
            mRecyclerView.Visibility = ViewStates.Invisible;
            overViewLayout.Visibility = ViewStates.Invisible;

            if (e.MenuItem.Tag == (int)MenuItem.Overview)
            {
                SetOverViewForCurrentSolution(currentSolution, overViewLayout);
            }

            if (e.MenuItem.Tag == (int)MenuItem.Contact)
            {   

                //SetContentView(Resource.Layout.Recycler);
                mRecyclerView.Visibility = ViewStates.Visible;

                // Plug in the linear layout manager:
                mLayoutManager = new LinearLayoutManager(this);
                mRecyclerView.SetLayoutManager(mLayoutManager);
                
                // Plug in my adapter:
                var mAdapter = new ContactsAdapter(currentSolution.Contacts);
                mRecyclerView.SetAdapter(mAdapter);

            }

            if (e.MenuItem.Tag == (int)MenuItem.InfoCard)
            {
                //set visibilitywebview.Visibility = ViewStates.Visible;
                webview.SetWebChromeClient(new WebChromeClient());
                webview.Settings.AllowUniversalAccessFromFileURLs = true;
                webview.Settings.JavaScriptEnabled = true;
                webview.Settings.AllowContentAccess = true;
                //leverage browser view
                // TODO: URL needs to be replaced with Solution.PagerUrl property
                var path = "http://docs.google.com/gview?embedded=true&url=" + currentSolution.PagerUrl;
                //webview.LoadUrl("http://docs.google.com/gview?embedded=true&url=http://federalsi.azurewebsites.net/api/solution/1/pager");
                webview.LoadUrl(path);
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
                var path = "http://docs.google.com/gview?embedded=true&url=" + currentSolution.InfoCardUrl;
                //webview.LoadUrl("http://docs.google.com/gview?embedded=true&url=http://federalsi.azurewebsites.net/api/solution/1/pager");
                webview.LoadUrl(path);
                // Show loading indicator

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentSolution"></param>
        /// <param name="overViewLayout"></param>
        private void SetOverViewForCurrentSolution(Solution currentSolution, LinearLayout overViewLayout)
        {
            overViewLayout.Visibility = ViewStates.Visible;
            var overViewSub = FindViewById<TextView>(Resource.Id.overViewSubText);
            overViewSub.Visibility = ViewStates.Visible;
            overViewSub.Text = currentSolution.Overview;
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