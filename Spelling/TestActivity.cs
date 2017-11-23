
using Android.App;
using Android.OS;
using Android.Widget;
using Spelling.Util;
using System;

namespace Spelling
{
    [Activity(Label = "TestActivity")]
    public class TestActivity : Activity
    {
        string curWord;
        WordsCollection words;
        Button nextButton;
        Button repeatButton;
        Button quitButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Test);

            words = new WordsCollection(WordsFileHandler.GetWordsList());

            curWord = GetNextWord(words);

            nextButton = FindViewById<Button>(Resource.Id.nextWordBtn);
            nextButton.Text = "First Word";
            nextButton.Click += NextButtonClick;

            repeatButton = FindViewById<Button>(Resource.Id.repeatWordBtn);
            repeatButton.Click += RepeatButtonClick;

            quitButton = FindViewById<Button>(Resource.Id.quitBtn);
            quitButton.Click += QuitButtonClick;
        }

        private string GetNextWord(WordsCollection words)
        {
            if (words.Count == 0)
            {
                Speaker speaker = new Speaker();
                speaker.Speak("Add Some Words", ApplicationContext);
                base.OnBackPressed();
            }
            return words.getWord();
        }

        private void QuitButtonClick(object sender, EventArgs e)
        {
            base.OnBackPressed();
        }

        private void RepeatButtonClick(object sender, EventArgs e)
        {
            Speaker speaker = new Speaker();
            speaker.Speak(curWord, ApplicationContext);
        }

        private void NextButtonClick(object sender, EventArgs e)
        {
            Speaker speaker = new Speaker();
            if(nextButton.Text == "First Word")
            {
                speaker.Speak(curWord, ApplicationContext);
                nextButton.Text = "Next Word";
                return;
            }

            if(words.hasNext())
            {
                curWord = GetNextWord(words);
                speaker.Speak(curWord, ApplicationContext);
                return;
            }

            speaker.Speak("No more words", ApplicationContext);
        }
    }
}