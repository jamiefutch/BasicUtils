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
    /// Provides basic file-based logging functionality for writing messages to log files.
    /// </summary>
    public static class LogFile
    {
        /// <summary>
        /// Writes a log message to a file in the specified directory. 
        /// The log file is named with the current date in "MMddyyyy.txt" format. 
        /// Each log entry is separated by a line of equal signs and includes a timestamp.
        /// </summary>
        /// <param name="logPath">The directory path where the log file will be created or appended.</param>
        /// <param name="logMsg">The message to write to the log file.</param>
        /// <remarks>
        /// If the specified directory does not end with a backslash, one is automatically added.
        /// If the log file for the current date does not exist, it is created; otherwise, the message is appended.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown if <paramref name="logPath"/> is null or empty.</exception>
        /// <exception cref="IOException">Thrown if the file cannot be created or written to.</exception>
        [Obsolete("Use Logs.LogUtils.WriteTolog")]
        public static void WriteToLog(string logPath, string logMsg)
        {
            if (string.IsNullOrWhiteSpace(logPath))
            {
                throw new ArgumentException("Log path cannot be null or empty.", nameof(logPath));
            }

            const string linebreak = @"============================================================================";

            string fileName = GetCurrentTimeString() + ".txt";

            if (!logPath.EndsWith("\\"))
            {
                logPath += "\\";
            }

            string fullPath = logPath + fileName;

            try
            {
                if (!File.Exists(fullPath))
                {
                    // Create a file to write to. 
                    using StreamWriter sw = File.CreateText(fullPath);
                    sw.WriteLine(linebreak);
                    sw.WriteLine($"{DateTime.Now:MM/dd/yyyy H:m:ss}");
                    sw.WriteLine("");
                    sw.WriteLine(logMsg);
                    sw.WriteLine(linebreak);
                }
                else
                {
                    using StreamWriter sw = File.AppendText(fullPath);
                    sw.WriteLine(linebreak);
                    sw.WriteLine($"{DateTime.Now:MM/dd/yyyy H:m:ss}");
                    sw.WriteLine("");
                    sw.WriteLine(logMsg);
                    sw.WriteLine(linebreak);
                }
            }
            catch (IOException ex)
            {
                throw new IOException("An error occurred while writing to the log file.", ex);
            }
        }

        /// <summary>
        /// Gets the current date as a string in the format "MMddyyyy".
        /// </summary>
        /// <returns>
        /// A string representing the current date in "MMddyyyy" format.
        /// </returns>
        private static string GetCurrentTimeString()
        {
            return $"{DateTime.Now:MMddyyyy}";
        }
    }
}