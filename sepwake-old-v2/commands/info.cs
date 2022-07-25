using System;
using System.Collections.Generic;

namespace sepWake2
{
    public class infoCommand : CommandTemplate
    {
        public override String[] ComamndName => new String[] {"info"};
        public override String BriefHelp => "print text with info format";
        public override void onCall(List<String> args)
        {
            String raw = "";
            for (int i=1; i<args.Count; i++) raw += args[i] + " ";
            w.infoprint(raw);
        }
        

    }
}