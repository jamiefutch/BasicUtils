﻿#pragma warning disable CS1587 // XML comment is not placed on a valid language element
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

// ReSharper disable once CheckNamespace
namespace BasicUtils;

public static class Math
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
    public static bool FastModForLoop(long limitcount, long limit)
    {
        return (bool)(limitcount > (limit - 1));
    }
}