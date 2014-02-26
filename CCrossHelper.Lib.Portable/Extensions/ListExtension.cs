using System;
using System.Collections.Generic;

namespace CCrossHelper.Lib.Portable.Extensions
{
    public static class ListExtension
    {
        /// <summary>
        ///     Shuffles the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Shuffle<T>(this IList<T> source)
        {
            // http://stackoverflow.com/questions/273313/

            var rnd = new Random();
            int n = source.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                T value = source[k];
                source[k] = source[n];
                source[n] = value;
            }
        }
    }
}