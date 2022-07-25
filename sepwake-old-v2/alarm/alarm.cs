using System;
using System.Collections.Generic;
using System.Threading;

namespace sepWake2
{
    public partial class alarm
    {

        public bool Enabled = true; //
        public String Name = "defualt0"; //
        public AlarmType Type = AlarmType.Standard; //
        public int[] RingTime = new int[] {5,0}; // 
        public bool PreSleepEnable = true; //
        public int PreSleepPrepareTime = 5;
        public int PreSleepTime = 30;
        public int SleepTime = 6*60;
        public int Count = 0;

        public bool Skip = false; 
        public int dmin { get{ return RingTime[0]*60 + RingTime[1]; }}



    
       
    }
}
