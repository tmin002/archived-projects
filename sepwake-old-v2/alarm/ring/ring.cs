using System;
using System.Collections.Generic;
using System.Threading;

namespace sepWake2
{
    public static class ring 
    {
        public static void onRing(AlarmRingEventArgs e)
        {
            w.infoprint($"onRing(): {e.RingType}, {e.RingAlarm.Name}");

            switch (e.RingType)
            {
                case alarm.AlarmRingType.PresleepPrepare:
                
                    afplay.playSoundAsync(base_.SOUND_RING_PATH);
                    Thread.Sleep(3000);
                    tts.SpeakScript(alarmttsScript.TTSPresleepPrepareScript(e.RingAlarm),tts.ttsPlaySoundEffectWhen.playafter);
                    break;

                case alarm.AlarmRingType.PresleepBegin:

                    tts.SpeakScript(alarmttsScript.TTSPresleepBeginScript(e.RingAlarm),tts.ttsPlaySoundEffectWhen.playbefore);
                    break;

                case alarm.AlarmRingType.Ring:

                    afplay.playSoundAsync(base_.SOUND_RING_PATH);
                    Thread.Sleep(3000);
                    e.RingAlarm.Count++;
                    alarm.SaveCurrentAlarm(alarm.AlarmFilePath);
                    tts.SpeakScript(alarmttsScript.TTSRingScript(e.RingAlarm),tts.ttsPlaySoundEffectWhen.playafter);
                    break;
            }
        }
    }
}