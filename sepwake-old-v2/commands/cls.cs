using System;
using System.Collections.Generic;

namespace sepWake2
{
    public class clearCommand : CommandTemplate
    {
        public override String[] ComamndName => new String[] {"cls", "clear"};
        public override String BriefHelp => "clear screen";
        public override void onCall(List<String> args) => Console.Clear();

    }
}