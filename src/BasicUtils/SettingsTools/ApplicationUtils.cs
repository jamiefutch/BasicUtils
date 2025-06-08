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
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BasicUtils.SettingsTools;

/// <summary>
/// Provides utility methods for loading application settings from JSON files.
/// </summary>
public class ApplicationUtils : IDisposable
{
    /// <summary>
    /// Loads application settings from a JSON file into a dictionary.
    /// </summary>
    /// <param name="path">The file path to the JSON settings file.</param>
    /// <returns>
    /// A <see cref="Dictionary{TKey, TValue}"/> containing the settings as key-value pairs.
    /// </returns>
    /// <exception cref="IOException">Thrown if the file cannot be read.</exception>
    /// <exception cref="JsonException">Thrown if the file content is not valid JSON.</exception>
    /// <exception cref="Exception">Thrown for other errors during file reading or deserialization.</exception>
    public static Dictionary<string, string> LoadSettings(string path)
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
    /// Loads application settings from a JSON file and deserializes them into a strongly-typed object.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the settings into.</typeparam>
    /// <param name="path">The file path to the JSON settings file.</param>
    /// <param name="settingsType">An instance of the type <typeparamref name="T"/> (not used, but required for method signature compatibility).</param>
    /// <returns>
    /// An instance of type <typeparamref name="T"/> containing the deserialized settings.
    /// </returns>
    /// <exception cref="IOException">Thrown if the file cannot be read.</exception>
    /// <exception cref="JsonException">Thrown if the file content is not valid JSON or cannot be deserialized to <typeparamref name="T"/>.</exception>
    /// <exception cref="Exception">Thrown for other errors during file reading or deserialization.</exception>
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

    /// <summary>
    /// Releases all resources used by the <see cref="ApplicationUtils"/> instance.
    /// </summary>
    /// <remarks>
    /// This method is called to perform cleanup operations, such as releasing unmanaged resources.
    /// It suppresses the finalization of the object to optimize garbage collection.
    /// </remarks>
    public void Dispose()
    {
        // Dispose logic for ApplicationUtils
        GC.SuppressFinalize(this);
    }
}