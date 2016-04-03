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
using Android.Views.Animations;
using Android.Graphics;
using CodeMasters.FederalSI.Shared.Model;
using CodeMasters.FederalSI.Shared.Service;
using System.Threading;
using System.Threading.Tasks;
using CodeMasters.FederalSI.Droid.Adapters;
using CodeMasters.FederalSI.Droid.Adapters.CodeMasters.FederalSI.Droid;

namespace CodeMasters.FederalSI.Droid.Activities
{
    [Activity(Label = "Menu Activity", MainLauncher = true)]
    public class SolutionHome : Activity
    {
        GestureDetector gestureDetector;
        GestureListener gestureListener;

        ListView menuListView;
        MenuListAdapterClass objAdapterMenu;
        ImageView menuIconImageView;
        int intDisplayWidth;
        bool isSingleTapFired = false;
        TextView txtActionBarText;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Window.RequestFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.SolutionHome);
            FnInitialization();
            TapEvent();
            FnBindMenu();
        }

        #region "Menu Item Code"
        void TapEvent()
        {
            menuIconImageView.Click += delegate (object sender, EventArgs e)
            {
                if (!isSingleTapFired)
                {
                    FnToggleMenu();
                    isSingleTapFired = false;
                }
            };
        }
        void FnInitialization()
        {
            //gesture initialization
            gestureListener = new GestureListener();
            gestureListener.LeftEvent += GestureLeft;
            gestureListener.RightEvent += GestureRight;
            gestureListener.SingleTapEvent += SingleTap;
            gestureDetector = new GestureDetector(this, gestureListener);

            menuListView = FindViewById<ListView>(Resource.Id.menuListView);
            menuIconImageView = FindViewById<ImageView>(Resource.Id.menuIconImgView);
            txtActionBarText = FindViewById<TextView>(Resource.Id.txtActionBarText);
            menuListView.ItemClick += MenuListView_ItemClick;
            //changed sliding menu width to 1/3 of screen width 
            Display display = this.WindowManager.DefaultDisplay;
            var point = new Point();
            display.GetSize(point);
            intDisplayWidth = point.X;
            intDisplayWidth = intDisplayWidth - (intDisplayWidth / 3);
            using (var layoutParams = (RelativeLayout.LayoutParams)menuListView.LayoutParameters)
            {
                layoutParams.Width = intDisplayWidth;
                layoutParams.Height = ViewGroup.LayoutParams.MatchParent;
                menuListView.LayoutParameters = layoutParams;
            }
            //menuListView.LayoutParameters = new RelativeLayout.LayoutParams(intDisplayWidth, ViewGroup.LayoutParams.MatchParent);
        }
        #region " Menu related"
        void FnBindMenu()
        {
            string[] strMnuText = { "Home", "Add New Solution", "Help", "ContactUs" };
            int[] strMnuUrl = { Resource.Drawable.icon_home, Resource.Drawable.newSolution, Resource.Drawable.icon_help, Resource.Drawable.icon_contactus };
            if (objAdapterMenu != null)
            {
                //objAdapterMenu.actionMenuSelected -= FnMenuSelected;
                objAdapterMenu = null;
            }
            objAdapterMenu = new MenuListAdapterClass(this, strMnuText, strMnuUrl);
            //objAdapterMenu.actionMenuSelected += FnMenuSelected;

            menuListView.Adapter = objAdapterMenu;
        }

        private void MenuListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var sen = sender;
            var sid = e.Id;

            if (1 == sid)
            {
                var newSolution = new Intent(this, typeof(AddNewSolution));

                StartActivity(newSolution);
            }
            else if (0 == sid)
            {


                //var solutionCol = FetchData();
                //// Launch new activity with loaded data
                //var homeScreenIntent = new Intent(this, typeof(SolutionList));
                //string solutionsJson = JsonHelper.Serialize<List<Solution>>(solutionCol);
                //homeScreenIntent.PutExtra("JsonSolutionsString", solutionsJson);
                //StartActivity(homeScreenIntent);
            }
        }

        void FnMenuSelected(string strMenuText)
        {


        }

        private List<Solution> FetchData()
        {
            DataService service = new DataService();
            List<Solution> solutions = service.GetSolutions();
            // TODO: just to simulate delay of data retrieval
            // Thread.Sleep(5000);

            return solutions;
        }

        void FnToggleMenu()
        {
            Console.WriteLine(menuListView.IsShown);
            if (menuListView.IsShown)
            {
                menuListView.Animation = new TranslateAnimation(0f, -menuListView.MeasuredWidth, 0f, 0f);
                menuListView.Animation.Duration = 300;
                menuListView.Visibility = ViewStates.Gone;
            }
            else
            {
                menuListView.Visibility = ViewStates.Visible;
                menuListView.RequestFocus();
                menuListView.Animation = new TranslateAnimation(-menuListView.MeasuredWidth, 0f, 0f, 0f);//starting edge of layout 
                menuListView.Animation.Duration = 300;
            }
        }
        #endregion

        #region "Gesture function "
        void GestureLeft()
        {
            if (!menuListView.IsShown)
                FnToggleMenu();
            isSingleTapFired = false;
        }
        void GestureRight()
        {
            if (menuListView.IsShown)
                FnToggleMenu();
            isSingleTapFired = false;
        }
        void SingleTap()
        {
            if (menuListView.IsShown)
            {
                FnToggleMenu();
                isSingleTapFired = true;
            }
            else
            {
                isSingleTapFired = false;
            }
        }
        public override bool DispatchTouchEvent(MotionEvent ev)
        {
            gestureDetector.OnTouchEvent(ev);
            return base.DispatchTouchEvent(ev);
        }
        #endregion


        #endregion
    }
}