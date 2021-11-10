using System;

namespace BasicUtils
{ 
    public static class DateTimeExtensions
    {
        public static string ElapsedTime(this long ticks)
        {
            TimeSpan ts = new TimeSpan(ticks);            
            return $"{ts.Hours.ToString("D2")}:{ ts.Minutes.ToString("D2")}:{ ts.Seconds.ToString("D2")}:{ ts.Milliseconds.ToString("D2")}";
        }

    }
}
