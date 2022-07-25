using System;
using System.Collections.Generic;

namespace sepWake2
{
    public class echoCommand : CommandTemplate
    {
        public override String[] ComamndName => new String[] {"echo"};
        public override String BriefHelp => "print text";
        public override void onCall(List<String> args)
        {
            for (int i=1; i<args.Count; i++) w.write(args[i] + " ");
            w.write("\n");
        }
        

    }
}