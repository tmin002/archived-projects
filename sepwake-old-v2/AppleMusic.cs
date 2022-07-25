using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading;

namespace sepWake2
{
    public static class applemusic
    {

        private static int prevol = 0;

        public static void PlayAlarmMusic()
        {
            String playlistname = "init";
            prevol = GetSystemVolumeValue();
            int trackCount = 
            Convert.ToInt32(osascript.executeOsaScript(
                $"tell application \\\"Music\\\" to return index of last track of playlist \\\"{playlistname}\\\"" //todo: wip. only on 'init'playlist 
            , true));
            int trackIndex = (alarm.DateTimeNow.Day % trackCount) + 1;

            w.infoprint($"AppleMusic playing: track {trackIndex} of {playlistname}");
            

            SetSystemVolumeValue(50);

            osascript.executeOsaScript(
                $"tell application \\\"Music\\\" to play track index {trackIndex} of playlist \\\"{playlistname}\\\"");

            for (int i=0; i<=80; i+=2) SetMusicVolumeValue(i);

            Thread.Sleep(1000 * 5);

            for (int i=80; i>=40; i-=2) SetMusicVolumeValue(i);
            tts.Speak("좋은 아침입니다. 기상 알림이 15초 후 시작됩니다. ", false);
            Thread.Sleep(1000 * 15);

            for (int i=40; i>=10; i-=3) SetMusicVolumeValue(i);

            Thread.Sleep(1000);

        }

        public static void StopAlarmMusic()
        {
            for (int i=10; i>=0; i--) SetMusicVolumeValue(i);
        }

        public static int GetSystemVolumeValue()
        {
            return Convert.ToInt32(osascript.executeOsaScript("return output volume of (get volume settings)", true));
        }

        public static void SetSystemVolumeValue(int volume) // 0 100
            => osascript.executeOsaScript($"set volume output volume {volume}");

        public static void SetMusicVolumeValue(int volume)
            => osascript.executeOsaScript($"tell application \\\"Music\\\" to set the sound volume to {volume}");

       public static void StopMusic()
            => osascript.executeOsaScript($"tell application \\\"Music\\\" to pause");

    }




}