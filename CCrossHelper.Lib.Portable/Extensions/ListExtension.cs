/* Author : 
 * Philippe Matray
 * 
 * Date : 
 * 2014-07-26 -> 2014-09-23
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CCrossHelper.Lib.Portable.Extensions
{
    public static class ListExtension
    {
        /// <summary>
        ///     Convert IEnumerable to ObservableCollection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            var retval = new ObservableCollection<T>();
            foreach (T item in source)
                retval.Add(item);

            return retval;
        }

        /// <summary>
        ///     Count each occur in the source and put them in a dictionary.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">source</exception>
        public static Dictionary<T, int> ToDictionaryCount<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            Dictionary<T, int> result = source.GroupBy(arg => arg)
                .ToDictionary(g => g.Key, g => g.Count());

            return result;
        }
    }
}