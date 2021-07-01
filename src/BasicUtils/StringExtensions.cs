using System;
using System.Text;

namespace BasicUtils
{
    /// <summary>
    /// String Extension methods
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Sets the console foreground color to the current console foreground color
        /// as a compromise so as not to have a null by 'default'
        /// </summary>
        private static ConsoleColor _cachedConsoleColor = Console.ForegroundColor;
        
        // ReSharper disable once MemberCanBePrivate.Global
        public static void Print(this string output, 
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
        /// Simple method to print output string N times with no color formatting
        /// </summary>
        /// <param name="output"></param>
        /// <param name="RepeatNTimes"></param>
        public static void Print(this string output,
            int RepeatNTimes)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= RepeatNTimes; i++)
            {
                sb.Append(output);
            }
            Console.WriteLine(sb.ToString());
        }
        
        /// <summary>
        /// Prints a string N times
        /// </summary>
        /// <param name="output"></param>
        /// <param name="RepeatNTimes"></param>
        /// <param name="showTimeStamp"></param>
        /// <param name="textColor"></param>
        public static  void Print(this string output,
            int RepeatNTimes,
            bool showTimeStamp = true,
            ConsoleColor textColor = ConsoleColor.White)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < RepeatNTimes; i++)
            {
                sb.Append(output);
            }
            
            var tempColor = Console.ForegroundColor;
            Console.ForegroundColor = textColor;
            if (showTimeStamp)
            {
                Console.WriteLine($"{System.DateTime.Now}\t{sb.ToString()}");
            }
            else
            {
                Console.WriteLine($"{sb.ToString()}");
            }
            Console.ForegroundColor = tempColor;
        }

        public static string Input(this string output,
            bool showTimeStamp = false,
            ConsoleColor textColor = ConsoleColor.White)
        {
            var tempColor = Console.ForegroundColor;
            Console.ForegroundColor = textColor;
            if (showTimeStamp)
            {
                Console.Write($"{DateTime.Now.ToString()}\t{output}");
            }
            else
            {
                Console.Write(output);
            }

            var input = Console.ReadLine().Trim();
            Console.ForegroundColor = tempColor;
            return input.Replace(output, "");
        }
        
        public static void PressAnyKey(this string prompt)
        {
            if (prompt.Length == 0)
            {
                @"Press any key to continue...".Print();
            }
            else
            {
                prompt.Print();
            }
            Console.ReadKey();
        }

        public static void PressAnyKey(this string output,
            bool showTimeStamp = false,
            ConsoleColor textColor = ConsoleColor.White)
        {
            var tempColor = Console.ForegroundColor;
            Console.ForegroundColor = textColor;
            if (showTimeStamp)
            {
                if (output.Length == 0)
                {
                    Console.Write($"{DateTime.Now.ToString()}\tPress any key to continue...");
                }
                else
                {
                    Console.Write($"{DateTime.Now.ToString()}\t{output}");
                }
            }
            else
            {
                if (output.Length == 0)
                {
                    Console.Write($"Press any key to continue...");
                }
                else
                {
                    Console.Write($"{output}");
                }
            }
            var input = Console.ReadKey();
            Console.ForegroundColor = tempColor;    
        }

        /// <summary>
        /// Print input prompt, returns input as string
        /// </summary>
        /// <param name="inputPrompt"></param>
        /// <param name="showTimeStamp"></param>
        /// <param name="textColor"></param>
        /// <returns>input as string</returns>
        public static string PrintForInput(this string inputPrompt, 
            bool showTimeStamp = false,
            ConsoleColor textColor = ConsoleColor.White)
        {
            var tempColor = Console.ForegroundColor;
            Console.ForegroundColor = textColor;
            if (showTimeStamp)
            {
                Console.Write($"{DateTime.Now.ToString()}\t{inputPrompt}");
            }
            else
            {
                Console.Write(inputPrompt);
            }

            var output = Console.ReadLine().Trim();
            Console.ForegroundColor = tempColor;
            return output.Replace(inputPrompt, "");
        }

        /// <summary>
        /// Caches current console color
        /// </summary>
        public static void CacheCurrentConsoleForegroundColor()
        {
            _cachedConsoleColor = Console.ForegroundColor;
        }

        /// <summary>
        /// Sets console color to cached console color
        /// </summary>
        public static void SetConsoleForegroundToCachedColor()
        {
            Console.ForegroundColor = _cachedConsoleColor;
        }

        
        
    }
}
