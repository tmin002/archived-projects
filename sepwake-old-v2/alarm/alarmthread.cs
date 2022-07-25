using System;
using System.Threading;
using System.Collections.Generic;

namespace sepWake2{
    public static class AlarmThread{ 

        private static Thread th;
        private static bool thstop = false;

        private static void thtask()
        {

            int lastmin = alarm.nmin;
            while (!thstop)
            {

                bool unskip = lastmin == 24*60-1 && alarm.nmin == 0;

                foreach (alarm a in alarm.AlarmList)
                {

                    if (unskip) a.Skip = false;

                    if (!a.Enabled || a.Skip) continue;

                    int ringtime = alarm.ArrayTimeToMinuteInt(a.RingTime);
                    if (alarm.nmin == ringtime) alarm.RaiseRing(alarm.AlarmRingType.Ring,a);


                    if (!a.PreSleepEnable) continue;

                    int presleeptime = ringtime - a.PreSleepTime - a.SleepTime;
                    int presleeppretime = presleeptime - a.PreSleepPrepareTime;

                    if (alarm.nmin == presleeptime) alarm.RaiseRing(alarm.AlarmRingType.PresleepBegin,a);
                    if (alarm.nmin == presleeppretime) alarm.RaiseRing(alarm.AlarmRingType.PresleepPrepare,a);
                    w.infoprint("sdfsd");
                } 

                lastmin = alarm.nmin;
                SleepUntilMinPass();
           } 
           thstop = false;
        }

        public static void StartWait()
        {
            th = new Thread(thtask);
            th.Start();
        }
        public static void StopWait() => thstop = true;
        private static void SleepUntilMinPass()
            => Thread.Sleep(1000 * (60 - DateTime.Now.Second));

    }
}