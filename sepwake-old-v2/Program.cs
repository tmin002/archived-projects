using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Text;

namespace sepWake2
{
    class Program
    {
        
        private static void greetings()
        {
            w.infoprint("Joyo project assistant (S.E.P. v2)");
            w.infoprint("Launch: " + alarm.DateTimeNow);
            w.infoprint("Designed to ran only on macOS");
            w.infoprint("PWD="+base_.SEP_PWD);
        }
        private static void init()
        {
            alarm.AlarmEventHandlerInitialize();
            AlarmThread.StartWait();
        }

        static void Main()
        {
            greetings();

            alarm.InitSettings();

            init();
            shell.init();
        }

    }
}
