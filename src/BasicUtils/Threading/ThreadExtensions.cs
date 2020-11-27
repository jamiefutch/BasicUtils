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
        ///     Create a collection of threads: List<Thread> threadsList = new List<Thread>();
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