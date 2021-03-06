﻿using System;

namespace BasicUtils
{
    /// <summary>
    /// String Extension methods
    /// </summary>
    public static class StringExtensions
    {
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
    }
}
