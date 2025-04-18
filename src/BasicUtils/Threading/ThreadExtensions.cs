/** 
The MIT License (MIT)
Copyright © 2025 Jamie Futch

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
**/
using System.Collections.Generic;
using System.Threading;

namespace BasicUtils.Threading
{
    /// <summary>
    /// Extension methods to help with threads
    /// </summary>
    public static class ThreadExtensions
    {
            
        /// <summary>
        /// Waits for all threads in the threads collection to finish before executing the next instruction
        /// Usage:
        ///     Create a collection of threads: List&lt;Thread&gt; threadsList = new List&lt;Thread&gt;();
        ///     Add the threads to the collection: threadsList.Add(threadX);
        ///     At the point where waiting on threads is desired: threadsList.WaitAll();            
        /// </summary>
        /// <param name="threads">threads collection</param>
        public static void WaitAll(this IEnumerable<Thread> threads)
        {
            if(threads!=null)
            {
                foreach(Thread thread in threads)
                { thread.Join(); }
            }
        }
    }
}