/* Author : 
 * Philippe Matray
 *
 * Date :
 * 2014-01-23
 */

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using CCrossHelper.Lib.Portable.Helpers;

namespace CCrossHelper.Lib.Store.ClassExtensions
{
    /// <summary>
    ///     Provides helper methods for reading and writing files that are represented by objects of type IStorageFile.
    ///     (Wrapper Extensions)
    /// </summary>
    public static class FileIOExtension
    {
        /// <summary>
        ///     Reads the contents of the specified file and returns text.
        /// </summary>
        /// <returns>
        ///     When this method completes successfully, it returns the contents of the file as a text string.
        /// </returns>
        /// <param name="file">The file to read.</param>
        public static async Task<string> ReadTextAsync(this IStorageFile file)
        {
            file.ThrowIfArgumentIsNull();
            return await FileIO.ReadTextAsync(file);
        }

        /// <summary>
        ///     Reads the contents of the specified file using the specified character encoding and returns text.
        /// </summary>
        /// <returns>
        ///     When this method completes successfully, it returns the contents of the file as a text string.
        /// </returns>
        /// <param name="file">The file to read.</param>
        /// <param name="encoding">The character encoding to use.</param>
        public static async Task<string> ReadTextAsync(this IStorageFile file, UnicodeEncoding encoding)
        {
            file.ThrowIfArgumentIsNull();
            return await FileIO.ReadTextAsync(file, encoding);
        }

        /// <summary>
        ///     Writes text to the specified file.
        /// </summary>
        /// <returns>
        ///     No object or value is returned when this method completes.
        /// </returns>
        /// <param name="file">The file that the text is written to.</param>
        /// <param name="contents">The text to write.</param>
        public static async void WriteTextAsync(this IStorageFile file, string contents)
        {
            file.ThrowIfArgumentIsNull();
            await FileIO.WriteTextAsync(file, contents);
        }

        /// <summary>
        ///     Writes text to the specified file using the specified character encoding.
        /// </summary>
        /// <returns>
        ///     No object or value is returned when this method completes.
        /// </returns>
        /// <param name="file">The file that the text is written to.</param>
        /// <param name="contents">The text to write.</param>
        /// <param name="encoding">The character encoding of the file.</param>
        public static async void WriteTextAsync(this IStorageFile file, string contents, UnicodeEncoding encoding)
        {
            file.ThrowIfArgumentIsNull();
            await FileIO.WriteTextAsync(file, contents, encoding);
        }

        /// <summary>
        ///     Appends text to the specified file.
        /// </summary>
        /// <returns>
        ///     No object or value is returned when this method completes.
        /// </returns>
        /// <param name="file">The file that the text is appended to.</param>
        /// <param name="contents">The text to append.</param>
        public static async void AppendTextAsync(this IStorageFile file, string contents)
        {
            file.ThrowIfArgumentIsNull();
            await FileIO.AppendTextAsync(file, contents);
        }

        /// <summary>
        ///     Appends text to the specified file using the specified character encoding.
        /// </summary>
        /// <returns>
        ///     No object or value is returned when this method completes.
        /// </returns>
        /// <param name="file">The file that the text is appended to.</param>
        /// <param name="contents">The text to append.</param>
        /// <param name="encoding">The character encoding of the file.</param>
        public static async void AppendTextAsync(this IStorageFile file, string contents, UnicodeEncoding encoding)
        {
            file.ThrowIfArgumentIsNull();
            await FileIO.AppendTextAsync(file, contents, encoding);
        }

        /// <summary>
        ///     Reads the contents of the specified file and returns lines of text.
        /// </summary>
        /// <returns>
        ///     When this method completes successfully, it returns the contents of the file as a list (type IVector) of lines of
        ///     text. Each line of text in the list is represented by a String object.
        /// </returns>
        /// <param name="file">The file to read.</param>
        public static async Task<IList<string>> ReadLinesAsync(this IStorageFile file)
        {
            file.ThrowIfArgumentIsNull();
            return await FileIO.ReadLinesAsync(file);
        }

