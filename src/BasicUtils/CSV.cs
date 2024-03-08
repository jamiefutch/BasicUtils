using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace BasicUtils
{
    /// <summary>
    /// support for simple CSV operations
    /// </summary>
    public static class CSV
    {
        /// <summary>
        /// loads the raw CSV file into a string array (one dimension)
        /// </summary>
        /// <param name="path"></param>
        /// <param name="hasHeader"></param>
        /// <returns>csv as array of csv lines</returns>
        public static string[] LoadRawCsv(string path, 
            bool hasHeader = true)        
        {
            if (!hasHeader)
            {
                return System.IO.File.ReadAllLines(path);
            }
            else
            {
                var records = new List<string>();
                using (var reader = new StreamReader(path))
                {
                    bool isFirstLine = true;
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (isFirstLine)
                        {
                            isFirstLine = false;
                            continue;
                        }                        
                        records.Add(line);
                    }
                }
                return records.ToArray();
            }
        }

        
        /// <summary>
        /// loads the CSV file into a list of string arrays
        /// </summary>
        /// <param name="path"></param>
        /// <param name="delimiter"></param>
        /// <param name="hasHeader"></param>
        /// <returns>list of string arrays</returns>
        public static List<string[]> Load(string path, 
            char delimiter = ',',
            bool hasHeader = true)
        {
            if (!hasHeader)
            {
                return System.IO.File.ReadAllLines(path)
                    .Select(v => v.Split(delimiter))
                    .ToList();
            }
            else
            {
                var records = new List<string[]>();
                using (var reader = new StreamReader(path))
                {
                    bool isFirstLine = true;
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (isFirstLine)
                        {
                            isFirstLine = false;
                            continue;
                        }
                        records.Add(line.Split(delimiter));
                    }
                }                
                return records;
            }
        }
        
    }
}
