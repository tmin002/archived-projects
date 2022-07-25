using System;
using System.Threading;
using System.Collections.Generic;
using System.IO;

namespace sepWake2{
   public partial class alarm{ //static parts

        public static List<alarm> AlarmList;  //require declartion: at alarm.loadalarm 

        public delegate void alarmRingEventHandler(AlarmRingEventArgs e);
        public static event alarmRingEventHandler alarmRing; 
        public static void AlarmEventHandlerInitialize() => alarmRing += ring.onRing; //call this at program.cs
        public static void RaiseRing(AlarmRingType at, alarm aa) => alarmRing.Invoke(new AlarmRingEventArgs(at,aa));

        public static String AlarmFilePath = base_.SEP_PWD + "/alarm.txt";
        ////

        public static void AddAlarm(alarm a) 
        {
            AlarmList.Add(a);
        }
        public static void RemoveAlarmByIndex(int i) => AlarmList.RemoveAt(i);
        public static void RemoveAlarmByName(String t) 
        {
            foreach (alarm a in AlarmList)
                if (a.Name == t) AlarmList.Remove(a);
        }
        public static void ClearAlarms() => AlarmList.Clear();
        public static int FindAlarmIndex(String t)
        {
            for (int i=0; i<AlarmList.Count; i++)
                if (AlarmList[i].Name == t) return i;
            return -1;
        }
        ////

        public static DateTime DateTimeNow { get { return DateTime.Now; }}
        public static int nmin {get { return DateTimeNow.Hour * 60 + DateTimeNow.Minute; }}
        public static int ArrayTimeToMinuteInt(int[] t) => t[0]*60 + t[1];
        public static int MinuteModularConvert(int t) 
        {
            while (t<0) t += 24*60;
            while (t>24*60-1) t -= 24*60;
            return t;
        }
        public static String MinuteIntToString(int t)
        {
            int mm = t%60;
            int mh = MinuteModularConvert(t-mm)/60;
            
            string a = alarm.DateTimeNow.Hour < 12 ? " AM" : " PM";
            string h = "";
            int hh = mh;

            if (hh==12 || hh==0) h = "12";
            else h = (hh%12).ToString();
            return h + ":" + mm.ToString() + a;
        }

        ////

        public static void InitSettings()
        {
            w.infoprint("Loading alarm data");
            LoadAlarm(alarm.AlarmFilePath);
        }
        ////

        public enum AlarmRingType { Ring, PresleepBegin, PresleepPrepare };
        public enum AlarmType { Standard, Stopwatch };
    }
    
    public class AlarmRingEventArgs {   
        public alarm.AlarmRingType RingType;
        public alarm RingAlarm;
        public AlarmRingEventArgs(alarm.AlarmRingType type, alarm a)
        {
            RingType = type;
            RingAlarm = a;
        }
    }
}