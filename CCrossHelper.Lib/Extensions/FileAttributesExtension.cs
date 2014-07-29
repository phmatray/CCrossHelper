/* Author: 
 * Philippe Matray
 * 
 * Date: 
 * 2014-07-28
 * 
 * Link:
 * http://www.csharp-examples.net/file-attributes/
 */

using System.IO;

namespace CCrossHelper.Lib.Extensions
{
    public static class FileAttributesExtension
    {
        /// <summary>
        ///     Determines whether the specified attributes is read only.
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        public static bool IsReadOnly(this FileAttributes attributes)
        {
            return (attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly;
        }

        /// <summary>
        ///     Determines whether the specified attributes is hidden.
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        public static bool IsHidden(this FileAttributes attributes)
        {
            return (attributes & FileAttributes.Hidden) == FileAttributes.Hidden;
        }

        /// <summary>
        ///     Determines whether the specified attributes is system.
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        public static bool IsSystem(this FileAttributes attributes)
        {
            return (attributes & FileAttributes.System) == FileAttributes.System;
        }

        /// <summary>
        ///     Determines whether the specified attributes is directory.
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        public static bool IsDirectory(this FileAttributes attributes)
        {
            return (attributes & FileAttributes.Directory) == FileAttributes.Directory;
        }

        /// <summary>
        ///     Determines whether the specified attributes is archive.
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        public static bool IsArchive(this FileAttributes attributes)
        {
            return (attributes & FileAttributes.Archive) == FileAttributes.Archive;
        }

        /// <summary>
        ///     Determines whether the specified attributes is device.
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        public static bool IsDevice(this FileAttributes attributes)
        {
            return (attributes & FileAttributes.Device) == FileAttributes.Device;
        }

        /// <summary>
        ///     Determines whether the specified attributes is normal.
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        public static bool IsNormal(this FileAttributes attributes)
        {
            return (attributes & FileAttributes.Normal) == FileAttributes.Normal;
        }

        /// <summary>
        ///     Determines whether the specified attributes is temporary.
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        public static bool IsTemporary(this FileAttributes attributes)
        {
            return (attributes & FileAttributes.Temporary) == FileAttributes.Temporary;
        }

        /// <summary>
        ///     Determines whether the specified attributes is sparse file.
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        public static bool IsSparseFile(this FileAttributes attributes)
        {
            return (attributes & FileAttributes.SparseFile) == FileAttributes.SparseFile;
        }

        /// <summary>
        ///     Determines whether the specified attributes is reparse point.
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        public static bool IsReparsePoint(this FileAttributes attributes)
        {
            return (attributes & FileAttributes.ReparsePoint) == FileAttributes.ReparsePoint;
        }

        /// <summary>
        ///     Determines whether the specified attributes is compressed.
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        public static bool IsCompressed(this FileAttributes attributes)
        {
            return (attributes & FileAttributes.Compressed) == FileAttributes.Compressed;
        }

        /// <summary>
        ///     Determines whether the specified attributes is offline.
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        public static bool IsOffline(this FileAttributes attributes)
        {
            return (attributes & FileAttributes.Offline) == FileAttributes.Offline;
        }

        /// <summary>
        ///     Determines whether the specified attributes is not content indexed.
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        public static bool IsNotContentIndexed(this FileAttributes attributes)
        {
            return (attributes & FileAttributes.NotContentIndexed) == FileAttributes.NotContentIndexed;
        }

        /// <summary>
        ///     Determines whether the specified attributes is encrypted.
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        public static bool IsEncrypted(this FileAttributes attributes)
        {
            return (attributes & FileAttributes.Encrypted) == FileAttributes.Encrypted;
        }

        /// <summary>
        ///     Determines whether the specified attributes is integrity stream.
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        public static bool IsIntegrityStream(this FileAttributes attributes)
        {
            return (attributes & FileAttributes.IntegrityStream) == FileAttributes.IntegrityStream;
        }

        /// <summary>
        ///     Determines whether the specified attributes is no scrub data.
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        public static bool IsNoScrubData(this FileAttributes attributes)
        {
            return (attributes & FileAttributes.NoScrubData) == FileAttributes.NoScrubData;
        }
    }
}