using System;
using System.Collections.Generic;

namespace sepWake2
{
    public class exitCommand : CommandTemplate
    {

        public override String[] ComamndName => new String[] {"exit", "quit"};
        public override String BriefHelp => "terminate joyo project assistant";
        public override void onCall(List<String> args) => Environment.Exit(0);

    }
}