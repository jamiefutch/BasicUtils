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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicUtils.ConsoleUtils
{
    /// <summary>
    /// Provides extension methods for managing and manipulating console colors.
    /// </summary>
    public class ConsoleUtils : IDisposable
    {
        // ReSharper disable once InconsistentNaming
        private static readonly ConsoleColor _cachedBgColor = System.Console.BackgroundColor;
        private static ConsoleColor _cachedForeColor = System.Console.ForegroundColor;

        private static ConsoleColor _bgColor;
        private static ConsoleColor _foreColor;

        /// <summary>
        /// Caches the current foreground color of the console for later restoration.
        /// </summary>
        public static void CacheForeColor()
        {
            _cachedForeColor = System.Console.ForegroundColor;
        }

        /// <summary>
        /// Caches the current background color of the console for later restoration.
        /// </summary>
        public static void CacheBgColor()
        {
            _cachedForeColor = System.Console.BackgroundColor;
        }

        /// <summary>
        /// Restores the console's foreground color to the previously cached value.
        /// </summary>
        public static void RestoreCachedForeColor()
        {
            System.Console.ForegroundColor = _cachedForeColor;
            _foreColor = _cachedForeColor;
        }

        /// <summary>
        /// Restores the console's background color to the previously cached value.
        /// </summary>
        public static void RestoreCachedBgColor()
        {
            System.Console.BackgroundColor = _cachedBgColor;
            _bgColor = _cachedBgColor;
        }

        /// <summary>
        /// Sets the console's background color to the specified value.
        /// </summary>
        /// <param name="color">The <see cref="ConsoleColor"/> to set as the background color.</param>
        public static void SetBgColor(ConsoleColor color)
        {
            _bgColor = color;
            System.Console.BackgroundColor = color;
        }

        /// <summary>
        /// Sets the console's foreground color to the specified value.
        /// </summary>
        /// <param name="color">The <see cref="ConsoleColor"/> to set as the foreground color.</param>
        public static void SetForeColor(ConsoleColor color)
        {
            _foreColor = color;
            System.Console.ForegroundColor = color;
        }


        public void Dispose()
        {
        }
    }
}
