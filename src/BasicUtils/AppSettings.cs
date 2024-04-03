﻿using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using System.Text;
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
