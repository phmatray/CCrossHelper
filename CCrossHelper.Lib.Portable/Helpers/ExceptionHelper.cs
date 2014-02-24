/* Author : 
 * Philippe Matray
 *
 * Date :
 * 2014-01-23
 * 
 * Link: 
 * http://extensionoverflow.codeplex.com/SourceControl/latest#ExtensionMethods/ClassExtensions.cs
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace CCrossHelper.Lib.Portable.Helpers
{
    public static class ExceptionHelper
    {
        #region methods

        /// <summary>
        ///     Throws an exception if the object called upon is null.
        /// </summary>
        /// <typeparam name="T">The calling class</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="paramName">The text to be written on the ArgumentNullException: [text] not allowed to be null</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static void ThrowIfArgumentIsNull<T>(this T value, string paramName = "this parameter")
            where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(
                    paramName + " not allowed to be null");
            }
        }

        /// <summary>
        ///     Throws if argument is null or empty.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static void ThrowIfArgumentIsNullOrEmpty(this string value, string paramName = "this parameter")
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(
                    paramName + " not allowed to be null or empty");
            }
        }

        /// <summary>
        ///     Throws if argument is null or white space.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static void ThrowIfArgumentIsNullOrWhiteSpace(this string value, string paramName = "this parameter")
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(
                    paramName + " not allowed to be null, empty or consists exclusively of white-space characters.");
            }
        }

        /// <summary>
        ///     Throws if collection is null or empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static void ThrowIfCollectionIsNullOrEmpty<T>(this IList<T> collection,
            string paramName = "this parameter")
        {
            if (collection == null)
            {
                throw new ArgumentNullException(
                    paramName + " not allowed to be null");
            }

            if (!collection.Any())
            {
                throw new ArgumentNullException(
                    paramName + " not allowed to be empty.");
            }
        }

        /// <summary>
        ///     Throws if greater than zero.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">argument must be less than 0</exception>
        public static void ThrowIfGreaterThanZero(this int value, string paramName = "this parameter")
        {
            if (value >= 0)
            {
                throw new ArgumentOutOfRangeException(
                    paramName, "argument must be less than 0");
            }
        }

        /// <summary>
        ///     Throws if less than zero.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">argument must be greater or equals than 0</exception>
        public static void ThrowIfLessThanZero(this int value, string paramName = "this parameter")
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(
                    paramName, "argument must be greater or equals than 0");
            }
        }

        /// <summary>
        ///     Throws if less or equals than zero.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">argument must be greater or equals than 0</exception>
        public static void ThrowIfLessOrEqualsThanZero(this int value, string paramName = "this parameter")
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    paramName, "argument must be greater or equals than 0");
            }
        }

        #endregion
    }
}