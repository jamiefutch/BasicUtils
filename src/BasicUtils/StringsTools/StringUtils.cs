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
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace BasicUtils.StringsTools;

/// <summary>
/// String Utility Class
/// </summary>
public class Utils :IDisposable
{
    private readonly Random _random;

    /// <summary>
    /// Initializes a new instance of the <see cref="Utils"/> class.
    /// </summary>
    public Utils()
    {
        _random = new Random();
    }

    /// <summary>
    /// Specifies the settings for generating random strings.
    /// </summary>
    /// <summary>
    /// Generates a random string containing only alphabetic characters.
    /// </summary>
    /// <summary>
    /// Generates a random string containing both alphabetic and numeric characters.
    /// </summary>
    /// <summary>
    /// Generates a random string containing alphabetic, numeric, and special characters.
    /// </summary>
    /// <summary>
    /// Generates a random string containing alphabetic, numeric, special characters, and spaces.
    /// </summary>
    public enum RandomStringSettings
    {
        /// <summary>
        /// Specifies that the random string should contain only alphabetic characters (A-Z, a-z).
        /// </summary>
        AlphaOnly = 0,
        /// <summary>
        /// Represents a setting for generating random strings that include both alphabetic characters and numeric digits.
        /// </summary>
        AlphaNumeric = 1,
        /// <summary>
        /// Specifies that the random string should include alphabetic characters, numeric digits, 
        /// and special characters.
        /// </summary>
        AlphaNumericSpecial = 2,
        /// <summary>
        /// Represents a setting for generating random strings that includes 
        /// alphanumeric characters, special characters, and spaces.
        /// </summary>
        AlphaNumericSpecialWithSpaces = 3
    }


    /// <summary>
    /// Generates a random string of the specified length using the specified character set.
    /// </summary>
    /// <param name="length">The length of the random string to generate. Must be a non-negative integer.</param>
    /// <param name="settings">
    /// Specifies the character set to use for generating the random string. 
    /// Defaults to <see cref="RandomStringSettings.AlphaNumericSpecialWithSpaces"/>.
    /// </param>
    /// <returns>A random string of the specified length composed of characters from the selected character set.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown if <paramref name="length"/> is less than zero.
    /// </exception>
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public string CreateRandomString(int length,
        RandomStringSettings settings = RandomStringSettings.AlphaNumericSpecialWithSpaces)
    {
        string chars;

        switch (settings)
        {
            case RandomStringSettings.AlphaOnly:
                chars = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                break;
            case RandomStringSettings.AlphaNumeric:
                chars = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                break;
            case RandomStringSettings.AlphaNumericSpecial:
                chars =
                    @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()-_=+[]{}|;:',.<>/?`~";
                break;
            case RandomStringSettings.AlphaNumericSpecialWithSpaces:
                chars =
                    @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()-_=+[]{}|;:',.<>/?`~ ";
                break;
            default:
                chars = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                break;
        }

        char[] result = new char[length];

        for (int i = 0; i < length; i++)
        {
            int index = _random.Next(chars.Length);
            result[i] = chars[index];
        }

        return new string(result);
    }

    #region WordCounts

    /// <summary>
    /// Represents a word and its associated count, typically used for word frequency analysis.
    /// </summary>
    public record WordCount
    {
        public string Word { get; set; }
        public int Count { get; set; }
    }


    /// <summary>
    /// Counts the occurrences of words in the provided text, splitting the text into lines - Windows OS.
    /// </summary>
    /// <param name="text">The input text to analyze. Each line in the text is treated as a separate window.</param>
    /// <returns>
    /// A dictionary where the key represents the window index (starting from 0) and the value is a <see cref="WordCount"/> structure
    /// containing the word and its associated count for that window.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="text"/> is <c>null</c>.</exception>
    WordCount[] CountWordsTextWindows(string text)
    {
        if (text == null)
            throw new ArgumentNullException(nameof(text), "Input text cannot be null.");

        var t = text.Trim();
        if (t.Length == 0)
            return [];

        t = t.RemovePunctuation().RemoveSymbols();
        // ReSharper disable once IdentifierTypo
        var textArray = t.Split("\r\n");

        if (textArray.Length == 0)
            return [];

        return GetWordUsages(textArray);
    }

    /// <summary>
    /// Counts the occurrences of words in the given text, splitting the text by Unix-style line breaks.
    /// </summary>
    /// <param name="text">The input text to analyze. Each line is processed separately.</param>
    /// <returns>
    /// A dictionary where the key is an integer representing the line number (starting from 0),
    /// and the value is a <see cref="WordCount"/> structure containing the word and its count.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="text"/> is <c>null</c>.</exception>
    /// <remarks>
    /// The method removes punctuation and symbols from the input text before counting words.
    /// It is optimized for processing large text inputs efficiently.
    /// </remarks>
    WordCount[] CountWordsTextUnix(string text)
    {
        if (text == null)
            throw new ArgumentNullException(nameof(text), "Input text cannot be null.");

        var t = text.Trim();
        if (t.Length == 0)
            return [];

        t = t.RemovePunctuation().RemoveSymbols();
        // ReSharper disable once IdentifierTypo
        var textArray = t.Split("\n");

        if (textArray.Length == 0)
            return [];

        return GetWordUsages(textArray);
    }

