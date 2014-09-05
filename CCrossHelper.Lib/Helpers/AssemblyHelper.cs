
/* Author: 
 * Philippe Matray
 * 
 * Date: 
 * 2014-07-01
 */

using System.Reflection;

namespace CCrossHelper.Lib.Helpers
{
    public static class AssemblyHelper
    {
        /// <summary>
        ///     Gets the assembly version.
        /// </summary>
        /// <remarks>
        ///     It's also worth noting that if both AssemblyVersion and AssemblyFileVersion are specified, you won't see this on
        ///     your .exe. The 3rd number is the number of days since the year 2000, and the 4th number is the number of seconds
        ///     since midnight (divided by 2) [IT IS NOT RANDOM]. So if you built the solution late in a day one day, and early in
        ///     a day the next day, the later build would have an earlier version number. I recommend always using X.Y.* instead of
        ///     X.Y.Z.* because your version number will ALWAYS increase this way.
        /// </remarks>
        /// <returns>
        ///     The assembly version.
        /// </returns>
        public static string GetAssemblyVersion()
        {
            string retval = Assembly.GetCallingAssembly()
                .GetName()
                .Version
                .ToString();

            return retval;
        }
    }
}