/** 
The MIT License (MIT)
Copyright © 2025 Jamie Futch

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
**/

using System;
using System.Globalization;

namespace BasicUtils
{
    /// <summary>
    /// Utils for working with objects
    /// </summary>
    public static class ObjectUtils
    {
        /// <summary>
        /// determines the type of an object and returns it as a string
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string GetTypeName(object o)
        {
            string typename = "";

            if (IsInt(o))
            {
                typename = "int";
            }
            else if (IsLong(o))
            {
                typename = "long";
            }
            else if (IsDouble(o))
            {
                typename = "double";
            }
            else if (IsSingle(o))
            {
                typename = "single";
            }
            else if (IsFloat(o))
            {
                typename = "float";
            }
            else if (IsDecimal(o))
            {
                typename = "decimal";
            }
            else if (IsCurrency(o))
            {
                typename = "currency";
            }
            else if (IsDateTime(o))
            {
                typename = "DateTime";
            }
            else if (IsBool(o))
            {
                typename = "bool";
            }
            else if (IsChar(o))
            {
                typename = "char";
            }
            else if (IsString(o))
            {
                typename = "string";
            }
            else
            {
                typename = "unknown";
            }
            return typename;
        }

        /// <summary>
        /// checks if an object is an int
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        private static bool IsInt(object o)
        {
            return int.TryParse(o.ToString(), out var val);
        }

        /// <summary>
        /// checks if an object is a long
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        private static bool IsLong(object o)
        {
            return long.TryParse(o.ToString(), out var val);
        }

        /// <summary>
        /// checks if an object is a double
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        private static bool IsDouble(object o)
        {
            return double.TryParse(o.ToString(), out var val);
        }

        /// <summary>
        /// checks if an object is a single
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        private static bool IsSingle(object o)
        {
            return float.TryParse(o.ToString(), out var val);
        }

        /// <summary>
        /// checks if an object is a float
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        private static bool IsFloat(object o)
        {
            return float.TryParse(o.ToString(), out _);
        }

        /// <summary>
        /// checks if an object is a decimal
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        private static bool IsDecimal(object o)
        {
            return decimal.TryParse(o.ToString(), out var val);
        }

        /// <summary>
        /// checks if an object is a DateTime
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        private static bool IsDateTime(object o)
        {
            return DateTime.TryParse(o.ToString(), out var val);
        }

        /// <summary>
        /// checks if an object is a currency
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        private static bool IsCurrency(object o)
        {
            bool val;
            val = Decimal.TryParse(o.ToString()!.Trim(), NumberStyles.Number |
                                                         NumberStyles.AllowCurrencySymbol, CultureInfo.CurrentCulture,
                out var value);
            return val;
        }

        /// <summary>
        /// checks if an object is a bool
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        private static bool IsBool(object o)
        {
            return bool.TryParse(o.ToString(), out var val);
        }

        /// <summary>
        /// checks if an object is a char
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        private static bool IsChar(object o)
        {
            return char.TryParse(o.ToString(), out var val);
        }

        /// <summary>
        /// checks if an object is a string
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        private static bool IsString(object o)
        {
            return true;
        }
    }
}
