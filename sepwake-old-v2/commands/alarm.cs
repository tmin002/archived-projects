using System;
using System.Collections.Generic;
using System.IO;

namespace sepWake2
{
    public class alarmCommand : CommandTemplate
    {
        public override String[] ComamndName => new String[] {"alarm"};
        public override String BriefHelp => "create, edit, remove alarms";
        public static Dictionary<String, Action<List<string>>> CommandList = new Dictionary<string, Action<List<string>>>{
            {"list", listAlarm}, {"skip", skipAlarm}, {"edit", editAlarm}, {"export", exportAlarm}, {"import", importAlarm}, 
            {"disable", disableAlarm}, {"call", callAlarmNow}, {"help", onHelp}, {"start", startAlarm},
            {"enable", enableAlarm}, {"reload", reloadAlarm}, {"alarmfilepath", ShowAlarmFilePath}, {"unskip", unskipAlarm}
        }; 

        public override void onCall(List<String> args)
        {
            if (args.Count == 1) args.Add("list");

            foreach (String k in CommandList.Keys)
                if (k == args[1]) 
                {
                    CommandList[k](args);
                    return;
                }
            w.writeline("alarm: command not found. 'alarm help' for help");
        }
        private static void onHelp(List<String> args)
        {
            w.writeline("<All available alarm commands>");
            foreach (String i in CommandList.Keys) w.write(i + " ");
            w.write("\n");
        }
        private static void listAlarm(List<String> args)
        {
            w.writeline($"&bname, type, ringtime, enabled, skip"+ base_.SHELL_DEFAULT_COLORCODE_STRING);

            foreach (alarm a in alarm.AlarmList) 
                w.writeline($"'{a.Name}' '{a.Type.ToString()}' {a.RingTime[0].ToString()+":"+a.RingTime[1].ToString()}"
                + $" {a.Enabled} {a.Skip}");

        }
        private static void startAlarm(List<String> args) // start stopwatch type alarm
        {
            alarm a = alarm.AlarmList.Find(aa => aa.Name == args[2]);
            if (a.Type != alarm.AlarmType.Stopwatch) w.writeline("This alarm rings automatically.");
            else {

                int dmin = alarm.MinuteModularConvert((alarm.nmin+1) + a.PreSleepPrepareTime + a.PreSleepTime + a.SleepTime);
                int modm = dmin%60;
                int modh = (dmin - modm) / 60;
                a.RingTime = new int[] {modh, modm};
                w.writeline("Changes will be applied at the next minute.");
            } 
        }
        private static void exportAlarm(List<String> args)
        {
            String filename = CommandTemplate.ArgsToString(args);
            w.writeline("Saving current alarm data to '" + filename+"'");
            alarm.SaveCurrentAlarm(filename);
            w.writeline("done");
        }
        private static void ShowAlarmFilePath(List<String> args) => w.writeline("Last loaded file: "+alarm.AlarmFilePath);
        private static void editAlarm(List<String> args) => System.Diagnostics.Process.Start("open",alarm.AlarmFilePath);
        private static void reloadAlarm(List<String> args) => alarm.LoadAlarm(alarm.AlarmFilePath);
        private static void importAlarm(List<String> args) => alarm.LoadAlarm(CommandTemplate.ArgsToString(args));
        private static void disableAlarm(List<String> args) => alarm.AlarmList.Find(aa => aa.Name == args[2]).Enabled = false;
        private static void enableAlarm(List<String> args) => alarm.AlarmList.Find(aa => aa.Name == args[2]).Enabled = true;
        private static void skipAlarm(List<String> args) => alarm.AlarmList.Find(aa => aa.Name == args[2]).Skip = true;
        private static void unskipAlarm(List<String> args) => alarm.AlarmList.Find(aa => aa.Name == args[2]).Skip = false;
        private static void callAlarmNow(List<String> args) => alarm.RaiseRing(alarm.AlarmRingType.Ring, new alarm());



       
    }
}