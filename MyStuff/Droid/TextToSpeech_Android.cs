using System;
using System.Collections.Generic;
using Android.Speech.Tts;
using Xamarin.Forms;

namespace MyStuff.Droid
{
	public class TextToSpeech_Android : Object, ITextToSpeech, TextToSpeech.IOnInitListener
	{
		TextToSpeech speaker;
		string toSpeak;

        public IntPtr Handle => throw new NotImplementedException();

        public void Speak(string text)
		{
			if (!string.IsNullOrWhiteSpace(text))
			{
				toSpeak = text;
				if (speaker == null)
					speaker = new TextToSpeech(Forms.Context, this);
				else
				{
					var p = new Dictionary<string, string>();
					speaker.Speak(toSpeak, QueueMode.Flush, p);
				}
			}
		}

		#region IOnInitListener implementation
		public void OnInit(OperationResult status)
		{
			if (status.Equals(OperationResult.Success))
			{
				var p = new Dictionary<string, string>();
				speaker.Speak(toSpeak, QueueMode.Flush, p);
			}
		}

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion
    }

}
