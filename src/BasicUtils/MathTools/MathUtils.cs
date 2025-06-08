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

namespace BasicUtils.MathTools;

/// <summary>
/// Provides utility methods for mathematical operations.
/// </summary>
public class MathUtils :IDisposable
{
    /// <summary>
    /// A fast modulo operation for large loops
    ///
    /// this is equivalent to (limitcount % limit) == 0, only a bit faster.
    /// usage:
    ///     where limitcount is the current loop count,
    ///     and limit is the modulo limit
    ///     if(Math.FastModForLoop(limitcount, limit))
    ///     {then do something}
    /// </summary>
    /// <param name="limitcount">the current loop count</param>
    /// <param name="limit">the limit of the modulo</param>
    /// <returns></returns>
    // ReSharper disable once IdentifierTypo
    public bool FastModForLoop(long limitcount, long limit)
    {
        return (bool)(limitcount > (limit - 1));
    }

    /// <summary>
    /// Generates a shuffled array of integers with optional parameters for range, count, and duplicates.
    /// </summary>
    /// <param name="minValue">The minimum value (inclusive) for the generated numbers.</param>
    /// <param name="maxValue">The maximum value (inclusive) for the generated numbers.</param>
    /// <param name="count">The number of integers to generate.</param>
    /// <param name="allowDuplicates">Whether duplicate values are allowed in the generated array.</param>
    /// <returns>
    /// An array of shuffled integers. If <paramref name="allowDuplicates"/> is false, all values are unique.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown if <paramref name="minValue"/> is greater than <paramref name="maxValue"/>, 
    /// if <paramref name="count"/> is negative, or if <paramref name="count"/> exceeds the range of unique numbers available.
    /// </exception>
    public int[] GenerateShuffledArray(
        int minValue = 0,
        int maxValue = 1,
        int count = 1,
        bool allowDuplicates = false)
    {
        if (minValue > maxValue) throw new ArgumentException("Minimum value cannot be greater than maximum value.");
        if (count < 0) throw new ArgumentException("Count cannot be negative.");

        var random = new Random();
        var result = new List<int>();

        if (allowDuplicates)
        {
            int[] array = new int[count];
            for (var i = 0; i < count; i++)
            {
                array[i] = random.Next(minValue, maxValue + 1);
            }

            return array;
        }
        else
        {
            var range = Enumerable.Range(minValue, maxValue - minValue + 1).ToList();

            if (count > range.Count)
                throw new ArgumentException("Count exceeds the range of unique numbers available.");
            HashSet<int> numbers = new HashSet<int>();

            for (var i = 0; i < count; i++)
            {
                var index = random.Next(range.Count);
                try
                {
                    numbers.Add(random.Next(minValue, maxValue + 1));
                }
                catch
                {
                    // ignored
                }
            }
        }

        return result.ToArray();
    }

    /// <summary>
    /// Releases all resources used by the <see cref="MathUtils"/> class.
    /// </summary>
    /// <remarks>
    /// This method is provided to fulfill the requirements of the <see cref="IDisposable"/> interface.
    /// Override this method to release any unmanaged resources if necessary.
    /// </remarks>
    public void Dispose()
    {
        // No resources to release in this implementation.
        // Method provided to fulfill IDisposable interface requirements.
    }
}