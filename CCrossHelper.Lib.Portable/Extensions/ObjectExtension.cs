/* Author : 
 * Philippe Matray
 * 
 * Date:
 * 2014-03-26
 */

using System.IO;
using System.Runtime.Serialization;

namespace CCrossHelper.Lib.Portable.Extensions
{
    public static class ObjectExtension
    {
        /// <summary>
        ///     Performs a deep clone.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T DeepClone<T>(this T obj)
        {
            T cloned;

            var serializer = new DataContractSerializer(typeof (T));

            using (var ms = new MemoryStream())
            {
                serializer.WriteObject(ms, obj);
                ms.Position = 0;
                cloned = (T) serializer.ReadObject(ms);
            }

            return cloned;
        }

        /// <summary>
        ///     Determines whether the specified source is null.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static bool IsNull(this object source)
        {
            return source == null;
        }
    }
}