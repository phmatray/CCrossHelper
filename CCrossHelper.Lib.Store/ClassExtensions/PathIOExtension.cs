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
    ///     Provides helper methods for reading and writing a file using the absolute path or Uniform Resource Identifier (URI)
    ///     of the file.
    ///     (Wrapper Extensions)
    /// </summary>
    public static class PathIOExtension
    {
        /// <summary>
        ///     Reads the contents of the file at the specified path or Uniform Resource Identifier (URI) and returns text.
        /// </summary>
        /// <returns>
        ///     When this method completes successfully, it returns the contents of the file as a text string.
        /// </returns>
        /// <param name="absolutePath">The path of the file to read.</param>
        public static async Task<string> ReadTextAsync(this Uri absolutePath)
        {
            absolutePath.ThrowIfArgumentIsNull();
            return await PathIO.ReadTextAsync(absolutePath.AbsolutePath);
        }

        /// <summary>
        ///     Reads the contents of the file at the specified path or Uniform Resource Identifier (URI) using the specified
        ///     character encoding and returns text.
        /// </summary>
        /// <returns>
        ///     When this method completes successfully, it returns the contents of the file as a text string.
        /// </returns>
        /// <param name="absolutePath">The path of the file to read.</param>
        /// <param name="encoding">The character encoding of the file.</param>
        public static async Task<string> ReadTextAsync(this Uri absolutePath, UnicodeEncoding encoding)
        {
            absolutePath.ThrowIfArgumentIsNull();
            return await PathIO.ReadTextAsync(absolutePath.AbsolutePath, encoding);
        }

        /// <summary>
        ///     Writes text to the file at the specified path or Uniform Resource Identifier (URI).
        /// </summary>
        /// <returns>
        ///     No object or value is returned when this method completes.
        /// </returns>
        /// <param name="absolutePath">The path of the file that the text is written to.</param>
        /// <param name="contents">The text to write.</param>
        public static async void WriteTextAsync(this Uri absolutePath, string contents)
        {
            absolutePath.ThrowIfArgumentIsNull();
            await PathIO.WriteTextAsync(absolutePath.AbsolutePath, contents);
        }

        /// <summary>
        ///     Writes text to the file at the specified path or Uniform Resource Identifier (URI) using the specified character
        ///     encoding.
        /// </summary>
        /// <returns>
        ///     No object or value is returned when this method completes.
        /// </returns>
        /// <param name="absolutePath">The path of the file that the text is written to.</param>
        /// <param name="contents">The text to write.</param>
        /// <param name="encoding">The character encoding of the file.</param>
        public static async void WriteTextAsync(this Uri absolutePath, string contents, UnicodeEncoding encoding)
        {
            absolutePath.ThrowIfArgumentIsNull();
            await PathIO.WriteTextAsync(absolutePath.AbsolutePath, contents, encoding);
        }

        /// <summary>
        ///     Appends text to the file at the specified path or Uniform Resource Identifier (URI).
        /// </summary>
        /// <returns>
        ///     No object or value is returned when this method completes.
        /// </returns>
        /// <param name="absolutePath">The path of the file that the text is appended to.</param>
        /// <param name="contents">The text to append.</param>
        public static async void AppendTextAsync(this Uri absolutePath, string contents)
        {
            absolutePath.ThrowIfArgumentIsNull();
            await PathIO.AppendTextAsync(absolutePath.AbsolutePath, contents);
        }

        /// <summary>
        ///     Appends text to the file at the specified path or Uniform Resource Identifier (URI) using the specified character
        ///     encoding.
        /// </summary>
        /// <returns>
        ///     No object or value is returned when this method completes.
        /// </returns>
        /// <param name="absolutePath">The path of the file that the text is appended to.</param>
        /// <param name="contents">The text to append.</param>
        /// <param name="encoding">The character encoding of the file.</param>
        public static async void AppendTextAsync(this Uri absolutePath, string contents, UnicodeEncoding encoding)
        {
            absolutePath.ThrowIfArgumentIsNull();
            await PathIO.AppendTextAsync(absolutePath.AbsolutePath, contents, encoding);
        }

        /// <summary>
        ///     Reads the contents of the file at the specified path or Uniform Resource Identifier (URI) and returns lines of
        ///     text.
        /// </summary>
        /// <returns>
        ///     When this method completes successfully, it returns the contents of the file as a list (type IVector) of lines of
        ///     text. Each line of text in the list is represented by a String object.
        /// </returns>
        /// <param name="absolutePath">The path of the file to read.</param>
        public static async Task<IList<string>> ReadLinesAsync(this Uri absolutePath)
        {
            absolutePath.ThrowIfArgumentIsNull();
            return await PathIO.ReadLinesAsync(absolutePath.AbsolutePath);
        }

        /// <summary>
        ///     Reads the contents of the file at the specified path or Uniform Resource Identifier (URI) using the specified
        ///     character encoding and returns lines of text.
        /// </summary>
        /// <returns>
        ///     When this method completes successfully, it returns the contents of the file as a list (type IVector) of lines of
        ///     text. Each line of text in the list is represented by a String object.
        /// </returns>
        /// <param name="absolutePath">The path of the file to read.</param>
        /// <param name="encoding">The character encoding of the file.</param>
        public static async Task<IList<string>> ReadLinesAsync(this Uri absolutePath, UnicodeEncoding encoding)
        {
            absolutePath.ThrowIfArgumentIsNull();
            return await PathIO.ReadLinesAsync(absolutePath.AbsolutePath, encoding);
        }

        /// <summary>
        ///     Writes lines to the file at the specified path or Uniform Resource Identifier (URI) using the specified character
        ///     encoding.
        /// </summary>
        /// <returns>
        ///     No object or value is returned when this method completes.
        /// </returns>
        /// <param name="absolutePath">The path of the file that the lines is written to.</param>
        /// <param name="lines">The lines to write.</param>
        public static async void WriteLinesAsync(this Uri absolutePath, IEnumerable<string> lines)
        {
            absolutePath.ThrowIfArgumentIsNull();
            await PathIO.WriteLinesAsync(absolutePath.AbsolutePath, lines);
        }

        /// <summary>
        ///     Writes lines to the file at the specified path or Uniform Resource Identifier (URI) using the specified character
        ///     encoding.
        /// </summary>
        /// <returns>
        ///     No object or value is returned when this method completes.
        /// </returns>
        /// <param name="absolutePath">The path of the file that the lines is written to.</param>
        /// <param name="lines">The lines to write.</param>
        /// <param name="encoding">The character encoding of the file.</param>
        public static async void WriteLinesAsync(this Uri absolutePath, IEnumerable<string> lines,
            UnicodeEncoding encoding)
        {
            absolutePath.ThrowIfArgumentIsNull();
            await PathIO.WriteLinesAsync(absolutePath.AbsolutePath, lines, encoding);
        }

        /// <summary>
        ///     Appends lines to the file at the specified path or Uniform Resource Identifier (URI) using the specified character
        ///     encoding.
        /// </summary>
        /// <returns>
        ///     No object or value is returned when this method completes.
        /// </returns>
        /// <param name="absolutePath">The path of the file that the lines is written to.</param>
        /// <param name="lines">The lines to write.</param>
        public static async void AppendLinesAsync(this Uri absolutePath, IEnumerable<string> lines)
        {
            absolutePath.ThrowIfArgumentIsNull();
            await PathIO.AppendLinesAsync(absolutePath.AbsolutePath, lines);
        }

        /// <summary>
        ///     Appends lines to the file at the specified path or Uniform Resource Identifier (URI) using the specified character
        ///     encoding.
        /// </summary>
        /// <returns>
        ///     No object or value is returned when this method completes.
        /// </returns>
        /// <param name="absolutePath">The path of the file that the lines is written to.</param>
        /// <param name="lines">The lines to write.</param>
        /// <param name="encoding">The character encoding of the file.</param>
        public static async void AppendLinesAsync(this Uri absolutePath, IEnumerable<string> lines,
            UnicodeEncoding encoding)
        {
            absolutePath.ThrowIfArgumentIsNull();
            await PathIO.AppendLinesAsync(absolutePath.AbsolutePath, lines, encoding);
        }

        /// <summary>
        ///     Reads the contents of the file at the specified path or Uniform Resource Identifier (URI) and returns a buffer.
        /// </summary>
        /// <returns>
        ///     When this method completes, it returns an object (type IBuffer) that represents the contents of the file.
        /// </returns>
        /// <param name="absolutePath">The path of the file to read.</param>
        public static async Task<IBuffer> ReadBufferAsync(this Uri absolutePath)
        {
            absolutePath.ThrowIfArgumentIsNull();
            return await PathIO.ReadBufferAsync(absolutePath.AbsolutePath);
        }

        /// <summary>
        ///     Writes data from a buffer to the file at the specified path or Uniform Resource Identifier (URI).
        /// </summary>
        /// <returns>
        ///     No object or value is returned when this method completes.
        /// </returns>
        /// <param name="absolutePath">The path of the file that the data is written to.</param>
        /// <param name="buffer">The buffer that contains the data to write.</param>
        public static async void WriteBufferAsync(this Uri absolutePath, IBuffer buffer)
        {
            absolutePath.ThrowIfArgumentIsNull();
            await PathIO.WriteBufferAsync(absolutePath.AbsolutePath, buffer);
        }

        /// <summary>
        ///     Writes a single byte of data to the file at the specified path or Uniform Resource Identifier (URI).
        /// </summary>
        /// <returns>
        ///     No object or value is returned when this method completes.
        /// </returns>
        /// <param name="absolutePath">The path of the file that the byte is written to.</param>
        /// <param name="buffer">An array of bytes to write.</param>
        public static async void WriteBytesAsync(this Uri absolutePath, byte[] buffer)
        {
            absolutePath.ThrowIfArgumentIsNull();
            await PathIO.WriteBytesAsync(absolutePath.AbsolutePath, buffer);
        }
    }
}