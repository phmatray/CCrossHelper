/* Author : 
 * Philippe Matray
 * 
 * Date : 
 * 2014-07-26
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CCrossHelper.Lib.Portable.Extensions
{
    public static class ListExtension
    {
        /// <summary>
        ///     Convert IEnumerable to ObservableCollection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source)
        {
            var retval = new ObservableCollection<T>();
            foreach (var item in source)
                retval.Add(item);

            return retval;
        }
    }
}