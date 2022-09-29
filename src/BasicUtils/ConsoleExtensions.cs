using System;

namespace BasicUtils
{
    public static class ConsoleExtensions
    {
        private static ConsoleColor _cachedBgColor = Console.BackgroundColor;
        private static ConsoleColor _cachedForeColor = Console.ForegroundColor;
        
        private static ConsoleColor _bgColor;
        private static ConsoleColor _foreColor;

        public static void CacheForeColor()
        {
            _cachedForeColor = Console.ForegroundColor;
        }
        
        public static void CacheBgColor()
        {
            _cachedForeColor = Console.BackgroundColor;
        }
        
        public static void RestoreCachedForeColor()
        {
            Console.ForegroundColor = _cachedForeColor;
            _foreColor = _cachedForeColor;
        }
        
        public static void RestoreCachedBgColor()
        {
            Console.BackgroundColor = _cachedBgColor;
            _bgColor = _cachedBgColor;
        }

        public static void SetBgColor(ConsoleColor color)
        {
            _bgColor = color;
            Console.BackgroundColor = color;
        }
        
        public static void SetForeColor(ConsoleColor color)
        {
            _foreColor = color;
            Console.ForegroundColor = color;
        }
    }
}