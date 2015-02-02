/* Author : 
 * Philippe Matray
 *
 * Date :
 * 2014-01-23, 2015-02-01
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

        #region shift methods

        /// <summary>
        ///     Shifts a collection to the left.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="iteration">Number of iterations.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">source</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">iteration</exception>
        public static List<T> ShiftLeft<T>(this IEnumerable<T> source, int iteration = 1)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (iteration < 0)
                throw new ArgumentOutOfRangeException("iteration");

            var result = new List<T>(source);
            for (var i = 0; i < iteration; i++)
            {
                var first = result.First();
                result.Remove(first);
                result.Add(first);
            }

            return result;
        }

        /// <summary>
        ///     Shifts a collection to the right.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="iteration">Number of iterations.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">source</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">iteration</exception>
        public static List<T> ShiftRight<T>(this IEnumerable<T> source, int iteration = 1)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (iteration < 0)
                throw new ArgumentOutOfRangeException("iteration");

            var result = new List<T>(source);
            for (var i = 0; i < iteration; i++)
            {
                var last = result.Last();
                result.Remove(last);
                result.Insert(0, last);
            }

            return result;
        }

        #endregion
    }
}