#pragma warning disable CS1587 // XML comment is not placed on a valid language element
/** 
The MIT License (MIT)
Copyright © 2025 Jamie Futch

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
**/
using System;
using System.IO;

namespace BasicUtils
{
    /// <summary>
    /// very basic logging class
    /// </summary>
    public static class LogFile
    {

        /// <summary>
        /// writes a message to a log file
        /// </summary>
        /// <param name="LogPath"></param>
        /// <param name="LogMsg"></param>
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

        /// <summary>
        /// gets the current time as a string in the format MMddyyyy
        /// </summary>
        /// <returns></returns>
        private static string GetCurrentTimeString()
        {
            //return String.Format("{0:MMddyyyy_H_mm_ss_ffff}", DateTime.Now);
            return String.Format("{0:MMddyyyy}", DateTime.Now);
        }

    }
}