using System;
using System.Linq;

namespace CCrossHelper.Lib.Portable.Extensions
{
    public static class ConditionExtension
    {
        public static bool EqualsAnyOf<T>(this T source, params T[] list)
        {
            if (source.Equals(null))
                throw new ArgumentNullException("source");

            return list.Contains(source);
        }
    }
}