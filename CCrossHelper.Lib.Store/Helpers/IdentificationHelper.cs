/* Author : 
 * Philippe Matray
 * 
 * Date:
 * 2014-03-26
 */

using System;
using Windows.Storage.Streams;
using Windows.System.Profile;

namespace CCrossHelper.Lib.Store.Helpers
{
    public static class IdentificationHelper
    {
        /// <summary>
        ///     Gets the hardware identifier.
        /// </summary>
        /// <returns></returns>
        public static string GetHardwareId()
        {
            HardwareToken token = HardwareIdentification.GetPackageSpecificToken(null);
            IBuffer id = token.Id;
            DataReader reader = DataReader.FromBuffer(id);
            var bytes = new byte[id.Length];
            reader.ReadBytes(bytes);

            string hardwareId = BitConverter.ToString(bytes);
            string hardwareIdMd5 = hardwareId.ComputeMd5();

            return hardwareIdMd5;
        }
    }
}