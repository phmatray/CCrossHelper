/* Author : 
 * Philippe Matray
 *
 * Date :
 * 2014-01-23
 * 
 * Link : 
 * http://stackoverflow.com/questions/5807128/an-extension-method-on-ienumerable-needed-for-shuffling
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace CCrossHelper.Lib.Portable.Extensions
{
    public static class EnumerableExtension
    {
        #region distinctsBy methods

        /// <summary>
        ///     Distincts by.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="keySelector">The key selector.</param>
        /// <returns></returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            var seenKeys = new HashSet<TKey>();
            return source.Where(element => seenKeys.Add(keySelector(element)));
        }

        #endregion

        #region shuffles methods

        /// <summary>
        ///     Shuffles the specified source.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            var randomGenerator = new Random();
            return source.Shuffle(randomGenerator);
        }

        /// <summary>
        ///     Shuffles the specified source.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="randomGenerator">The random generator.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">
        ///     source
        ///     or
        ///     randomGenerator
        /// </exception>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random randomGenerator)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (randomGenerator == null)
                throw new ArgumentNullException("randomGenerator");

            return source.ShuffleIterator(randomGenerator);
        }

        /// <summary>
        ///     Shuffles the specified source and iterates it.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="randomGenerator">The random generator.</param>
        /// <returns></returns>
        private static IEnumerable<T> ShuffleIterator<T>(this IEnumerable<T> source, Random randomGenerator)
        {
            List<T> buffer = source.ToList();

            for (int i = 0; i < buffer.Count; i++)
            {
                int j = randomGenerator.Next(i, buffer.Count);
                yield return buffer[j];

                buffer[j] = buffer[i];
            }
        }

        #endregion
    }
}