using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace sepWake2
{
    public static class osascript
    {

        private static Process osa = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = "osascript",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    StandardErrorEncoding = System.Text.Encoding.UTF8,
                    StandardOutputEncoding = System.Text.Encoding.UTF8
                    //args are to be added by following..
                }
            };

        /*public static string executeOsaScripts(List<string> args, bool getOutput = false)
        {

            foreach (string i in args) osa.StartInfo.Arguments += $"-e \"{i}\" ";
            return executeOsaInternal(osa.StartInfo.Arguments, getOutput);

        }*/
    

        public static string executeOsaScript(string args, bool getOutput = false)
        {
            return executeOsaInternal($"-e \"{args}\"", getOutput);
        }

        private static string executeOsaInternal(string args, bool getOutput = false)
        {
            osa.StartInfo.Arguments = args;
            osa.Start();

            string a = osa.StandardOutput.ReadToEnd();
            //string b = osa.StandardError.ReadToEnd();

            //Console.WriteLine($"* {osa.StartInfo.Arguments} => {a}\n{b}");

            if (getOutput) return a;
            return null;
        }

    }
}