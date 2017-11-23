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
using Java.Lang;
using Spelling.Util;

namespace Spelling
{
    public class WordsAdapter : BaseAdapter
    {
        WordsCollection words;
        Activity activity;

        public WordsAdapter(WordsCollection ipWords,Activity ipActivity)
        {
            words = ipWords;
            activity = ipActivity;
        }

        public override int Count
        {
            get { return words.Count; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return words.GetItemId(position);
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.WordListItem, parent, false);
            TextView wordView = view.FindViewById<TextView>(Resource.Id.WordTextView);
            wordView.Text = words.GetItem(position);
            return view;
        }
    }
}