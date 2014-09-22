/* Author : 
 * Philippe Matray
 * 
 * Date : 
 * 2014-09-22
 */

using System.Globalization;

namespace CCrossHelper.Lib.Portable.Extensions
{
    public static class StringExtension
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
    }
}