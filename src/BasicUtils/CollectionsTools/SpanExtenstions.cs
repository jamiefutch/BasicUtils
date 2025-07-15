using System;
using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace BasicUtils
{
    /// <summary>
    /// Provides extension methods for working with <see cref="ReadOnlySpan{T}"/> of characters.
    /// </summary>
    public static class SpanExtenstions
    {
        /// <summary>
        /// Determines whether the specified <see cref="ReadOnlySpan{T}"/> of characters is empty.
        /// </summary>
        /// <param name="span">
        /// The <see cref="ReadOnlySpan{T}"/> of characters to check.
        /// </param>
        /// <returns>
        /// <c>true</c> if the span is empty; otherwise, <c>false</c>.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEmpty(this ReadOnlySpan<char> span) => span.Length == 0;


        /// <summary>
        /// Trims leading and trailing whitespace characters from the specified <see cref="ReadOnlySpan{T}"/> of characters.
        /// </summary>
        /// <param name="span">
        /// The <see cref="ReadOnlySpan{T}"/> of characters to trim. 
        /// After the method call, this span will be updated to exclude leading and trailing whitespace.
        /// </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Trim(this ref ReadOnlySpan<char> span)
        {
            int start = 0;
            while (start < span.Length && char.IsWhiteSpace(span[start])) start++;
            int end = span.Length - 1;
            while (end >= 0 && char.IsWhiteSpace(span[end])) end--;

            if (start <= end) span = span.Slice(start, end - start + 1);
        }

    }
}