        /// <summary>
        ///     Reads the contents of the specified file using the specified character encoding and returns lines of text.
        /// </summary>
        /// <returns>
        ///     When this method completes successfully, it returns the contents of the file as a list (type IVector) of lines of
        ///     text. Each line of text in the list is represented by a String object.
        /// </returns>
        /// <param name="file">The file to read.</param>
        /// <param name="encoding">The character encoding to use.</param>
        public static async Task<IList<string>> ReadLinesAsync(this IStorageFile file, UnicodeEncoding encoding)
        {
            file.ThrowIfArgumentIsNull();
            return await FileIO.ReadLinesAsync(file, encoding);
        }

        /// <summary>
        ///     Writes lines to the specified file using the specified character encoding.
        /// </summary>
        /// <returns>
        ///     No object or value is returned when this method completes.
        /// </returns>
        /// <param name="file">The file that the text is written to.</param>
        /// <param name="lines">The line to write.</param>
        public static async void WriteLinesAsync(this IStorageFile file, IEnumerable<string> lines)
        {
            file.ThrowIfArgumentIsNull();
            await FileIO.WriteLinesAsync(file, lines);
        }

        /// <summary>
        ///     Writes lines to the specified file using the specified character encoding.
        /// </summary>
        /// <returns>
        ///     No object or value is returned when this method completes.
        /// </returns>
        /// <param name="file">The file that the text is written to.</param>
        /// <param name="lines">The line to write.</param>
        /// <param name="encoding">The character encoding of the file.</param>
        public static async void WriteLinesAsync(this IStorageFile file, IEnumerable<string> lines,
            UnicodeEncoding encoding)
        {
            file.ThrowIfArgumentIsNull();
            await FileIO.WriteLinesAsync(file, lines, encoding);
        }

        /// <summary>
        ///     Appends lines to the specified file using the specified character encoding.
        /// </summary>
        /// <returns>
        ///     No object or value is returned when this method completes.
        /// </returns>
        /// <param name="file">The file that the text is written to.</param>
        /// <param name="lines">The line to write.</param>
        public static async void AppendLinesAsync(this IStorageFile file, IEnumerable<string> lines)
        {
            file.ThrowIfArgumentIsNull();
            await FileIO.AppendLinesAsync(file, lines);
        }

        /// <summary>
        ///     Appends lines to the specified file using the specified character encoding.
        /// </summary>
        /// <returns>
        ///     No object or value is returned when this method completes.
        /// </returns>
        /// <param name="file">The file that the text is written to.</param>
        /// <param name="lines">The line to write.</param>
        /// <param name="encoding">The character encoding of the file.</param>
        public static async void AppendLinesAsync(this IStorageFile file, IEnumerable<string> lines,
            UnicodeEncoding encoding)
        {
            file.ThrowIfArgumentIsNull();
            await FileIO.AppendLinesAsync(file, lines, encoding);
        }

        /// <summary>
        ///     Reads the contents of the specified file and returns a buffer.
        /// </summary>
        /// <returns>
        ///     When this method completes, it returns an object (type IBuffer) that represents the contents of the file.
        /// </returns>
        /// <param name="file">The file to read.</param>
        public static async Task<IBuffer> ReadBufferAsync(this IStorageFile file)
        {
            file.ThrowIfArgumentIsNull();
            return await FileIO.ReadBufferAsync(file);
        }

        /// <summary>
        ///     Writes data from a buffer to the specified file.
        /// </summary>
        /// <returns>
        ///     No object or value is returned when this method completes.
        /// </returns>
        /// <param name="file">The file that the buffer of data is written to.</param>
        /// <param name="buffer">The buffer that contains the data to write.</param>
        public static async void WriteBufferAsync(this IStorageFile file, IBuffer buffer)
        {
            file.ThrowIfArgumentIsNull();
            await FileIO.WriteBufferAsync(file, buffer);
        }

        /// <summary>
        ///     Writes an array of bytes of data to the specified file.
        /// </summary>
        /// <returns>
        ///     No object or value is returned when this method completes.
        /// </returns>
        /// <param name="file">The file that the byte is written to.</param>
        /// <param name="buffer">The array of bytes to write.</param>
        public static async void WriteBytesAsync(this IStorageFile file, byte[] buffer)
        {
            file.ThrowIfArgumentIsNull();
            await FileIO.WriteBytesAsync(file, buffer);
        }
    }
}