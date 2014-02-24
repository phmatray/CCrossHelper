/* Author : 
 * Philippe Matray
 *
 * Date :
 * 2014-01-23
 */

using System;
using System.Threading;

namespace CCrossHelper.Lib.Portable.Tools
{
    public static class StaticRandom
    {
        #region fields

        private static readonly ThreadLocal<Random> ThreadLocal;

        #endregion

        #region ctor

        /// <summary>
        ///     Initializes the <see cref="StaticRandom" /> class.
        /// </summary>
        static StaticRandom()
        {
            int seed = Environment.TickCount;

            ThreadLocal = new ThreadLocal<Random>(
                () => new Random(Interlocked.Increment(ref seed)));
        }

        #endregion

        #region properties

        /// <summary>
        ///     Gets the instance.
        /// </summary>
        /// <value>
        ///     The instance.
        /// </value>
        public static Random Instance
        {
            get { return ThreadLocal.Value; }
        }

        #endregion
    }
}