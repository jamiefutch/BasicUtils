using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;



namespace BasicUtils
{
    /// <summary>
    /// String Extension methods
    /// </summary>
    public static class StringExtensions
    {
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
        /// deprecated; replaced by Print and print line
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
        public static string RemovePunctuation(this string text,
            string replacement = "")
        {
            return Regex.Replace(text, @"[^\w^\s]", "");
        }

        /// <summary>
        /// removes ascii symbols from string
        /// </summary>
        /// <param name="text"></param>
        /// <param name="replacement"></param>
        /// <returns></returns>
        public static string RemoveSymbols(this string text,
            string replacement = "")
        {
            return Regex.Replace(text, @"[^\w^\s]", "");
        }

        /// <summary>
        /// removes numbers from string
        /// </summary>
        /// <param name="text"></param>
        /// <param name="replacement"></param>
        /// <returns></returns>
        public static string RemoveNumbers(this string text,
            string replacement = "" )
        {
            return  Regex.Replace(text, @"[\d-]", replacement);
        }

        /// <summary>
        /// remove multiple spaces from string
        /// replaces with replacement value
        /// </summary>
        /// <param name="text"></param>
        /// <param name="replacement"></param>
        /// <returns></returns>
        public static string RemoveMultipleSpaces(this string text, 
            string replacement = " ")
        {
            return Regex.Replace(text, @"\s+", replacement);
        }

        /// <summary>
        /// remove tabs from string
        /// replaces with replacement value
        /// </summary>
        /// <param name="text"></param>
        /// <param name="replacement"></param>
        /// <returns></returns>
        public static string RemoveTabs(this string text,
            string replacement = " ")
        {
            return Regex.Replace(text, @"\t", replacement);
        }

        /// <summary>
        /// removes stop words from string
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string RemoveStopWords(this string text)
        {
            var retval = new List<string>();
            var t = text.Split(' ');
            foreach (var s in t)
            {
                if (!StopWords.StopWordsList.Contains(s))
                {
                    retval.Add(s);
                }
            }
            return string.Join(" ",retval);
        }
    }
}
