/* Author : 
 * Philippe Matray
 *
 * Date :
 * 2014-01-23
 */

using System;
using System.Text.RegularExpressions;

namespace CCrossHelper.Lib.Portable.Helpers
{
    public static class ValidationHelper
    {
        #region enums

        public enum RegexTypeEnum
        {
            Alphanumeric,
            Numeric
        }

        #endregion

        #region constants

        private const string NumericPattern = "^[0-9]+$";
        private const string AlphanumericPattern = "^[A-Za-z]+$";

        #endregion

        #region fields

        private static Regex _regexNumeric;
        private static Regex _regexAlphanumeric;

        #endregion

        #region methods

        /// <summary>
        ///     Matches the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="regexType">Type of the regex.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException">regexType</exception>
        public static bool MatchValue(this string value, RegexTypeEnum regexType)
        {
            value.ThrowIfArgumentIsNullOrWhiteSpace();

            switch (regexType)
            {
                case RegexTypeEnum.Alphanumeric:
                    return MatchIfIsAlphanumeric(value);
                case RegexTypeEnum.Numeric:
                    return MatchIfIsNumeric(value);
                default:
                    throw new ArgumentOutOfRangeException("regexType");
            }
        }

        /// <summary>
        ///     Matches if is numeric.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool MatchIfIsNumeric(this string value)
        {
            value.ThrowIfArgumentIsNullOrWhiteSpace();

            if (_regexNumeric == null)
                _regexNumeric = new Regex(NumericPattern);

            bool isMatch = _regexNumeric.IsMatch(value);
            return isMatch;
        }

        /// <summary>
        ///     Matches if is alphanumeric.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool MatchIfIsAlphanumeric(this string value)
        {
            value.ThrowIfArgumentIsNullOrWhiteSpace();

            if (_regexAlphanumeric == null)
                _regexAlphanumeric = new Regex(AlphanumericPattern);

            bool isMatch = _regexAlphanumeric.IsMatch(value);
            return isMatch;
        }

        #endregion

        /* validation basée sur les REGEX
         * 
         * email
         * numéro de téléphone
         * ...
         */
    }
}