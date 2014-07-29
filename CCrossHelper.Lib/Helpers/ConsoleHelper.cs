/* Author: 
 * Philippe Matray
 * 
 * Date: 
 * 2014-07-29
 */

using System.Runtime.InteropServices;
using System.Security;

namespace CCrossHelper.Lib.Helpers
{
    public static class ConsoleHelper
    {
        public static int Create()
        {
            return AllocConsole() ? 0 : Marshal.GetLastWin32Error();
        }

        public static int Destroy()
        {
            return FreeConsole() ? 0 : Marshal.GetLastWin32Error();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security",
            "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage"), SuppressUnmanagedCodeSecurity]
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security",
            "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage"), SuppressUnmanagedCodeSecurity]
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FreeConsole();
    }
}
