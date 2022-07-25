using System;
using System.Collections.Generic;
using System.Threading;

namespace sepWake2
{
    public static class shell 
    {
        public static void init()
        {
            List<String> lastCmd = new List<string>();
            while (true)
            {
                w.write(base_.SHELL_PROMPT_STRING);

                String rawinput = Console.ReadLine();
                String onecmd = "";
                foreach (char c in rawinput)
                    if (c != ' ' && c != 9) onecmd += c;
                    else if (onecmd.Length != 0) 
                    {
                        lastCmd.Add(onecmd);
                        onecmd = "";
                    }
                if (onecmd.Length != 0) lastCmd.Add(onecmd);

                bool exe = false;
                if (lastCmd.Count != 0)
                {
                    foreach(CommandTemplate c in base_.SHELL_COMMANDS) 
                        foreach (String cmd in c.ComamndName)
                            if (lastCmd[0] == cmd) 
                            {
                                exe = true;
                                try { c.onCall(lastCmd); }
                                catch (Exception e)
                                { w.writeline("&c"+e.ToString()+base_.SHELL_DEFAULT_COLORCODE_STRING); }
                                break;
                            }

                        if (!exe) w.writeline("Unknown command. ? for help");
                }

                lastCmd.Clear();

            }

        }
    }
}