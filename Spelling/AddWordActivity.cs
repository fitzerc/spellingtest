
using Android.App;
using Android.OS;
using Android.Widget;
using Spelling.Util;
using System;

namespace Spelling
{
    [Activity(Label = "AddWordActivity")]
    public class AddWordActivity : Activity
    {
        Button addWordBtn;
        TextView addWordTv;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AddWord);

            addWordBtn = FindViewById<Button>(Resource.Id.addBtn);
            addWordTv = FindViewById<TextView>(Resource.Id.wordEt);

            addWordBtn.Click += writeWordToFile;
        }

        private void writeWordToFile(object sender, EventArgs e)
        {
            WordsFileHandler.appendWord(addWordTv.Text);
            addWordTv.Text = "";
        }
    }
}