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

namespace CodeMasters.FederalSI.Droid.Activities
{
    [Activity(MainLauncher = true)]
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