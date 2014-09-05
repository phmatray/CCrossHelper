/* Author: 
 * Philippe Matray
 * 
 * Date: 
 * 2014-07-29 -> 2014-09-05
 */

using System;
using System.Runtime.InteropServices;
using System.Security;

namespace CCrossHelper.Lib.Helpers
{
    public static class ConsoleHelper
    {
        #region ColorConsole

        public static void Write(ConsoleColor color, string format, params object[] arg)
        {
            Console.ForegroundColor = color;
            Console.Write(format, arg);
            Console.ResetColor();
        }

        public static void Write(int cursorLeft, ConsoleColor color, string format, params object[] arg)
        {
            Console.CursorLeft = cursorLeft;
            Write(color, format, arg);
        }

        public static void WriteLine(ConsoleColor color, string format, params object[] arg)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(format, arg);
            Console.ResetColor();
        }

        public static void WriteLine(int cursorLeft, ConsoleColor color, string format, params object[] arg)
        {
            Console.CursorLeft = cursorLeft;
            WriteLine(color, format, arg);
        }

        #endregion

        #region OpenConsole

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

        #endregion
    }
}
