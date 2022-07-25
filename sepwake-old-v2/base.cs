using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;

namespace sepWake2
{
    public static class base_
    {

        public static CommandTemplate[] SHELL_COMMANDS = {
            new clearCommand(),
            new exitCommand(),
            new helpCommand(),
            new echoCommand(),
            new infoCommand(),
            new alarmCommand()
        };
        public static String SHELL_DEFAULT_COLORCODE_STRING = "&f";

        public static String SHELL_PROMPT_STRING 
        {
            get { return $"&ajoyo {alarm.DateTimeNow.ToString("(yyyy-MM-dd hh:mm:ss)")}>{SHELL_DEFAULT_COLORCODE_STRING} "; }
        }

        ////////////
        ////////////
        ///////////

        public static int TTS_SCRIPT_DELAY = 400;

        ////////////
        ////////////
        ////////////

        public static String SEP_PWD = Environment.CurrentDirectory;

        public static String RemoveSpaces(string text)
            => text.Replace(" ","").Replace((char)9,(char)0);
        public static int StringToInt(string text) => int.Parse(text);

        ////////////
        ////////////
        ////////////

        public static String SOUND_PRESLEEP_PATH = SEP_PWD + "/presleep.wav";
        public static String SOUND_RING_PATH = SEP_PWD + "/ring.wav";
    }
}