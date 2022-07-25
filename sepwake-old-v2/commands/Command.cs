using System;
using System.Collections.Generic;

namespace sepWake2
{
    public abstract class CommandTemplate 
    {
        public abstract String[] ComamndName{get;}
        public abstract String BriefHelp{get;}
        public abstract void onCall(List<String> args);

        public static String ArgsToString(List<string> args)
        {
            String str = "";
            int i=2;

            for (i=2; i<args.Count-1; i++) str += args[i] + " ";
            str += args[i];

            return str;
        }
    }
}