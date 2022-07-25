using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;

namespace sepWake2{
    public static class tts{

        public enum ttsPlaySoundEffectWhen
        {
            dontplay=0, playbefore=1, playafter=2, platyboth=3
        }

        public static void Speak(string text, bool async = true, string voice = "Daniel")
        {
            applemusic.SetSystemVolumeValue(60);

            Process say = new Process()
            {
                StartInfo = new ProcessStartInfo() { FileName = "say", Arguments = $"-v {voice} {text}" }
            };

            w.infoprint("[TTS] " + text);
            say.Start();
            if (!async) say.WaitForExit();
        }

        public static void SpeakScript(List<string> script, ttsPlaySoundEffectWhen endsound=0, string voice = "Daniel") 
        {

            if (endsound==ttsPlaySoundEffectWhen.playbefore || endsound==ttsPlaySoundEffectWhen.platyboth) 
            {
                afplay.playSoundAsync(base_.SOUND_PRESLEEP_PATH);
                Thread.Sleep(3000);
            }

            foreach (string i in script) 
            {
                tts.Speak(i, false, voice);
                Thread.Sleep(base_.TTS_SCRIPT_DELAY);
            }

            if (endsound==ttsPlaySoundEffectWhen.playafter || endsound==ttsPlaySoundEffectWhen.platyboth)
            {
                afplay.playSoundAsync(base_.SOUND_PRESLEEP_PATH);
                Thread.Sleep(3000);
            }
        }

    }

}