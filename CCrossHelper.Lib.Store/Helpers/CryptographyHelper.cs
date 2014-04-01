/* Author : 
 * Philippe Matray
 * 
 * Date:
 * 2014-03-26
 */

using System;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;

namespace CCrossHelper.Lib.Store.Helpers
{
    public static class CryptographyHelper
    {
        #region methods

        /// <summary>
        ///     Computes the MD5.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">str</exception>
        public static string ComputeMd5(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                throw new ArgumentNullException("str");

            HashAlgorithmProvider hashAlgorithmProvider = HashAlgorithmProvider.OpenAlgorithm("MD5");
            IBuffer binary = CryptographicBuffer.ConvertStringToBinary(str, BinaryStringEncoding.Utf8);
            return CryptographicBuffer.EncodeToHexString(hashAlgorithmProvider.HashData(binary));
        }

        /// <summary>
        ///     Encodes the hexadecimal.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">data</exception>
        public static string EncodeHex(this Byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException("data");

            string str = "";
            Byte[] numArray = data;
            for (Int32 i = 0; i < numArray.Length; i++)
            {
                int num = (Char)numArray[i];
                object[] objArray = { Convert.ToUInt32(num.ToString()) };
                str = String.Concat(str, String.Format("{0:x2}", objArray));
            }
            return str;
        }

        #endregion
    }
}