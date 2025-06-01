using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicUtils.ML
{
    public class MlUtils : IDisposable
    {

        /// <summary>
        /// Extracts all unique n-grams of the specified length from the given string.
        /// The input string is first cleaned by removing punctuation, symbols, and extra spaces.
        /// N-grams are returned as strings with words joined by the '|' character.
        /// </summary>
        /// <param name="text">The input string from which to extract n-grams.</param>
        /// <param name="length">The number of words in each n-gram.</param>
        /// <returns>
        /// A list of unique n-gram strings, or an empty list if no n-grams are found.
        /// </returns>
        public static List<string> GetNgramsFromString(string text, int length)
        {
            text = text.RemovePunctuation().RemoveSymbols().RemoveMultipleSpaces().Trim();
            var ngrams = new HashSet<string>();
            var arr = text.Split(' ');

            for (var i = 0; i < arr.Length - length + 1; i++)
            {
                StringBuilder sb = new StringBuilder(arr[i]);

                for (var j = 1; j < length; j++)
                {
                    sb.Append("|");
                    sb.Append(arr[i + j]);
                }

                ngrams.Add(sb.ToString());
            }

            return ngrams.Count > 0 ? ngrams.ToList() : new List<string>();
        }

        /// <summary>
        /// Asynchronously extracts all unique n-grams of the specified length from the given string.
        /// The input string is first cleaned by removing punctuation, symbols, and extra spaces.
        /// N-grams are returned as strings with words joined by the '|' character.
        /// </summary>
        /// <param name="text">The input string from which to extract n-grams.</param>
        /// <param name="length">The number of words in each n-gram.</param>
        /// <returns>
        /// A task representing the asynchronous operation, with a result of a list of unique n-gram strings,
        /// or an empty list if no n-grams are found.
        /// </returns>
        public static async Task<List<string>> GetNgramsFromStringAsync(string text, int length)
        {
            return await Task.Run(() =>
            {
                text = text.RemovePunctuation().RemoveSymbols().RemoveMultipleSpaces().Trim();
                var ngrams = new HashSet<string>();
                var arr = text.Split(' ');

                for (var i = 0; i < arr.Length - length + 1; i++)
                {
                    var sb = new StringBuilder(arr[i]);

                    for (var j = 1; j < length; j++)
                    {
                        sb.Append("|");
                        sb.Append(arr[i + j]);
                    }

                    ngrams.Add(sb.ToString());
                }

                return ngrams.Count > 0 ? ngrams.ToList() : new List<string>();
            });
        }


        public void Dispose()
        {
            
        }
    }
}
