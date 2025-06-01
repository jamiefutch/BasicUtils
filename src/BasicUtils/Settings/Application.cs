using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BasicUtils.Settings
{
    public class Application : IDisposable
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

        public void Dispose()
        {
        }
    }
}
