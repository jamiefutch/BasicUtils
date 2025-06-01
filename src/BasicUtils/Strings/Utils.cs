using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicUtils.Strings
{
    public class Utils :IDisposable
    {
        /// <summary>
        /// Specifies the settings for generating random strings.
        /// </summary>
        /// <summary>
        /// Generates a random string containing only alphabetic characters.
        /// </summary>
        /// <summary>
        /// Generates a random string containing both alphabetic and numeric characters.
        /// </summary>
        /// <summary>
        /// Generates a random string containing alphabetic, numeric, and special characters.
        /// </summary>
        /// <summary>
        /// Generates a random string containing alphabetic, numeric, special characters, and spaces.
        /// </summary>
        public enum RandomStringSettings
        {
            /// <summary>
            /// Specifies that the random string should contain only alphabetic characters (A-Z, a-z).
            /// </summary>
            AlphaOnly = 0,
            /// <summary>
            /// Represents a setting for generating random strings that include both alphabetic characters and numeric digits.
            /// </summary>
            AlphaNumeric = 1,
            /// <summary>
            /// Specifies that the random string should include alphabetic characters, numeric digits, 
            /// and special characters.
            /// </summary>
            AlphaNumericSpecial = 2,
            /// <summary>
            /// Represents a setting for generating random strings that includes 
            /// alphanumeric characters, special characters, and spaces.
            /// </summary>
            AlphaNumericSpecialWithSpaces = 3
        }


        /// <summary>
        /// Generates a random string of the specified length using the specified character set.
        /// </summary>
        /// <param name="length">The length of the random string to generate. Must be a non-negative integer.</param>
        /// <param name="settings">
        /// Specifies the character set to use for generating the random string. 
        /// Defaults to <see cref="RandomStringSettings.AlphaNumericSpecialWithSpaces"/>.
        /// </param>
        /// <returns>A random string of the specified length composed of characters from the selected character set.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if <paramref name="length"/> is less than zero.
        /// </exception>
        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        public static string CreateRandomString(int length,
            RandomStringSettings settings = RandomStringSettings.AlphaNumericSpecialWithSpaces)
        {
            string chars;

            switch (settings)
            {
                case RandomStringSettings.AlphaOnly:
                    chars = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                    break;
                case RandomStringSettings.AlphaNumeric:
                    chars = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                    break;
                case RandomStringSettings.AlphaNumericSpecial:
                    chars = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()-_=+[]{}|;:',.<>/?`~";
                    break;
                case RandomStringSettings.AlphaNumericSpecialWithSpaces:
                    chars = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()-_=+[]{}|;:',.<>/?`~ ";
                    break;
                default:
                    chars = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                    break;
            }

            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        public void Dispose()
        {
            
        }
    }
}
