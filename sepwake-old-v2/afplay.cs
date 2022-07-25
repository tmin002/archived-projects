using System;
using System.Diagnostics;
using System.Threading;

namespace sepWake2{
    public static class afplay
    {

        private static Process afp = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = "afplay",
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

        public static void playSound(String path)
        {
            afp.StartInfo.Arguments = path;
            afp.Start();
            afp.WaitForExit();
        }

        public static void playSoundAsync(String path)
        {
            w.infoprint($"[afp] {path}");
            afp.StartInfo.Arguments = path;
            afp.Start();
        }

    }
}