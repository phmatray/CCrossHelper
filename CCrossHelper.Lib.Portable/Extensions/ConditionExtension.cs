/* Author : 
 * Philippe Matray
 * 
 * Date : 
 * 2014-09-22
 */

using System;
using System.Linq;

namespace CCrossHelper.Lib.Portable.Extensions
{
    public static partial class ConditionExtension
    {
        public static bool EqualsAnyOf<T>(this T source, params T[] list)
        {
            if (source.Equals(null))
                throw new ArgumentNullException("source");

            return list.Contains(source);
        }
    }
}