/* Author : 
 * Philippe Matray
 *
 * Date :
 * 2016-01-19
 */

using System;
using CCrossHelper.Lib.Portable.Types;

namespace CCrossHelper.Lib.Portable.Extensions
{
    public static partial class GuidExtensions
    {
        public static ShortGuid ToShortGuid(this Guid guid)
        {
            ShortGuid shortGuid = guid;
            return shortGuid;
        }

        public static Guid ToGuid(this ShortGuid shortGuid)
        {
            var guid = shortGuid.Guid;
            return guid;
        }

        public static int Length(this ShortGuid shortGuid)
        {
            var length = shortGuid.Value.Length;
            return length;
        }
    }
}