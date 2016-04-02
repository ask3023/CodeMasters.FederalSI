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
using Android.Support.V7.Widget;

namespace CodeMasters.FederalSI.Droid.Adapters
{
    public class ContactsAdapter : RecyclerView.Adapter
    {
        public List<Pointofcontact> Contacts;
        

        public ContactsAdapter(List<Pointofcontact> contacts)
        {
            Contacts = contacts;
             
        }

        public override int ItemCount
        {
            get { return Contacts.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ContactViewHolder vh = holder as ContactViewHolder;

            //remove hard coding and add dynamic path
            //vh.personPhoto.SetImageURI(Android.Net.Uri.Parse("android.resource://SIMarketplace.Android/drawable/" + Contacts[position].ImageURL));
            if (Contacts[position].Name.Contains("Brian"))
            {
                vh.personPhoto.SetImageResource(Resource.Drawable.BrianBreit);
            }
            else if (Contacts[position].Name.Contains("Azunna"))
            {
                vh.personPhoto.SetImageResource(Resource.Drawable.AzunnaAnyanwu);
            }
            else if (Contacts[position].Name.Contains("Jason"))
            {
                vh.personPhoto.SetImageResource(Resource.Drawable.JasonBowers);
            }
            
            vh.personName.Text = Contacts[position].Name;
            vh.personEmail.Text = Contacts[position].Email;
            vh.personDescription.Text = Contacts[position].Description;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            // Inflate the CardView for the photo:
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.ContactCard, parent, false);

            // Create a ViewHolder to hold view references inside the CardView:
            ContactViewHolder vh = new ContactViewHolder(itemView);
            return vh;
        }
    }

    public class ContactViewHolder : RecyclerView.ViewHolder
    {
        public CardView cv;
        public TextView personName;
        public TextView personEmail;
        public TextView personDescription;
        public ImageView personPhoto;

        //public ImageView Image { get; private set; }
        //public TextView Caption { get; private set; }

        public ContactViewHolder(View itemView) : base(itemView)
        {
            // Locate and cache view references:
            cv = itemView.FindViewById<CardView>(Resource.Id.card_view);
            personName = itemView.FindViewById<TextView>(Resource.Id.person_name);
            personEmail = itemView.FindViewById<TextView>(Resource.Id.person_email);
            personPhoto = itemView.FindViewById<ImageView>(Resource.Id.person_photo);
            personDescription = itemView.FindViewById<TextView>(Resource.Id.person_description);
        }
    }
}