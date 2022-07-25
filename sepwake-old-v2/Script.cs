using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;

namespace sepWake2{
    public static class alarmttsScript{

        public static String DateTimeDateString{
            get{
                return alarm.DateTimeNow.DayOfWeek.ToString() + ";"
                + GetEnglishMonthString(alarm.DateTimeNow.Month) + alarm.DateTimeNow.ToString(" dd, yyyy");
            }
        }

        public static String DateTimeTimeString{
            get{
                string a = alarm.DateTimeNow.Hour < 12 ? "AM" : "PM";
                string h = "";
                int hh = alarm.DateTimeNow.Hour;

                if (hh==12 || hh==0) h = "12";
                else h = (hh%12).ToString();
                return alarm.DateTimeNow.ToString($" {h}:mm") + a;
            }
        }



        public static List<string> TTSRingScript(alarm a)
        {

                String goodmorningstr = "";
                switch(alarm.DateTimeNow.Day%7)
                {
                    case 0: goodmorningstr = "Rise and shine!"; break;
                    case 1: goodmorningstr = "Top of the morning to you!"; break;
                    case 2: goodmorningstr = "Good morning!"; break;
                    case 3: goodmorningstr = "What a pleasant morning we are having."; break;
                    case 4: goodmorningstr = "Wakey, wakey, eggs and bakey."; break;
                    case 5: goodmorningstr = "Good morning, sleepyhead!"; break;
                    case 6: goodmorningstr = "Good morning!"; break;
                }

                String endstr = "";
                switch(alarm.DateTimeNow.Day%6)
                {
                    case 0: endstr = "Have a good day!"; break;
                    case 1: endstr = "Have an awesome day!"; break;
                    case 2: endstr = "I hope your day is great!"; break;
                    case 3: endstr = "Today will be the best!"; break;
                    case 4: endstr = "Have a nice day."; break;
                    case 5: endstr = "Have a pleasant day."; break;
                }

                return new List<string> 
                {
                    $"{goodmorningstr} Today is {DateTimeDateString}, the {a.Count}th joyo project day. Current time is {DateTimeTimeString}.",
                    $"{endstr}" //todo: weatehr

                };
        }

        public static List<string> TTSPresleepPrepareScript(alarm a)
        {
            String greetingstr = "";
            switch(alarm.DateTimeNow.Day%3)
            {
                case 0: greetingstr = "I hope you had and will have a great day."; break;
                case 1: greetingstr = "Nice to see you again!"; break;
                case 2: greetingstr = "I have been called once again! Thank you for not forgetting to wake me up."; break;
            }

            String countstr = "";
            if (a.Count == 0) countstr = "Well, we have finally finished development. Me and you, we are both going through the "
                 + "way full of fog and myths. We are not sure to succeed, but we got to do it. Well then; good luck; and have fun.";
            else if (a.Count%100==0) countstr = $"Congratulations!; {a.Count} days,; You have made this far!;"
            + "You are continuously proving yourself of limitless potential. Keep the good work and Let's go as far as we can;"
            + "Your digital version yourself really appreciate you.";
            else if (a.Count%365==0) countstr = $"Oh my swirls, it has been {a.Count/365} years!; As a digital myself, I have so many things"
            + " I want to do with you, but this digital voice may not reach there quite well.; Hope you please take me out from here.;"
            + "You are continuously proving yourself of limitless potential. Keep the good work and Let's go as far as we can.;"
            + "Your digital version yourself really, really appreciate you.";
            else switch (alarm.DateTimeNow.Day%3)
            {
                case 0: countstr = "Nice progress you made by here!";break;
                case 1: countstr = "You are doing great. Keep the good work.";break;
                case 2: countstr = "I can see you getting better day by day. You are doing great job.";break;
            }

            String goodnightstr = "";
            switch (alarm.DateTimeNow.Day%7)
            {
                case 0: goodnightstr = "Nighty night!"; break;
                case 1: goodnightstr = "Sleep well!"; break;
                case 2: goodnightstr = "Have a good sleep!"; break;
                case 3: goodnightstr = "Lights out!"; break;
                case 4: goodnightstr = "I'll be dreaming of you!"; break;
                case 5: goodnightstr = "See you in the morning!"; break;
                case 6: goodnightstr = "Sleep tight!"; break;
            }

            return new List<string> 
            {
                $"Hello there! {greetingstr}",
                $"Today was {a.Count}th day of joyo project. {countstr}",
                $"You will sleep from {alarm.MinuteIntToString(a.dmin-a.SleepTime)}" + 
                $"; to {alarm.MinuteIntToString(a.dmin)}, therefore sleeping {string.Format("{0:0.00}", a.SleepTime/60)} hours.",
                $"You have been given {a.PreSleepPrepareTime} minutes of sleep preparation time,; and {a.PreSleepTime} minutes of "+
                $"pre-sleep time. Please prepare your sleeping environments.",
                $"{goodnightstr} Good night."
            };
        }

        public static List<string> TTSPresleepBeginScript (alarm a)
        {
           return new List<string> {}; 
        } 


        public static string GetEnglishMonthString(int m) 
        {

            switch (m)
            {
                case 1: return "January";
                case 2: return "February";
                case 3: return "March";
                case 4: return "April";                
                case 5: return "May";
                case 6: return "June";
                case 7: return "July";                 
                case 8: return "August";
                case 9: return "September";
                case 10: return "October";              
                case 11: return "November";
                case 12: return "December";                        
                default:
                    return null;
            }

        } 

    }

}