    /// <summary>
    /// Analyzes the provided array of text lines and calculates the frequency of each word.
    /// </summary>
    /// <param name="text">An array of strings, where each string represents a line of text to analyze.</param>
    /// <returns>An array of <see cref="WordCount"/> objects, each containing a word and its frequency count.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="text"/> parameter is null.</exception>
    /// <remarks>
    /// This method processes each line of text, removes leading and trailing whitespace, and splits the text into words.
    /// It uses a hash-based approach to efficiently count word occurrences.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public WordCount[] GetWordUsages(string[] text)
    {
        var wordCounts = new Dictionary<int, WordCount>(capacity: 4096);

        foreach (var line in text)
        {
            var l = line.AsSpan();
            l.Trim();

            if (l.IsEmpty())
                continue;

            int start = 0;
            for (int i = 0; i <= l.Length; i++)
            {
                if (i == l.Length || char.IsWhiteSpace(l[i]))
                {
                    if (start < i)
                    {
                        ReadOnlySpan<char> wordSpan = l.Slice(start, i - start); // Fix: Use ReadOnlySpan<char> instead of Span<char>
                        int hash = ComputeFnv1AHash(wordSpan);

                        // Use TryGetValue to avoid unnecessary allocations
                        if (!wordCounts.TryGetValue(hash, out WordCount? outWordCount)) // Fix: Use nullable WordCount? to handle potential null values
                        {
                            outWordCount = new WordCount { Word = wordSpan.ToString(), Count = 1 };
                            wordCounts[hash] = outWordCount;
                        }
                        else
                        {
                            // ReSharper disable once PossibleNullReferenceException
                            outWordCount.Count++;
                        }
                    }
                    start = i + 1;
                }
            }
        }
        return wordCounts.Values.ToArray();
    }



    
    /// <summary>
    /// Counts the occurrences of each word in a text file and returns the results as an array of <see cref="WordCount"/>.
    /// </summary>
    /// <param name="filePath">The path to the file from which to count words.</param>
    /// <returns>An array of <see cref="WordCount"/> objects, where each object represents a word and its frequency in the file.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="filePath"/> is <c>null</c>.</exception>
    /// <exception cref="FileNotFoundException">Thrown if the file specified by <paramref name="filePath"/> does not exist.</exception>
    /// <exception cref="IOException">Thrown if an I/O error occurs while reading the file.</exception>
    /// <remarks>
    /// This method reads the file line by line, processes each line to extract words, and calculates their frequencies.
    /// Words are identified by splitting the text based on whitespace characters.
    /// </remarks>
    public WordCount[] CountWordsFromFile(string filePath)
    {
        
        var wordCounts = new Dictionary<int, WordCount>(capacity: 8192);
        using StreamReader reader = new StreamReader(filePath);
        while (reader.ReadLine() is { } line)
        {
            var l = line.AsSpan();
            l.Trim();

            if (l.IsEmpty())
                continue;

            int start = 0;
            for (int i = 0; i <= l.Length; i++)
            {
                if (i == l.Length || char.IsWhiteSpace(l[i]))
                {
                    if (start < i)
                    {
                        ReadOnlySpan<char> wordSpan = l.Slice(start, i - start); // Fix: Use ReadOnlySpan<char> instead of Span<char>
                        int hash = ComputeFnv1AHash(wordSpan);

                        // Use TryGetValue to avoid unnecessary allocations
                        if (!wordCounts.TryGetValue(hash, out WordCount? outWordCount)) // Fix: Use nullable WordCount? to handle potential null values
                        {
                            outWordCount = new WordCount { Word = wordSpan.ToString(), Count = 1 };
                            wordCounts[hash] = outWordCount;
                        }
                        else
                        {
                            // ReSharper disable once PossibleNullReferenceException
                            outWordCount.Count++;
                        }
                    }
                    start = i + 1;
                }
            }
        }

        return wordCounts.Values.ToArray();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int ComputeFnv1AHash(ReadOnlySpan<char> span)
    {
        uint hash = 2166136261u;
        for (int i = 0; i < span.Length; i++)
        {
            hash ^= span[i];
            hash *= 16777619;
        }
        return unchecked((int)hash);
    }
    

    /// <summary>
    /// Displays the word counts in descending order of frequency.
    /// </summary>
    /// <param name="wordCounts">
    /// An array of <see cref="WordCount"/> objects representing the words and their respective counts.
    /// </param>
    /// <param name="numberToDisplay">
    /// The maximum number of word counts to display. If set to 0 or less, all word counts will be displayed.
    /// </param>
    public void DisplayWordCounts(WordCount[] wordCounts, int numberToDisplay = 0)
    {
        var count = 1;
        foreach (var wc in wordCounts.OrderByDescending(w => w.Count))
        {
            $"{count}\t{wc.Word}:\t {wc.Count}".pl();
            count++;
            if (numberToDisplay > 0 && --numberToDisplay <= 0)
                break;
        }
    }
    #endregion

    /// <summary>
    /// Releases all resources used by the <see cref="Utils"/> class.
    /// </summary>
    /// <remarks>
    /// This method suppresses finalization for the current instance to optimize garbage collection.
    /// </remarks>
    public void Dispose()
    {
        // No resources to release in the current implementation.
        GC.SuppressFinalize(this);
    }
}