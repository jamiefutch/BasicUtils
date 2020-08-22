using System;

namespace BasicUtils
{ 
    public static class DateTimeExtensions
    {
        public static string ElapsedTime(this long ticks)
        {
            TimeSpan ts = new TimeSpan(ticks);

            return String.Format("{0}:{1}:{2}:{3}",
                ts.Hours,
                ts.Minutes,
                ts.Seconds,
                ts.Milliseconds
            );
        }

    }
}
