using System;

namespace BasicUtils
{
    /// <summary>
    /// String Extension methods
    /// </summary>
    public static class StringExtensions
    {
        public static void Print(this string output)
        {
            Console.WriteLine($"{System.DateTime.Now}\t{output}");
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
    }
}
