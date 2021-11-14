using System;

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
            var r = text;
            if (text.Contains("\t"))
                r = r.Replace("\t", replacement);

            if (text.Contains("\n"))
                r = r.Replace("\n", replacement);

            if (text.Contains("\r"))
                r = r.Replace("\r", replacement);

            if (text.Contains(","))
                r = r.Replace(",", replacement);            

            if (text.Contains("."))
                r = r.Replace(".", replacement);

            if (text.Contains("?"))
                r = r.Replace("?", replacement);              
                                      
            if (text.Contains(":"))
                r = r.Replace(":", replacement);

            if (text.Contains(";"))
                r = r.Replace(";", replacement);                        

            if (text.Contains("!"))
                r = r.Replace("!", replacement);

            return r;
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
            var r = text;
            
            if (text.Contains("\\"))
                r = r.Replace("\\", replacement);                

            if (text.Contains("("))
                r = r.Replace("(", replacement);

            if (text.Contains(")"))
                r = r.Replace(")", replacement);

            if (text.Contains("-"))
                r = r = r.Replace("-", replacement);

            if (text.Contains("$"))
                r = r.Replace("$", replacement);                

            if (text.Contains("\\"))
                r = r.Replace("\\", replacement);

            if (text.Contains("/"))
                r = r.Replace("/", replacement);

            if (text.Contains("+"))
                r = r.Replace("+", replacement);

            if (text.Contains("*"))
                r = r.Replace("*", replacement);

            if (text.Contains("&"))
                r = r.Replace("&", replacement);

            if (text.Contains("%"))
                r = r.Replace("%", replacement);

            if (text.Contains("#"))
                r = r.Replace("#", replacement);

            if (text.Contains("@"))
                r = r.Replace("@", replacement);

            if (text.Contains("["))
                r = r.Replace("[", replacement);

            if (text.Contains("]"))
                r = r.Replace("]", replacement);

            if (text.Contains("{"))
                r = r.Replace("{", replacement);

            if (text.Contains("}"))
                r = r.Replace("}", replacement);

            if (text.Contains("|"))
                r = r.Replace("|", replacement);

            if (text.Contains("~"))
                r = r.Replace("~", replacement);

            if (text.Contains("^"))
                r = r.Replace("^", replacement);

            return r;
        }

        /// <summary>
        /// removes numbers from string
        /// </summary>
        /// <param name="text"></param>
        /// <param name="replacement"></param>
        /// <returns></returns>
        public static string RemoveNumbers(this string text,
            string replacement = "")
        {
            var r = text;

            if (text.Contains("0"))
                r = r.Replace("0", replacement);

            if (text.Contains("1"))
                r = r.Replace("1", replacement);

            if (text.Contains("2"))
                r = r.Replace("2", replacement);

            if (text.Contains("3"))
                r = r.Replace("3", replacement);

            if (text.Contains("4"))
                r = r.Replace("4", replacement);

            if (text.Contains("5"))
                r = r.Replace("5", replacement);

            if (text.Contains("6"))
                r = r.Replace("6", replacement);

            if (text.Contains("7"))
                r = r.Replace("7", replacement);

            if (text.Contains("8"))
                r = r.Replace("8", replacement);

            if (text.Contains("9"))
                r = r.Replace("9", replacement);

            return r;
        }
    }
}
