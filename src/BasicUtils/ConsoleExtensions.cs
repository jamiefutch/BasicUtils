using System;

namespace BasicUtils
{
    public static class ConsoleExtensions
    {
        private static ConsoleColor _CachedBgColor = Console.BackgroundColor;
        private static ConsoleColor _CachedForeColor = Console.ForegroundColor;
        
        private static ConsoleColor _BgColor;
        private static ConsoleColor _ForeColor;

        public static void CacheForeColor()
        {
            _CachedForeColor = Console.ForegroundColor;
        }
        
        public static void CacheBgColor()
        {
            _CachedForeColor = Console.BackgroundColor;
        }
        
        public static void RestoreCachedForeColor()
        {
            Console.ForegroundColor = _CachedForeColor;
            _ForeColor = _CachedForeColor;
        }
        
        public static void RestoreCachedBgColor()
        {
            Console.BackgroundColor = _CachedBgColor;
            _BgColor = _CachedBgColor;
        }

        public static void SetBgColor(ConsoleColor color)
        {
            _BgColor = color;
            Console.BackgroundColor = color;
        }
        
        public static void SetForeColor(ConsoleColor color)
        {
            _ForeColor = color;
            Console.ForegroundColor = color;
        }
    }
}