#pragma warning disable CS1587 // XML comment is not placed on a valid language element
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
        /// Determines the type of object and returns it as a string.
        /// </summary>
        /// <param name="o">The object to check.</param>
        /// <returns>The type name as a string, or "unknown" if not recognized.</returns>
        public static string GetTypeName(object o)
        {
            if (o is null)
                return "unknown";

            // Fast type checks
            switch (o)
            {
                case int: return "int";
                case long: return "long";
                case double: return "double";
                case float: return "float";
                case decimal: return "decimal";
                case DateTime: return "DateTime";
                case bool: return "bool";
                case char: return "char";
                case string: return "string";
            }

            // Fallback: try to parse string representations for ambiguous types
            var str = o.ToString();
            if (int.TryParse(str, out _)) return "int";
            if (long.TryParse(str, out _)) return "long";
            if (double.TryParse(str, out _)) return "double";
            if (float.TryParse(str, out _)) return "float";
            if (decimal.TryParse(str, out _)) return "decimal";
            if (DateTime.TryParse(str, out _)) return "DateTime";
            if (bool.TryParse(str, out _)) return "bool";
            if (char.TryParse(str, out _)) return "char";

            // Currency check (if needed)
            return decimal.TryParse(str, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, CultureInfo.CurrentCulture, out _) ? "currency" : "unknown";
        }

        /// <summary>
        /// Checks if an object is an int or a string that can be parsed as an int.
        /// </summary>
        /// <param name="o">The object to check.</param>
        /// <returns>True if the object is an int or a string representing an int; otherwise, false.</returns>
        public static bool IsInt(object o)
        {
            switch (o)
            {
                case null:
                    return false;
                case int:
                    return true;
                case string s:
                    return int.TryParse(s, out _);
            }

            if (o is not IConvertible convertible) return false;
            try
            {
                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                convertible.ToInt32(CultureInfo.InvariantCulture);
                return true;
            }
            catch
            {
                // ignored
            }

            return false;
        }

        /// <summary>
        /// Checks if an object is a long or a string that can be parsed as a long.
        /// </summary>
        /// <param name="o">The object to check.</param>
        /// <returns>True if the object is a long or a string representing a long; otherwise, false.</returns>
        public static bool IsLong(object o)
        {
            switch (o)
            {
                case null:
                    return false;
                case long:
                    return true;
                case string s:
                    return long.TryParse(s, out _);
            }

            if (o is not IConvertible convertible) return false;
            try
            {
                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                convertible.ToInt64(CultureInfo.InvariantCulture);
                return true;
            }
            catch
            {
                // ignored
            }

            return false;
        }

        /// <summary>
        /// Checks if an object is a double or a string that can be parsed as a double.
        /// </summary>
        /// <param name="o">The object to check.</param>
        /// <returns>True if the object is a double or a string representing a double; otherwise, false.</returns>
        public static bool IsDouble(object o)
        {
            switch (o)
            {
                case null:
                    return false;
                case double:
                    return true;
                case string s:
                    return double.TryParse(s, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out _);
            }

            if (o is not IConvertible convertible) return false;
            try
            {
                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                convertible.ToDouble(CultureInfo.InvariantCulture);
                return true;
            }
            catch
            {
                // ignored
            }

            return false;
        }

        /// <summary>
        /// Checks if an object is a single-precision floating point (float) or a string that can be parsed as a float.
        /// </summary>
        /// <param name="o">The object to check.</param>
        /// <returns>True if the object is a float or a string representing a float; otherwise, false.</returns>
        public static bool IsSingle(object o)
        {
            switch (o)
            {
                case null:
                    return false;
                case float:
                    return true;
                case string s:
                    return float.TryParse(s, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out _);
            }

            if (o is not IConvertible convertible) return false;
            try
            {
                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                convertible.ToSingle(CultureInfo.InvariantCulture);
                return true;
            }
            catch
            {
                // ignored
            }

            return false;
        }

        /// <summary>
        /// Checks if an object is a float (single-precision floating point) or a string that can be parsed as a float.
        /// </summary>
        /// <param name="o">The object to check.</param>
        /// <returns>True if the object is a float or a string representing a float; otherwise, false.</returns>
        public static bool IsFloat(object o)
        {
            switch (o)
            {
                case null:
                    return false;
                case float:
                    return true;
                case string s:
                    return float.TryParse(s, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out _);
            }

            if (o is not IConvertible convertible) return false;
            try
            {
                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                convertible.ToSingle(CultureInfo.InvariantCulture);
                return true;
            }
            catch
            {
                // ignored
            }

            return false;
        }

        /// <summary>
        /// Checks if an object is a decimal or a string that can be parsed as a decimal.
        /// </summary>
        /// <param name="o">The object to check.</param>
        /// <returns>True if the object is a decimal or a string representing a decimal; otherwise, false.</returns>
        public static bool IsDecimal(object o)
        {
            switch (o)
            {
                case null:
                    return false;
                case decimal:
                    return true;
                case string s:
                    return decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out _);
            }

            if (o is not IConvertible convertible) return false;
            try
            {
                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                convertible.ToDecimal(CultureInfo.InvariantCulture);
                return true;
            }
            catch
            {
                // ignored
            }

            return false;
        }

        /// <summary>
        /// Checks if an object is a <see cref="DateTime"/> or a string that can be parsed as a DateTime.
        /// </summary>
        /// <param name="o">The object to check.</param>
        /// <returns>True if the object is a DateTime or a string representing a DateTime; otherwise, false.</returns>
        public static bool IsDateTime(object o)
        {
            switch (o)
            {
                case null:
                    return false;
                case DateTime:
                    return true;
                case string s:
                    return DateTime.TryParse(s, CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
            }

            if (o is not IConvertible convertible) return false;
            try
            {
                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                convertible.ToDateTime(CultureInfo.InvariantCulture);
                return true;
            }
            catch
            {
                // ignored
            }

            return false;
        }

        /// <summary>
        /// Checks if an object is a currency value (decimal with currency symbol support) or a string that can be parsed as such.
        /// </summary>
        /// <param name="o">The object to check.</param>
        /// <returns>True if the object is a currency value or a string representing a currency; otherwise, false.</returns>
        public static bool IsCurrency(object o)
        {
            switch (o)
            {
                case null:
                    return false;
                case decimal:
                    // Decimals are valid currency values
                    return true;
                case string s:
                    // Try parsing with currency symbol allowed, using current culture
                    return decimal.TryParse(s.Trim(), NumberStyles.Number | NumberStyles.AllowCurrencySymbol, CultureInfo.CurrentCulture, out _);
            }

            if (o is not IConvertible convertible) return false;
            try
            {
                // Try to convert to decimal (covers boxed numerics)
                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                convertible.ToDecimal(CultureInfo.CurrentCulture);
                return true;
            }
            catch
            {
                // ignored
            }

            return false;
        }

        /// <summary>
        /// Checks if an object is a <see cref="bool"/> or a string that can be parsed as a boolean ("true" or "false", case-insensitive).
        /// </summary>
        /// <param name="o">The object to check.</param>
        /// <returns>True if the object is a bool or a string representing a bool; otherwise, false.</returns>
        public static bool IsBool(object o)
        {
            switch (o)
            {
                case null:
                    return false;
                case bool:
                    return true;
                case string s:
                    return bool.TryParse(s, out _);
            }

            if (o is not IConvertible convertible) return false;
            try
            {
                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                convertible.ToBoolean(CultureInfo.InvariantCulture);
                return true;
            }
            catch
            {
                // ignored
            }

            return false;
        }

        /// <summary>
        /// Checks if an object is a <see cref="char"/> or a string that can be parsed as a single character.
        /// </summary>
        /// <param name="o">The object to check.</param>
        /// <returns>True if the object is a char or a string representing a single character; otherwise, false.</returns>
        public static bool IsChar(object o)
        {
            switch (o)
            {
                case null:
                    return false;
                case char:
                    return true;
                case string s:
                    return s.Length == 1;
            }

            if (o is not IConvertible convertible) return false;
            try
            {
                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                convertible.ToChar(CultureInfo.InvariantCulture);
                return true;
            }
            catch
            {
                // ignored
            }

            return false;
        }

        /// <summary>
        /// Checks if an object is a <see cref="string"/>.
        /// </summary>
        /// <param name="o">The object to check.</param>
        /// <returns>True if the object is a string; otherwise, false.</returns>
        public static bool IsString(object o)
        {
            return o is string;
        }
    }
}
