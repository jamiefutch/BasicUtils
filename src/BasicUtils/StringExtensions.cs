#pragma warning disable CS1587 // XML comment is not placed on a valid language element
/** 
The MIT License (MIT)
Copyright © 2025 Jamie Futch

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
**/
using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BasicUtils
{
    /// <summary>
    /// String Extension methods
    /// </summary>
    public static class StringExtensions
    {

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
        /// Writes the specified string to the console without a line feed.
        /// </summary>
        /// <param name="str">The string to write to the console.</param>
        public static void p(this string str)
        {
            Print(str, false);
        }

        /// <summary>
        /// Writes the specified string to the console followed by a line feed.
        /// </summary>
        /// <param name="str">The string to write to the console.</param>
        public static void pl(this string str)
        {
            PrintLine(str,false);
        }

        /// <summary>
        /// Writes the specified string to the console, optionally with a timestamp and in a specified color.
        /// </summary>
        /// <param name="str">The string to write to the console.</param>
        public static void Print(this string str)
        {
            Console.Write(str);
        }

        /// <summary>
        /// Writes the specified string to the console, optionally with a timestamp and in a specified color.
        /// </summary>
        /// <param name="str">The string to write to the console.</param>
        /// <param name="showTimeStamp">If true, prepends the current timestamp to the output.</param>
        public static void Print(this string str,
            bool showTimeStamp = true)
        {
            Console.Write(showTimeStamp ? $"{System.DateTime.Now}\t{str}" : $"{str}");
        }

        /// <summary>
        /// Writes the specified string to the console, optionally with a timestamp and in a specified color.
        /// </summary>
        /// <param name="str">The string to write to the console.</param>
        /// <param name="showTimeStamp">If true, prepends the current timestamp to the output.</param>
        /// <param name="textColor">The color to use for the output text.</param>
        public static void Print(this string str, 
            bool showTimeStamp = true,
            ConsoleColor textColor = ConsoleColor.White)
        {
            var tempColor = Console.ForegroundColor;
            Console.ForegroundColor = textColor;
            Console.Write(showTimeStamp ? $"{System.DateTime.Now}\t{str}" : $"{str}");
            Console.ForegroundColor = tempColor;
        }


        /// <summary>
        /// Writes the specified string to the console followed by a line feed, optionally prepending the current timestamp.
        /// </summary>
        /// <param name="str">The string to write to the console.</param>
        public static void PrintLine(this string str)
        {
            Console.WriteLine(str);
        }

        /// <summary>
        /// Writes the specified string to the console followed by a line feed, optionally prepending the current timestamp.
        /// </summary>
        /// <param name="str">The string to write to the console.</param>
        /// <param name="showTimeStamp">If true, prepends the current timestamp to the output.</param>
        public static void PrintLine(this string str,
            bool showTimeStamp = true)
        {
            Console.WriteLine(showTimeStamp ? $"{System.DateTime.Now}\t{str}" : $"{str}");
        }

        // ReSharper disable once MethodOverloadWithOptionalParameter
        /// <summary>
        /// Writes the specified string to the console followed by a line feed.
        /// </summary>
        /// <param name="str">The string to write to the console.</param>
        /// <param name="showTimeStamp">If true, prepends the current timestamp to the output.</param>
        /// <param name="textColor">The color to use for the output text.</param>
        public static void PrintLine(this string str,
            bool showTimeStamp = true,
            ConsoleColor textColor = ConsoleColor.White)
        {
            var tempColor = Console.ForegroundColor;
            Console.ForegroundColor = textColor;
            Console.WriteLine(showTimeStamp ? $"{System.DateTime.Now}\t{str}" : $"{str}");
            Console.ForegroundColor = tempColor;
        }


        /// <summary>
        /// Displays a prompt or a default "Press any key to continue..." message, then waits for a key press.
        /// </summary>
        /// <param name="prompt">The prompt to display. If empty, a default message is shown.</param>
        /// <param name="showTimeStamp">If true, prepends the current timestamp to the prompt.</param>
        public static void PressAnyKey(this string prompt, 
            bool showTimeStamp = true)
        {
            if (prompt.Length == 0)
            {
                if (showTimeStamp)
                {
                    Console.WriteLine($"{System.DateTime.Now}\tPress any key to continue...");
                }
                else
                {
                    @"Press any key to continue...".PrintLine();   
                }
            }
            else
            {
                prompt.Print();
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Writes a prompt to the console and reads input from the user, returning the input as a string.
        /// </summary>
        /// <param name="inputPrompt">The prompt to display to the user.</param>
        /// <param name="showTimeStamp">If true, prepends the current timestamp to the prompt.</param>
        /// <param name="textColor">The color to use for the prompt text.</param>
        /// <returns>The user's input as a string.</returns>
        public static string PrintForInput(this string inputPrompt, 
            bool showTimeStamp = false,
            ConsoleColor textColor = ConsoleColor.White)
        {
            var tempColor = Console.ForegroundColor;
            Console.ForegroundColor = textColor;
            Console.Write(showTimeStamp
                ? $"{DateTime.Now.ToString(CultureInfo.InvariantCulture)}\t{inputPrompt}"
                : inputPrompt);

            // ReSharper disable once PossibleNullReferenceException
            var output = Console.ReadLine().Trim();
            Console.ForegroundColor = tempColor;
            return output.Replace(inputPrompt, "");
        }

        /// <summary>
        /// Not implemented. Intended to read input from the user with a prompt.
        /// </summary>
        /// <param name="inputPrompt">The prompt to display to the user.</param>
        /// <param name="showTimeStamp">If true, prepends the current timestamp to the prompt.</param>
        /// <param name="textColor">The color to use for the prompt text.</param>
        /// <returns>The user's input as a string.</returns>
        /// <exception cref="NotImplementedException">Always thrown.</exception>
        public static string Input(this string inputPrompt,
            bool showTimeStamp = false,
            ConsoleColor textColor = ConsoleColor.White)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes all punctuation characters from the string.
        /// </summary>
        /// <param name="text">The string to process.</param>
        /// <returns>A new string with punctuation removed.</returns>
        public static string RemovePunctuation(this string text)
        {
            var result = new StringBuilder(text.Length);
            foreach (var c in text)
            {
                if (!char.IsPunctuation(c))
                {
                    result.Append(c);
                }
            }
            return result.ToString();
        }

        /// <summary>
        /// Removes all ASCII symbol characters from the string, leaving only letters, digits, and whitespace.
        /// </summary>
        /// <param name="text">The string to process.</param>
        /// <returns>A new string with symbols removed.</returns>
        public static string RemoveSymbols(this string text)
        {
            var result = new StringBuilder(text.Length);
            foreach (var c in text)
            {
                if (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c))
                {
                    result.Append(c);
                }
            }
            return result.ToString();
        }

        /// <summary>
        /// Removes all numeric digits from the string.
        /// </summary>
        /// <param name="text">The string to process.</param>
        /// <returns>A new string with numbers removed.</returns>
        public static string RemoveNumbers(this string text)
        {
            var result = new StringBuilder(text.Length);
            foreach (var c in text)
            {
                if (!char.IsDigit(c))
                {
                    result.Append(c);
                }
            }
            return result.ToString();
        }

        /// <summary>
        /// Replaces multiple consecutive spaces in the string with a single replacement value.
        /// </summary>
        /// <param name="text">The string to process.</param>
        /// <param name="replacement">The string to replace multiple spaces with. Defaults to a single space.</param>
        /// <returns>A new string with multiple spaces replaced.</returns>
        public static string RemoveMultipleSpaces(this string text, string replacement = " ")
        {
            var words = text.Split([' '], StringSplitOptions.RemoveEmptyEntries);
            return string.Join(replacement, words);
        }

        /// <summary>
        /// Replaces all tab characters in the string with the specified replacement value.
        /// </summary>
        /// <param name="text">The string to process.</param>
        /// <param name="replacement">The string to replace tabs with. Defaults to a single space.</param>
        /// <returns>A new string with tabs replaced.</returns>
        public static string RemoveTabs(this string text, string replacement = " ")
        {
            return text.Replace("\t", replacement);
        }

        /// <summary>
        /// Removes stop words from the string using a predefined stop words list.
        /// </summary>
        /// <param name="text">The string to process.</param>
        /// <returns>A new string with stop words removed.</returns>
        public static string RemoveStopWords(this string text)
        {
            var words = text.Split(' ');
            var stopWordsSet = new HashSet<string>(StopWords.StopWordsList);
            var filteredWords = words.Where(word => !stopWordsSet.Contains(word));
            return string.Join(" ", filteredWords);
        }

        /// <summary>
        /// Repeats the string a specified number of times.
        /// </summary>
        /// <param name="text">The string to repeat.</param>
        /// <param name="count">The number of times to repeat the string.</param>
        /// <returns>A new string consisting of the original string repeated the specified number of times.</returns>
        public static string Repeat(this string text, int count)
        {
            return string.Concat(Enumerable.Repeat(text, count));
        }

        /// <summary>
        /// Generates a random string of the specified length, optionally including special characters.
        /// </summary>
        /// <param name="length">The length of the random string to generate.</param>
        /// <param name="includeSpecialCharacters">If true, includes special characters in the generated string; otherwise, only alphanumeric characters are used.</param>
        /// <returns>A randomly generated string of the specified length.</returns>
        [Obsolete]
        public static string CreateRandomString(int length, bool includeSpecialCharacters = false)
        {
            // ReSharper disable once StringLiteralTypo
            string chars;
            if (!includeSpecialCharacters)
            {
                chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            }
            else
            {
                chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()-_=+[]{}|;:',.<>/?`~";
            }

            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
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
        public static string CreateRandomString(int length, 
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
                    chars = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()-_=+[]{}|;:',.<>/?`~";
                    break;
                case RandomStringSettings.AlphaNumericSpecialWithSpaces:
                    chars = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()-_=+[]{}|;:',.<>/?`~ ";
                    break;
                default:
                    chars = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                    break;
            }

            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
