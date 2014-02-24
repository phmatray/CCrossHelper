/* Author : 
 * Philippe Matray
 *
 * Date :
 * 2014-01-23
 */

using System;
using CCrossHelper.Lib.Portable.Helpers;

namespace CCrossHelper.Lib.Portable.Tools
{
    public static class Keyword
    {
        #region methods

        /// <summary>
        ///     Invokes the specified function one in ... chance.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="oneIn">The one in ... chance.</param>
        public static void Maybe(this Action action, int oneIn = 2)
        {
            oneIn.ThrowIfLessOrEqualsThanZero("oneIn");

            int number1 = StaticRandom.Instance.Next(oneIn);
            int number2 = StaticRandom.Instance.Next(oneIn);

            if (number1 == number2)
                action.Invoke();
        }

        /// <summary>
        ///     Invokes the specified function one in ... chance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="function">The function.</param>
        /// <param name="oneIn">The one in ... chance.</param>
        /// <returns></returns>
        public static T Maybe<T>(this Func<T> function, int oneIn = 2)
        {
            oneIn.ThrowIfLessOrEqualsThanZero("oneIn");

            int number1 = StaticRandom.Instance.Next(oneIn);
            int number2 = StaticRandom.Instance.Next(oneIn);

            if (number1 == number2)
                return function.Invoke();

            return default(T);
        }

        #endregion
    }
}