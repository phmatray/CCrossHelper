/* Author : 
 * Philippe Matray
 * 
 * Date : 
 * 2014-09-22
 *
 * Link:
 * http://www.codeproject.com/Tips/549109/Working-with-SecureString
 */

using System;
using System.Runtime.InteropServices;
using System.Security;

namespace CCrossHelper.Lib.Extensions
{
    public static class SecureStringExtension
    {
        /// <summary>
        ///     Converts to secure string.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static SecureString ConvertToSecureString(this string source)
        {
            var secureString = new SecureString();

            if (source.Length > 0)
                foreach (char c in source)
                    secureString.AppendChar(c);

            return secureString;
        }

        /// <summary>
        /// Converts to unsecure string.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static string ConvertToString(this SecureString source)
        {
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(source);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}