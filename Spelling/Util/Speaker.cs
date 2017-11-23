﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Speech.Tts;
using System.Runtime.CompilerServices;

namespace Spelling.Util
{
    public class Speaker : Java.Lang.Object, TextToSpeech.IOnInitListener
    {
        TextToSpeech speaker;
        string toSpeak;

        public void Speak(string text, Context context)
        {
            toSpeak = text;
            if (speaker == null)
            {
                speaker = new TextToSpeech(context, this);
            }
            else
            {
                speaker.Speak(toSpeak, QueueMode.Flush, null, null);
            }
        }

        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                speaker.Speak(toSpeak, QueueMode.Flush, null, null);
            }
        }
    }
}