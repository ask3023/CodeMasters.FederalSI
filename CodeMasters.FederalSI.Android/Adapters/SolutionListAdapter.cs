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
    public class SolutionListAdapter : BaseAdapter<Solution>
    {
        Activity _context;
        List<Solution> _solutions;

        public SolutionListAdapter(Activity context, List<Solution> solutions)
        {
            this._context = context;
            this._solutions = solutions;
        }

        public override Solution this[int position]
        {
            get
            {
                return _solutions[position];
            }
        }

        public override int Count
        {
            get
            {
                return this._solutions.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return this._solutions[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            Solution sol = _solutions[position];

            if(convertView == null)
            {
                // convertView = _context.LayoutInflater.Inflate(global::Android.Resource.Layout.SimpleListItem1, null);
                convertView = _context.LayoutInflater.Inflate(Resource.Layout.SolutionItem, null);
            }

            convertView.FindViewById<TextView>(Resource.Id.SolName).Text = sol.Name;
            // convertView.FindViewById<TextView>(global::Android.Resource.Id.Text1).Text = sol.Name;
            convertView.FindViewById<ImageView>(Resource.Id.listItemImage).Visibility = ViewStates.Invisible;

            return convertView;
        }
    }
}