using System;
using System.IO;
using System.Collections.Generic;

namespace sepWake2
{
    public static class w
    {
        public static List<String> Buffer = new List<string> {};

        public static void infoprint(Object text) 
            => writeline($"&7[{alarm.DateTimeNow}] {text} {base_.SHELL_DEFAULT_COLORCODE_STRING}");

        public static void write(Object text)
        {
            String t = text.ToString();
            int len = t.Length;
            List<char> colorlist = new List<char>() {
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
                'a', 'b', 'c', 'd', 'e', 'f'
                };

            //MemoryStream a = new MemoryStream();
            //a.ReadAsync

            for (int c=0; c<text.ToString().Length; c++)
            {
                if (c != len-1 && t[c] =='&' && colorlist.Exists(a => a == t[c+1]))
                {
                    String co = t[c+1].ToString();
                    int cof;
                    switch (co)
                    {
                        case "a": cof = 10; break;
                        case "b": cof = 11; break;
                        case "c": cof = 12; break;
                        case "d": cof = 13; break;
                        case "e": cof = 14; break;
                        case "f": cof = 15; break;
                        default: cof = int.Parse(co); break;
                    }
                   Console.ForegroundColor = (ConsoleColor)cof;
                   c++;
                   continue;
                }
                else Console.Write(t[c]);
            }
        }

        public static void writeline(Object text) => write(text + "\n");

    }
}
