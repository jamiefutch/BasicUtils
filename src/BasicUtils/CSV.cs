/** 
The MIT License (MIT)
Copyright © 2024 Jamie Futch

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
**/
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicUtils
{
    /// <summary>
    /// support for simple CSV operations
    /// </summary>
    public static class Csv
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
        /// async loads the raw CSV file into a string array (one dimension)
        /// </summary>
        /// <param name="path"></param>
        /// <param name="hasHeader"></param>
        /// <returns>csv as array of csv lines</returns>
        public static async Task<string[]> LoadRawCsvAsync(string path,
            bool hasHeader = true)
        {
            if (!hasHeader)
            {
                return await System.IO.File.ReadAllLinesAsync(System.IO.Path.GetFullPath(path));
            }
            else
            {
                var records = new List<string>();
                using (var reader = new StreamReader(path))
                {
                    bool isFirstLine = true;
                    while (!reader.EndOfStream)
                    {
                        var line = await reader.ReadLineAsync();
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
                using var reader = new StreamReader(path);
                bool isFirstLine = true;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (isFirstLine)
                    {
                        isFirstLine = false;
                        continue;
                    }

                    if (line != null) records.Add(line.Split(delimiter));
                }
                return records;
            }
        }        
        

        /// <summary>
        /// async loads the CSV file into a list of string arrays
        /// </summary>
        /// <param name="path"></param>
        /// <param name="delimiter"></param>
        /// <param name="hasHeader"></param>
        /// <returns></returns>
        public static async Task<List<string[]>> LoadAsync(string path,
            char delimiter = ',',
            bool hasHeader = true)
        {
            if (!hasHeader)
            {
                var lines = await System.IO.File.ReadAllLinesAsync(path);
                return lines.Select(v => v.Split(delimiter))
                    .ToList();                
            }
            else
            {
                var records = new List<string[]>();
                using var reader = new StreamReader(path);
                bool isFirstLine = true;
                while (!reader.EndOfStream)
                {
                    var line = await reader.ReadLineAsync();
                    if (isFirstLine)
                    {
                        isFirstLine = false;
                        continue;
                    }

                    if (line != null) records.Add(line.Split(delimiter));
                }
                return records;
            }
        }

        /// <summary>
        /// saves a list of string arrays to a CSV file
        /// </summary>
        /// <param name="path"></param>
        /// <param name="data"></param>
        /// <param name="delimiter"></param>
        public static void Save(string path,
                       List<string[]> data, 
                                  char delimiter = ',')
        {
            var sb = new StringBuilder();
            foreach (var record in data)
            {
                sb.AppendLine(string.Join(delimiter, record));
            }
            System.IO.File.WriteAllText(path, sb.ToString());
        }

        /// <summary>
        /// async saves a list of string arrays to a CSV file
        /// </summary>
        /// <param name="path"></param>
        /// <param name="data"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static async Task SaveAsync(string path,
                       List<string[]> data,
                                  char delimiter = ',')
        {
            var sb = new StringBuilder();
            foreach (var record in data)
            {
                sb.AppendLine(string.Join(delimiter, record));
            }
            await System.IO.File.WriteAllTextAsync(path, sb.ToString());
        }

        /// <summary>
        /// returns the headers from a CSV file
        /// </summary>
        /// <param name="path"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static string[] GetHeadersFromFile(string path, char delimiter = ',')
        {
            using var reader = new StreamReader(path);
            var line = reader.ReadLine();
            return line != null ? line.Split(delimiter) : new string[] { };
        }

        /// <summary>
        /// async returns the headers from a CSV file
        /// </summary>
        /// <param name="path"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static async Task<string[]> GetHeadersFromFileAsync(string path, char delimiter = ',')
        {
            using var reader = new StreamReader(path);
            var line = await reader.ReadLineAsync();
            return line != null ? line.Split(delimiter) : new string[] { };
        }

        /// <summary>
        /// returns the headers from a raw CSV string array
        /// </summary>
        /// <param name="csv"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static string[] GetHeadersFromRawCsv(string[] csv, char delimiter = ',')
        {
            return csv[0].Split(delimiter);
        }
    }
}
