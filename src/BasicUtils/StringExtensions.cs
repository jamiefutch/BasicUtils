/** 
The MIT License (MIT)
Copyright © 2024 Jamie Futch

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
**/
using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;

namespace BasicUtils
{
    /// <summary>
    /// String Extension methods
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// lazy way to print to console (no line feed)
        /// </summary>
        /// <param name="output"></param>
        public static void p(this string output)
        {
            Print(output);
        }

        /// <summary>
        /// lazy way to print to console (with line feed)
        /// </summary>
        /// <param name="output"></param>
        public static void pl(this string output)
        {
            PrintLine(output);
        }        
        
        /// <summary>
        /// prints string to console
        /// </summary>
        /// <param name="output"></param>
        /// <param name="showTimeStamp"></param>
        /// <param name="textColor"></param>
        public static void Print(this string output, 
            bool showTimeStamp = true,
            ConsoleColor textColor = ConsoleColor.White)
        {
            var tempColor = Console.ForegroundColor;
            Console.ForegroundColor = textColor;
            if (showTimeStamp)
            {
                Console.Write($"{System.DateTime.Now}\t{output}");
            }
            else
            {
                Console.Write($"{output}");
            }

            Console.ForegroundColor = tempColor;
        }


        /// <summary>
        /// Prints string to console 
        /// </summary>
        /// <param name="output"></param>
        /// <param name="showTimeStamp"></param>
        /// <param name="textColor"></param>
        // ReSharper disable once MemberCanBePrivate.Global
        public static void PrintLine(this string output,
            bool showTimeStamp = true,
            ConsoleColor textColor = ConsoleColor.White)
        {
            var tempColor = Console.ForegroundColor;
            Console.ForegroundColor = textColor;
            if (showTimeStamp)
            {
                Console.WriteLine($"{System.DateTime.Now}\t{output}");
            }
            else
            {
                Console.WriteLine($"{output}");
            }

            Console.ForegroundColor = tempColor;
        }

        /// <summary>
        /// displays a prompt or a default press any key prompt then waits for any key press
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="showTimeStamp"></param>
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
        /// prints a line and accepts inupt from the user.  Returns the input as a string
        /// </summary>
        /// <param name="inputPrompt"></param>
        /// <param name="showTimeStamp"></param>
        /// <param name="textColor"></param>
        /// <returns></returns>
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
        /// not implemented
        /// </summary>
        /// <param name="inputPrompt"></param>
        /// <param name="showTimeStamp"></param>
        /// <param name="textColor"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static string Input(this string inputPrompt,
            bool showTimeStamp = false,
            ConsoleColor textColor = ConsoleColor.White)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// removes punctuation and end of lines from string
        /// </summary>
        /// <param name="text"></param>
        /// <param name="replacement"></param>
        /// <returns></returns>
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
        /// removes ascii symbols from string
        /// </summary>
        /// <param name="text"></param>
        /// <param name="replacement"></param>
        /// <returns></returns>
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
        /// removes numbers from string
        /// </summary>
        /// <param name="text"></param>
        /// <param name="replacement"></param>
        /// <returns></returns>
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
        /// remove multiple spaces from string
        /// replaces with replacement value
        /// </summary>
        /// <param name="text"></param>
        /// <param name="replacement"></param>
        /// <returns></returns>
        public static string RemoveMultipleSpaces(this string text, string replacement = " ")
        {
            var words = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return string.Join(replacement, words);
        }

        /// <summary>
        /// remove tabs from string
        /// replaces with replacement value
        /// </summary>
        /// <param name="text"></param>
        /// <param name="replacement"></param>
        /// <returns></returns>
        public static string RemoveTabs(this string text, string replacement = " ")
        {
            return text.Replace("\t", replacement);
        }

        /// <summary>
        /// removes stop words from string
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string RemoveStopWords(this string text)
        {
            var words = text.Split(' ');
            var stopWordsSet = new HashSet<string>(StopWords.StopWordsList);
            var filteredWords = words.Where(word => !stopWordsSet.Contains(word));
            return string.Join(" ", filteredWords);
        }

        /// <summary>
        /// repeats a string n times
        /// </summary>
        /// <param name="text"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string Repeat(this string text, int count)
        {
            return string.Concat(Enumerable.Repeat(text, count));
        }
    }
}
