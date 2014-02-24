/* Author : 
 * Philippe Matray
 *
 * Date :
 * 2014-01-23
 */

using System;

namespace CCrossHelper.Lib.Portable.Tools
{
    public static class TimeSpanPicker
    {
        #region methods

        /// <summary>
        ///     Picks the milliseconds.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
        /// <param name="maxValue">The inclusive upper bound of the random number returned.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException">minValue;minValue is greater than maxValue.</exception>
        public static TimeSpan PickMilliseconds(int minValue = 0, int maxValue = 1000)
        {
            if (minValue >= maxValue)
                throw new ArgumentOutOfRangeException("minValue", "minValue is greater than maxValue.");

            return TimeSpan.FromMilliseconds(StaticRandom.Instance.Next(minValue, ++maxValue));
        }

        /// <summary>
        ///     Picks the seconds.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
        /// <param name="maxValue">The inclusive upper bound of the random number returned.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException">minValue;minValue is greater than maxValue.</exception>
        public static TimeSpan PickSeconds(int minValue = 0, int maxValue = 60)
        {
            if (minValue >= maxValue)
                throw new ArgumentOutOfRangeException("minValue", "minValue is greater than maxValue.");

            return TimeSpan.FromSeconds(StaticRandom.Instance.Next(minValue, ++maxValue));
        }

        /// <summary>
        ///     Picks the minutes.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
        /// <param name="maxValue">The inclusive upper bound of the random number returned.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException">minValue;minValue is greater than maxValue.</exception>
        public static TimeSpan PickMinutes(int minValue = 0, int maxValue = 60)
        {
            if (minValue >= maxValue)
                throw new ArgumentOutOfRangeException("minValue", "minValue is greater than maxValue.");

            return TimeSpan.FromMinutes(StaticRandom.Instance.Next(minValue, ++maxValue));
        }

        /// <summary>
        ///     Picks the hours.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
        /// <param name="maxValue">The inclusive upper bound of the random number returned.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException">minValue;minValue is greater than maxValue.</exception>
        public static TimeSpan PickHours(int minValue = 0, int maxValue = 24)
        {
            if (minValue >= maxValue)
                throw new ArgumentOutOfRangeException("minValue", "minValue is greater than maxValue.");

            return TimeSpan.FromHours(StaticRandom.Instance.Next(minValue, ++maxValue));
        }

        /// <summary>
        ///     Picks the days.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
        /// <param name="maxValue">The inclusive upper bound of the random number returned.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException">minValue;minValue is greater than maxValue.</exception>
        public static TimeSpan PickDays(int minValue = 0, int maxValue = 365)
        {
            if (minValue >= maxValue)
                throw new ArgumentOutOfRangeException("minValue", "minValue is greater than maxValue.");

            return TimeSpan.FromDays(StaticRandom.Instance.Next(minValue, ++maxValue));
        }

        /// <summary>
        ///     Picks the day of week.
        /// </summary>
        /// <param name="minDay">The inclusive lower bound of the random day returned.</param>
        /// <param name="maxDay">The inclusive upper bound of the random day returned.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException">minDay;minDay is after than maxDay.</exception>
        public static DayOfWeek PickDayOfWeek(DayOfWeek minDay, DayOfWeek maxDay)
        {
            var minValue = (int)minDay;
            var maxValue = (int)maxDay;

            if (minValue >= maxValue)
                throw new ArgumentOutOfRangeException("minDay", "minDay is after than maxDay.");

            return (DayOfWeek)StaticRandom.Instance.Next(minValue, ++maxValue);
        }

        #endregion
    }
}