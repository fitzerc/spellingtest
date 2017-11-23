using Android.App;
using Android.OS;
using Android.Widget;
using Spelling.Util;
using System;

namespace Spelling
{
    [Activity(Label = "Spelling", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button addBtn = FindViewById<Button>(Resource.Id.addWordBtn);
            addBtn.Click += delegate {
                StartActivity(typeof(AddWordActivity));
            };

            Button startTestBtn = FindViewById<Button>(Resource.Id.startTestBtn);
            startTestBtn.Click += delegate {
                StartActivity(typeof(TestActivity));
            };

            Button delWords = FindViewById<Button>(Resource.Id.deleteWordsBtn);
            delWords.Click += ConfirmDeleteAll;
        }

        private void ConfirmDeleteAll(object sender, EventArgs e)
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(this);
            alert.SetTitle("Confirm Delete");
            alert.SetMessage("Delete all words?");
            alert.SetPositiveButton("Delete", (senderAlert, args) => {
                WordsFileHandler.writeWords("");
            });

            alert.SetNegativeButton("Cancel", (senderAlert, args) => {
                return;
            });

            Dialog dialog = alert.Create();
            dialog.Show();
        }

        private void speak()
        {
            Speaker spkr = new Speaker();
            string ipWord = WordsFileHandler.getWords();
            spkr.Speak(ipWord,ApplicationContext);
        }
    }
}

