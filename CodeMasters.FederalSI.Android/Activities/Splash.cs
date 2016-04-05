using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using AndroidHUD;
using CodeMasters.FederalSI.Shared.Service;
using System.Collections.Generic;
using CodeMasters.FederalSI.Shared.Model;
using System.Threading.Tasks;
using System.Threading;

namespace CodeMasters.FederalSI.Droid
{
    [Activity(Label = "", 
                NoHistory=true,
                Theme = "@style/FederalSITheme.Splash")]
    public class Splash : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Splash);

            // Show loading indicator
            AndHUD.Shared.Show(this, "Loading", -1, MaskType.Clear);

            // Load the data asynchronously
            Task<List<Solution>> dataTask = Task.Factory.StartNew(new Func<List<Solution>>(FetchData));

            dataTask.ContinueWith((previousTask) =>
            {
                // Launch new activity with loaded data
                var homeScreenIntent = new Intent(this, typeof(SolutionList));
                string solutionsJson = JsonHelper.Serialize<List<Solution>>(previousTask.Result);
                homeScreenIntent.PutExtra("JsonSolutionsString", solutionsJson);
                StartActivity(homeScreenIntent);

                AndHUD.Shared.Dismiss();
            }
            );
        }

        private List<Solution> FetchData()
        {
            DataService service = new DataService();
            List<Solution> solutions = service.GetSolutions();
            // TODO: just to simulate delay of data retrieval
            Thread.Sleep(5000);

            return solutions;
        }
    }
}

