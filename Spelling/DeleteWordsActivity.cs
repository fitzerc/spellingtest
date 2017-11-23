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
using Spelling.Util;
using Android.Graphics;

namespace Spelling
{
    [Activity(Label = "Activity1")]
    public class DeleteWordsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DeleteWords);

            ListView wordsListView = FindViewById<ListView>(Resource.Id.wordListView);
            WordsCollection words = new WordsCollection();
            WordsAdapter adapter = new WordsAdapter(words, this);
            wordsListView.Adapter = adapter;

            // Create your application here
            wordsListView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs e)
            {
            };

            Button selectAllBtn = FindViewById<Button>(Resource.Id.selectAllBtn);
            selectAllBtn.Click += delegate {
                for(int view = 0;view <= wordsListView.Count;view++)
                {
                }
            };
        }
    }
}