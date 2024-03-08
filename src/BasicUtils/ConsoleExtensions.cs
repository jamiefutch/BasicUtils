/** 
The MIT License (MIT)
Copyright © 2024 Jamie Futch

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
**/
using System;

namespace BasicUtils
{
    /// <summary>
    /// console extensions
    /// </summary>
    public static class ConsoleExtensions
    {
        private static ConsoleColor _cachedBgColor = Console.BackgroundColor;
        private static ConsoleColor _cachedForeColor = Console.ForegroundColor;
        
        private static ConsoleColor _bgColor;
        private static ConsoleColor _foreColor;

        /// <summary>
        /// cahce forground color for later restoration
        /// </summary>
        public static void CacheForeColor()
        {
            _cachedForeColor = Console.ForegroundColor;
        }
        
        /// <summary>
        /// cache background color for later restoration
        /// </summary>
        public static void CacheBgColor()
        {
            _cachedForeColor = Console.BackgroundColor;
        }
        
        /// <summary>
        /// restore forground color to cached value
        /// </summary>
        public static void RestoreCachedForeColor()
        {
            Console.ForegroundColor = _cachedForeColor;
            _foreColor = _cachedForeColor;
        }
        
        /// <summary>
        /// restore background color to cached value
        /// </summary>
        public static void RestoreCachedBgColor()
        {
            Console.BackgroundColor = _cachedBgColor;
            _bgColor = _cachedBgColor;
        }

        /// <summary>
        /// set background color
        /// </summary>
        /// <param name="color"></param>
        public static void SetBgColor(ConsoleColor color)
        {
            _bgColor = color;
            Console.BackgroundColor = color;
        }
        
        /// <summary>
        /// set forground color
        /// </summary>
        /// <param name="color"></param>
        public static void SetForeColor(ConsoleColor color)
        {
            _foreColor = color;
            Console.ForegroundColor = color;
        }
    }
}