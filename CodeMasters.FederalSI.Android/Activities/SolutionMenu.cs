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

namespace CodeMasters.FederalSI.Droid.Activities
{
    [Activity(Label = "Solution Details", Icon = "@drawable/loadinganimated", Theme = "@style/FederalSITheme")]
    class SolutionMenu : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.SolutionMenu);

            var button = FindViewById<SatelliteMenuButton>(Resource.Id.menu);

            button.AddItems(new[] {
        new SatelliteMenuButtonItem ((int)MenuItem.Overview, Resource.Drawable.ic_action_pin),
        new SatelliteMenuButtonItem ((int)MenuItem.Description, Resource.Drawable.ic_action_news),
        new SatelliteMenuButtonItem ((int)MenuItem.Contact, Resource.Drawable.ic_action_phone_start),
        new SatelliteMenuButtonItem ((int)MenuItem.InfoCard, Resource.Drawable.ic_action_lab),
        new SatelliteMenuButtonItem ((int)MenuItem.Pager, Resource.Drawable.ic_action_pie_chart)});

            //button.MenuItemClick += (sender, e) =>
            //{
            //    Console.WriteLine("{0} selected", e.MenuItem);
            //};

            button.MenuItemClick += MenuClick;
        }

        public  void MenuClick(object sender, SatelliteMenuItemEventArgs e)
        {

            //Load your content here dynamically
            //SetContentView(Resource.Layout.SolutionList);

            var imageView = FindViewById<ImageView>(Resource.Id.dynamicImage1);
            var webview = FindViewById<WebView>(Resource.Id.webView1);


            if (e.MenuItem.Tag == (int)MenuItem.InfoCard) { }
            {
                //set visibility
                webview.Visibility = ViewStates.Invisible;
                imageView.Visibility = ViewStates.Visible;

                imageView.SetImageResource(Resource.Drawable.solution1_InfoCard);
            }
            if (e.MenuItem.Tag == (int)MenuItem.Description)
            {
                //set visibility
                imageView.Visibility = ViewStates.Invisible;
                webview.Visibility = ViewStates.Visible;

                webview.SetWebChromeClient(new WebChromeClient());
                webview.Settings.AllowUniversalAccessFromFileURLs = true;
                webview.Settings.JavaScriptEnabled = true;
                webview.Settings.AllowContentAccess = true;
                //leverage browser view
                // webview.LoadUrl("http://docs.google.com/gview?embedded=true&url=http://www2.deloitte.com/content/dam/Deloitte/us/Documents/technology-media-telecommunications/us-tmt-fast500-2014-ranking-list.pdf");
                // webview.LoadUrl("http://docs.google.com/gview?embedded=true&url=https://childcare.dhss.delaware.gov/api/userGuides/pdf");
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