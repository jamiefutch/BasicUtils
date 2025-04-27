#pragma warning disable CS1587 // XML comment is not placed on a valid language element
/**
The MIT License (MIT)
Copyright © 2025 Jamie Futch

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
**/
#pragma warning restore CS1587 // XML comment is not placed on a valid language element
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace BasicUtils
{
    /// <summary>
    /// Application settings utility class
    /// </summary>
    public static class AppSettings
    {
        /// <summary>
        /// Loads settings from a json file
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Dictionary<string,string> LoadSettings(string path)
        {
            Dictionary<string, string> settings;
            try
            {
                var json = File.ReadAllText(path);
                settings = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return settings;
        }

        /// <summary>
        /// Loads settings from a json file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="settingsType"></param>
        /// <returns></returns>
        public static T LoadSettings<T>(string path, T settingsType)
        {
            try
            {
                var json = File.ReadAllText(path);
                var settings = JsonSerializer.Deserialize<T>(json);
                return settings;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
