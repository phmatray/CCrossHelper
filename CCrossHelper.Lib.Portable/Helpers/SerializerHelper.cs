/* Author : 
 * Olivier Dahan
 */

using System;
using System.IO;
using System.Xml.Serialization;

namespace CCrossHelper.Lib.Portable.Helpers
{
    public static class SerializerHelper
    {
        #region methods

        /// <summary>
        ///     Serializes to string.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static string SerializeToString(this object obj)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");

            var serializer = new XmlSerializer(obj.GetType());
            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, obj);
                return writer.ToString();
            }
        }

        /// <summary>
        ///     Deserializes from string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlText">The XML text.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">xmlText</exception>
        public static T DeserializeFromString<T>(this string xmlText)
        {
            if (string.IsNullOrWhiteSpace(xmlText))
                throw new ArgumentNullException("xmlText");

            var deserializer = new XmlSerializer(typeof(T));
            using (var reader = new StringReader(xmlText))
            {
                return (T)deserializer.Deserialize(reader);
            }
        }

        #endregion
    }
}