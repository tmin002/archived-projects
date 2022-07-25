using System;
using System.Collections.Generic;
using System.Threading;

namespace sepWake2
{
    public partial class alarm
    {

        public static void LoadAlarm(String file)
        {
            if (AlarmList == null) AlarmList = new List<alarm> {};
            else AlarmList.Clear();

            ConfigContainer cc = ConfigLoader.LoadConfigFromFile(file); if (cc == null)
            {
                w.infoprint("&cLoadAlarm(): cc is null" + base_.SHELL_DEFAULT_COLORCODE_STRING);
                return;
            }

            foreach (ConfigGroup cg in cc.Items)
            {
                alarm a = new alarm();
                a.Name = cg.GroupName;

                foreach (String k in cg.GroupItems.Keys)
                {
                    if (k == "RingTime")
                    {
                        String[] raw = cg.GroupItems[k].Split(':',2);
                        a.RingTime = new int[] {int.Parse(raw[0]), int.Parse(raw[1])};
                    }
                    if (k == "AlarmType")
                    {
                        if (cg.GroupItems[k].ToUpper() == "STANDARD") a.Type = alarm.AlarmType.Standard;
                        if (cg.GroupItems[k].ToUpper() == "STOPWATCH") 
                        {
                            a.Type = alarm.AlarmType.Stopwatch;
                            a.RingTime[0] = -1;
                            a.RingTime[1] = -1; //making it impossible to catch event without getting assigned
                        }
                    }
                    if (k == "Count") a.Count = int.Parse(cg.GroupItems[k]);
                    if (k == "PresleepTime") a.PreSleepTime = int.Parse(cg.GroupItems[k]);
                    if (k == "SleepTime") a.SleepTime = int.Parse(cg.GroupItems[k]);
                    if (k == "PresleepPrepareTime") a.PreSleepPrepareTime = int.Parse(cg.GroupItems[k]);
                    if (k == "Enabled") a.Enabled = cg.GroupItems[k].ToUpper() == "TRUE";
                    if (k == "PresleepEnabled") a.PreSleepEnable = cg.GroupItems[k].ToUpper() == "TRUE";
                }

                AlarmList.Add(a);
            }

            alarm.AlarmFilePath = file;

        }

        public static void SaveCurrentAlarm(String file)
        {
            ConfigContainer cc = new ConfigContainer();

            foreach (alarm a in alarm.AlarmList)
            {
                ConfigGroup cg = new ConfigGroup();
                cg.GroupName = a.Name;
                cg.GroupItems["RingTime"] = a.RingTime[0].ToString() + ":" + a.RingTime[1].ToString();
                cg.GroupItems["AlarmType"] = a.Type.ToString();
                cg.GroupItems["Count"] = a.Count.ToString();
                cg.GroupItems["PresleepTime"] = a.PreSleepTime.ToString();
                cg.GroupItems["PresleepPrepareTime"] = a.PreSleepPrepareTime.ToString();
                cg.GroupItems["SleepTime"] = a.SleepTime.ToString();
                cg.GroupItems["Enabled"] = a.Enabled.ToString();
                cg.GroupItems["PresleepEnabled"] = a.PreSleepEnable.ToString();

                cc.Items.Add(cg);
            }

            ConfigLoader.SaveConfigToFile(cc, file);

        }

    }
}
