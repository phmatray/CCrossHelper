/* Author: 
 * Philippe Matray
 * 
 * Date: 
 * 2014-07-29 -> 2014-09-05
 */

using System;
using System.Runtime.InteropServices;
using System.Security;

namespace WideTech.Core.Common.Helpers
{
    public static class ConsoleHelper
    {
        private static ConsoleColor _backgroundColor;
        private static ConsoleColor _foregroundColor;

        #region ColorConsole

        public static void Write(ConsoleColor color, string format, params object[] arg)
        {
            SaveConsoleColors();

            Console.ForegroundColor = color;
            Console.Write(format, arg);

            ResetConsoleColors();
        }

        public static void Write(int cursorLeft, ConsoleColor color, string format, params object[] arg)
        {
            SaveConsoleColors();

            Console.CursorLeft = cursorLeft;
            Write(color, format, arg);

            ResetConsoleColors();
        }

        public static void WriteLine(ConsoleColor color, string format, params object[] arg)
        {
            SaveConsoleColors();

            Console.ForegroundColor = color;
            Console.WriteLine(format, arg);

            ResetConsoleColors();
        }

        public static void WriteLine(int cursorLeft, ConsoleColor color, string format, params object[] arg)
        {
            SaveConsoleColors();

            Console.CursorLeft = cursorLeft;
            WriteLine(color, format, arg);

            ResetConsoleColors();
        }

        private static void SaveConsoleColors()
        {
            _backgroundColor = Console.BackgroundColor;
            _foregroundColor = Console.ForegroundColor;
        }

        private static void ResetConsoleColors()
        {
            Console.BackgroundColor = _backgroundColor;
            Console.ForegroundColor = _foregroundColor;
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