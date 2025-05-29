#pragma warning disable CS1587 // XML comment is not placed on a valid language element
/** 
The MIT License (MIT)
Copyright © 2025 Jamie Futch

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
**/
using System;
using System.Diagnostics;

namespace BasicUtils
{ 
    /// <summary>
    /// some semi useful extensions for DateTime
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// gets elapsed time from ticks
        /// </summary>
        /// <param name="ticks"></param>
        /// <returns></returns>
        public static string ElapsedTime(this long ticks)
        {
            TimeSpan ts = new TimeSpan(ticks);            
            return $"{ts.Hours:D2}:{ ts.Minutes:D2}:{ ts.Seconds:D2}:{ ts.Milliseconds:D2}";
        }

        /// <summary>
        /// returns time formatted as HH:MM:SS:MS
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public static string TimeFormatted(this Stopwatch sw)
        {
            var ts = sw.Elapsed;
            return $"{ts.Hours:D2}:{ ts.Minutes:D2}:{ ts.Seconds:D2}:{ ts.Milliseconds:D2}";
        }
    }
}
