/* Author : 
 * Philippe Matray
 * 
 * Date : 
 * 2014-09-22
 */

using System;

namespace CCrossHelper.Lib.Portable.Extensions
{
    public static partial class ComparableExtension
    {
        /// <summary>
        ///     Check whether a value is between two others (inclusive).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        /// <returns></returns>
        public static bool BetweenInclusive<T>(this T value, T from, T to)
            where T : IComparable<T>
        {
            return value.CompareTo(from) >= 0 && value.CompareTo(to) <= 0;
        }

        /// <summary>
        ///     Check whether a value is between two others (exclusive).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        /// <returns></returns>
        public static bool BetweenExclusive<T>(this T value, T from, T to)
            where T : IComparable<T>
        {
            return value.CompareTo(from) > 0 && value.CompareTo(to) < 0;
        }
    }
}