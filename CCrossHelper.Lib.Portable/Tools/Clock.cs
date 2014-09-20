/* Author: 
 * Olivier Dahan
 * 
 * Link: 
 * http://www.e-naxos.com/Blog/post/Du-mauvais-usage-de-DateTimeNow-dans-les-applications.aspx
 */

using System;

namespace CCrossHelper.Lib.Portable.Tools
{
    public class Clock
    {
        #region Fields

        private static Func<DateTime> _function;

        #endregion

        #region Ctors

        static Clock()
        {
            _function = () => DateTime.Now;
        }

        #endregion

        #region Properties

        public static DateTime Now
        {
            get { return _function(); }
        }

        public static Func<DateTime> FunctionNow
        {
            set { _function = value ?? (() => DateTime.Now); }
        }

        #endregion

        #region Methods

        public static void Reset()
        {
            FunctionNow = null;
        }

        #endregion
    }
}