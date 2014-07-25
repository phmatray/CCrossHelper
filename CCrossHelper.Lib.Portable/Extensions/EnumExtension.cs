/* Author : 
 * Philippe Matray
 *
 * Date :
 * 2014-01-23
 */

using System;
using System.Reflection;
using CCrossHelper.Lib.Portable.Tools;

namespace CCrossHelper.Lib.Portable.Extensions
{
    public static class EnumExtension
    {
        /// <summary>
        ///     Gets the attribute.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The enum value.</param>
        /// <returns></returns>
        public static T GetAttribute<T>(this Enum value)
            where T : Attribute
        {
            var retval = value
                .GetType()
                .GetTypeInfo()
                .GetDeclaredField(value.ToString())
                .GetCustomAttribute<T>();

            return retval;
        }

        /// <summary>
        ///     Gets a random value of enumeration.
        /// </summary>
        /// <returns></returns>
        public static T GetRandomEnumValue<T>()
            where T : struct
        {
            if (typeof(T).GetTypeInfo().IsEnum)
                throw new ArgumentException("T must be an enumerated type");

            Array values = Enum.GetValues(typeof(T));
            var retval = (T)values.GetValue(StaticRandom.Instance.Next(values.Length));

            return retval;
        }
    }
}
