/* Author : 
 * Philippe Matray
 * 
 * Date : 
 * 2014-09-22 -> 2014-09-23
 */

using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CCrossHelper.Lib.Portable.Extensions
{
    public static partial class StringExtension
    {
        /// <summary>
        ///     Determines whether the specified value is numeric.
        /// </summary>
        /// <param name="theValue">The value.</param>
        /// <returns></returns>
        public static bool IsNumeric(this string theValue)
        {
            long retNum;
            bool result = long.TryParse(theValue, NumberStyles.Integer, NumberFormatInfo.InvariantInfo, out retNum);
            return result;
        }

        /// <summary>
        ///     Determines whether the specified text contains any of the characters of the second parameter.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="characters">The characters.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">characters</exception>
        public static bool ContainsAny(this string text, string characters)
        {
            if (string.IsNullOrWhiteSpace(characters))
                throw new ArgumentNullException("characters");

            return text.ContainsAny(characters.ToCharArray());
        }

        /// <summary>
        ///     Determines whether the specified text contains any of the characters of the second parameter.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="characters">The characters.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">characters</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">characters</exception>
        public static bool ContainsAny(this string text, params char[] characters)
        {
            if (characters == null)
                throw new ArgumentNullException("characters");
            if (characters.Count() <= 0)
                throw new ArgumentOutOfRangeException("characters");

            return text.IndexOfAny(characters) != -1;
        }

        /// <summary>
        ///     Removes any of the characters of the second parameter.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="characters">The characters.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">characters</exception>
        public static string RemoveAny(this string text, string characters)
        {
            if (string.IsNullOrWhiteSpace(characters))
                throw new ArgumentNullException("characters");

            return text.RemoveAny(characters.ToCharArray());
        }

        /// <summary>
        ///     Removes any of the characters of the second parameter.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="characters">The characters.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">characters</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">characters</exception>
        public static string RemoveAny(this string text, params char[] characters)
        {
            if (characters == null)
                throw new ArgumentNullException("characters");
            if (characters.Count() <= 0)
                throw new ArgumentOutOfRangeException("characters");

            var sb = new StringBuilder(text);
            foreach (char character in characters)
                sb.Replace(character.ToString(), "");

            string result = sb.ToString();
            return result;
        }
    }
}