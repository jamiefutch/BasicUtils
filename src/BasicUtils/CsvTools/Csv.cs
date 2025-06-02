#pragma warning disable CS1587 // XML comment is not placed on a valid language element
/** 
The MIT License (MIT)
Copyright © 2025 Jamie Futch

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

// ReSharper disable once CheckNamespace
namespace BasicUtils;

/// <summary>
/// Provides utility methods for simple CSV (Comma-Separated Values) file operations, including loading, saving, and header extraction.
/// </summary>
public static class Csv
{
    // <summary>
    /// Loads the contents of a CSV file into a string array, where each element represents a line from the file. 
    /// <param name="path">The file path to the CSV file.</param>
    /// <param name="hasHeader">If true, skips the first line (header) in the result.</param>
    /// <returns>An array of strings, each representing a line from the CSV file.</returns>
    [Obsolete("Use CsvTools.CsvUtils.LoadRawCsv instead. This method will be removed in a future version.", false)]
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
    /// Asynchronously loads the contents of a CSV file into a string array, where each element represents a line from the file.
    /// </summary>
    /// <param name="path">The file path to the CSV file.</param>
    /// <param name="hasHeader">If true, skips the first line (header) in the result.</param>
    /// <returns>A task representing the asynchronous operation, with a result of an array of strings, each representing a line from the CSV file.</returns>
    [Obsolete("Use CsvTools.CsvUtils.LoadRawCsvAsync instead. This method will be removed in a future version.", false)]
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
    /// Loads the contents of a CSV file into a list of string arrays, where each array represents a row split by the specified delimiter.
    /// </summary>
    /// <param name="path">The file path to the CSV file.</param>
    /// <param name="delimiter">The character used to separate values in the CSV file. Defaults to ','.</param>
    /// <param name="hasHeader">If true, skips the first line (header) in the result.</param>
    /// <returns>A list of string arrays, each representing a row from the CSV file.</returns>
    [Obsolete("Use CsvTools.CsvUtils.Load instead. This method will be removed in a future version.", false)]
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
    /// Asynchronously loads the contents of a CSV file into a list of string arrays, where each array represents a row split by the specified delimiter.
    /// </summary>
    /// <param name="path">The file path to the CSV file.</param>
    /// <param name="delimiter">The character used to separate values in the CSV file. Defaults to ','.</param>
    /// <param name="hasHeader">If true, skips the first line (header) in the result.</param>
    /// <returns>A task representing the asynchronous operation, with a result of a list of string arrays, each representing a row from the CSV file.</returns>
    [Obsolete("Use CsvTools.CsvUtils.LoadAsync instead. This method will be removed in a future version.", false)]
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
    /// Saves a list of string arrays to a CSV file, using the specified delimiter to separate values.
    /// </summary>
    /// <param name="path">The file path to save the CSV file to.</param>
    /// <param name="data">The list of string arrays to write to the file. Each array represents a row.</param>
    /// <param name="delimiter">The character used to separate values in the CSV file. Defaults to ','.</param>
    [Obsolete("Use CsvTools.CsvUtils.Save instead. This method will be removed in a future version.", false)]
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
    /// Asynchronously saves a list of string arrays to a CSV file, using the specified delimiter to separate values.
    /// </summary>
    /// <param name="path">The file path to save the CSV file to.</param>
    /// <param name="data">The list of string arrays to write to the file. Each array represents a row.</param>
    /// <param name="delimiter">The character used to separate values in the CSV file. Defaults to ','.</param>
    /// <returns>A task representing the asynchronous save operation.</returns>
    [Obsolete("Use CsvTools.CsvUtils.SaveAsync instead. This method will be removed in a future version.", false)]
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
    /// Retrieves the header row from a CSV file as an array of column names.
    /// </summary>
    /// <param name="path">The file path to the CSV file.</param>
    /// <param name="delimiter">The character used to separate values in the CSV file. Defaults to ','.</param>
    /// <returns>An array of strings representing the column headers, or an empty array if the file is empty.</returns>
    [Obsolete("Use CsvTools.CsvUtils.GetHeadersFromFile instead. This method will be removed in a future version.", false)]
    public static string[] GetHeadersFromFile(string path, char delimiter = ',')
    {
        using var reader = new StreamReader(path);
        var line = reader.ReadLine();
        return line != null ? line.Split(delimiter) : [];
    }

    /// <summary>
    /// Asynchronously retrieves the header row from a CSV file as an array of column names.
    /// </summary>
    /// <param name="path">The file path to the CSV file.</param>
    /// <param name="delimiter">The character used to separate values in the CSV file. Defaults to ','.</param>
    /// <returns>A task representing the asynchronous operation, with a result of an array of strings representing the column headers, or an empty array if the file is empty.</returns>
    [Obsolete("Use CsvTools.CsvUtils.GetHeadersFromFileAsync instead. This method will be removed in a future version.", false)]
    public static async Task<string[]> GetHeadersFromFileAsync(string path, char delimiter = ',')
    {
        using var reader = new StreamReader(path);
        var line = await reader.ReadLineAsync();
        return line != null ? line.Split(delimiter) : [];
    }

    /// <summary>
    /// Retrieves the header row from a raw CSV string array as an array of column names.
    /// </summary>
    /// <param name="csv">The array of CSV lines, where the first element is expected to be the header row.</param>
    /// <param name="delimiter">The character used to separate values in the CSV data. Defaults to ','.</param>
    /// <returns>An array of strings representing the column headers.</returns>
    [Obsolete("Use CsvTools.CsvUtils.GetHeadersFromRawCsv instead. This method will be removed in a future version.", false)]
    public static string[] GetHeadersFromRawCsv(string[] csv, char delimiter = ',')
    {
        return csv[0].Split(delimiter);
    }
}