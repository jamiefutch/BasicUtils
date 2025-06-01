using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicUtils.ConsoleUtils
{
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
