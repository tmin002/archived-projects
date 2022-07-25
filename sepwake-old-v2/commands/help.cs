using System;
using System.Collections.Generic;

namespace sepWake2
{
    public class helpCommand : CommandTemplate
    {

        public override String[] ComamndName => new String[] {"help", "?"};
        public override String BriefHelp => "show available commands and descriptions";
        public override void onCall(List<String> args)
        {
            w.write("<List of all available commands>\n");

            foreach (CommandTemplate i in base_.SHELL_COMMANDS)
            {
                foreach (String j in i.ComamndName) w.write($"{j} ");
                w.writeline(": " + i.BriefHelp);
            }
        }

       
    }
}