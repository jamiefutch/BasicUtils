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
using System.Text;

namespace BasicUtils.MenuTools;

/// <summary>
/// menu items
/// </summary>
public class MenuItem : IDisposable
{
    /// <summary>
    /// menu item id
    /// </summary>
    public string id { get; set; }
        
    /// <summary>
    /// menu item title
    /// </summary>
    public string title { get; set; }

    /// <summary>
    /// concats menu item id and title to a string for display
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"{id}\t{ title}";
    }

    /// <summary>
    /// Releases all resources used by the <see cref="MenuItem"/> instance.
    /// </summary>
    /// <remarks>
    /// This method cleans up any resources associated with the <see cref="MenuItem"/> instance,
    /// such as resetting the <see cref="id"/> and <see cref="title"/> properties to <c>null</c>.
    /// It also suppresses finalization for this object.
    /// </remarks>
    public void Dispose()
    {
        // Clean up any resources used by the MenuItem instance
        id = null;
        title = null;
        GC.SuppressFinalize(this);
    }
}