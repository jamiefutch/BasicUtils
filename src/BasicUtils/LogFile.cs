using System;
using System.IO;

namespace BasicUtils
{
    public static class LogFile
    {

        public static void WriteToLog(string LogPath, string LogMsg)
        {
            string path = LogPath;

            const string linebreak = "============================================================================";

            string FileName = GetCurrentTimeString() + ".txt";

            if (path.LastIndexOf('\\') != path.Length - 1)
                path = path += "\\";

            path = path += FileName;

            if (!File.Exists(path))
            {
                // Create a file to write to. 
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(linebreak);
                    sw.WriteLine(String.Format("{0:MM/dd/yyyy H:m:ss}", DateTime.Now));
                    sw.WriteLine("");
                    sw.WriteLine(LogMsg);
                    sw.WriteLine(linebreak);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(linebreak);
                    sw.WriteLine(String.Format("{0:MM/dd/yyyy H:m:ss}", DateTime.Now));
                    sw.WriteLine("");
                    sw.WriteLine(LogMsg);
                    sw.WriteLine(linebreak);
                }
            }
        }

        private static string GetCurrentTimeString()
        {
            //return String.Format("{0:MMddyyyy_H_mm_ss_ffff}", DateTime.Now);
            return String.Format("{0:MMddyyyy}", DateTime.Now);
        }

    }
}