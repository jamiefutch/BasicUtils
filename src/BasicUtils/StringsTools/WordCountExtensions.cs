using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace BasicUtils.StringsTools
{
    /// <summary>
    /// Provides extension methods for performing word count operations on strings.
    /// </summary>
    public static unsafe class WordCountExtensions
    {
        /// <summary>
        /// Counts the number of words in the string. Words are defined as sequences of non-whitespace characters separated by whitespace.
        /// </summary>
        /// <param name="s">The input string to count words in.</param>
        /// <returns>The number of words in the string.</returns>
        public static int CountWords(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            int count = 0;
            bool inWord = false;
            int len = s.Length;

            fixed (char* pStr = s)
            {
                char* ptr = pStr;
                int simdStep = Vector128<ushort>.Count;

                int simdLen = len - (len % simdStep);

                for (int i = 0; i < simdLen; i += simdStep)
                {
                    // Load chunk
                    var chunk = Sse2.LoadVector128((ushort*)(ptr + i));
                    // Compare to ' ' (space)
                    var spaceMask = Sse2.CompareEqual(chunk, Vector128.Create((ushort)' '));
                    // Compare to '\t'
                    var tabMask = Sse2.CompareEqual(chunk, Vector128.Create((ushort)'\t'));
                    // Compare to '\n'
                    var lfMask = Sse2.CompareEqual(chunk, Vector128.Create((ushort)'\n'));
                    // Compare to '\r'
                    var crMask = Sse2.CompareEqual(chunk, Vector128.Create((ushort)'\r'));

                    // Combine all whitespace masks
                    var whiteMask = Sse2.Or(
                        Sse2.Or(spaceMask, tabMask),
                        Sse2.Or(lfMask, crMask)
                    );
                    uint mask = (uint)Sse2.MoveMask(whiteMask.AsByte());

                    if (mask == 0xFFFFu)
                    {
                        inWord = false;
                    }
                    else if (mask == 0x0000u)
                    {
                        if (!inWord)
                        {
                            inWord = true;
                            count++;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < simdStep; j++)
                        {
                            char c = *(ptr + i + j);
                            bool isWhite = char.IsWhiteSpace(c);
                            if (!isWhite)
                            {
                                if (!inWord) { inWord = true; count++; }
                            }
                            else inWord = false;
                        }
                    }
                }

                for (int i = simdLen; i < len; i++)
                {
                    char c = *(ptr + i);
                    bool isWhite = char.IsWhiteSpace(c);
                    if (!isWhite)
                    {
                        if (!inWord) { inWord = true; count++; }
                    }
                    else inWord = false;
                }
            }
            return count;
        }
    }
}
