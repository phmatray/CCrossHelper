/* Author : 
 * Philippe Matray
 * 
 * Date : 
 * 2014-09-22
 */

using System;

namespace CCrossHelper.Lib.Portable.Extensions
{
    public static class DateTimeExtension
    {
        /// <summary>
        ///     Determines whether the specified date is monday.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static bool IsMonday(this DateTime date)
        {
            DayOfWeek dayOfWeek = date.DayOfWeek;
            bool isMonday = dayOfWeek == DayOfWeek.Monday;
            return isMonday;
        }

        /// <summary>
        ///     Determines whether the specified date is tuesday.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static bool IsTuesday(this DateTime date)
        {
            DayOfWeek dayOfWeek = date.DayOfWeek;
            bool isTuesday = dayOfWeek == DayOfWeek.Tuesday;
            return isTuesday;
        }

        /// <summary>
        ///     Determines whether the specified date is wednesday.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static bool IsWednesday(this DateTime date)
        {
            DayOfWeek dayOfWeek = date.DayOfWeek;
            bool isWednesday = dayOfWeek == DayOfWeek.Wednesday;
            return isWednesday;
        }

        /// <summary>
        ///     Determines whether the specified date is thursday.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static bool IsThursday(this DateTime date)
        {
            DayOfWeek dayOfWeek = date.DayOfWeek;
            bool isThursday = dayOfWeek == DayOfWeek.Thursday;
            return isThursday;
        }

        /// <summary>
        ///     Determines whether the specified date is friday.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static bool IsFriday(this DateTime date)
        {
            DayOfWeek dayOfWeek = date.DayOfWeek;
            bool isFriday = dayOfWeek == DayOfWeek.Friday;
            return isFriday;
        }

        /// <summary>
        ///     Determines whether the specified date is saturday.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static bool IsSaturday(this DateTime date)
        {
            DayOfWeek dayOfWeek = date.DayOfWeek;
            bool isSaturday = dayOfWeek == DayOfWeek.Saturday;
            return isSaturday;
        }

        /// <summary>
        ///     Determines whether the specified date is sunday.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static bool IsSunday(this DateTime date)
        {
            DayOfWeek dayOfWeek = date.DayOfWeek;
            bool isSunday = dayOfWeek == DayOfWeek.Sunday;
            return isSunday;
        }

        /// <summary>
        ///     Determines whether the specified date is in the weekend.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static bool IsWeekend(this DateTime date)
        {
            bool isWeekend = date.IsSaturday() || date.IsSunday();
            return isWeekend;
        }

        /// <summary>
        ///     Determines whether the specified date is a week day.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static bool IsWeek(this DateTime date)
        {
            bool isWeek = !date.IsWeekend();
            return isWeek;
        }

        /// <summary>
        ///     Gets the first day of month.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static DateTime GetFirstDayOfMonth(this DateTime date)
        {
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            return firstDayOfMonth;
        }

        /// <summary>
        ///     Gets the last day of month.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static DateTime GetLastDayOfMonth(this DateTime date)
        {
            DateTime lastDayOfMonth = new DateTime(date.Year, date.Month + 1, 1).AddDays(-1);
            return lastDayOfMonth;
        }
    }
}