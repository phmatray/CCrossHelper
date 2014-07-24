/* Author : 
 * Philippe Matray
 * 
 * Date : 
 * 2014-07-23
 */

using System.Linq;
using System.Text;

namespace CCrossHelper.Lib.Portable.Extensions
{
    public static class ArrayExtension
    {
        #region Public Methods

        public static string ToString<T>(this T[] array)
        {
            var sb = new StringBuilder(string.Empty);
            foreach (var obj in array)
                sb.AppendLine(obj.ToString());

            return sb.ToString();
        }

        public static T[] Trim<T>(this T[] array)
        {
            var retval = array
                .SkipWhile(arg => arg.Equals(default(T)))
                .Reverse()
                .SkipWhile(arg => arg.Equals(default(T)))
                .Reverse()
                .ToArray();

            return retval;
        }

        public static T[] Remove<T>(this T[] array, T toRemove = default(T))
        {
            var retval = array
                .Where(arg => !arg.Equals(toRemove))
                .ToArray();

            return retval;
        }

        public static T[] Remove<T>(this T[] array, params T[] toRemoves)
        {
            var retval = array
                .Where(arg => !toRemoves.Contains(arg))
                .ToArray();

            return retval;
        }

        public static T[] Replace<T>(this T[] array, T oldValue, T newValue)
        {
            var retval = array
                .Select(arg => arg.Equals(oldValue) ? newValue : arg)
                .ToArray();

            return retval;
        }

        public static T[] ToArray<T>(this T[][] jaggedArray)
        {
            var elementsCount = jaggedArray.Sum(arg => arg.Length);
            var retval = new T[elementsCount];

            int index = 0;
            foreach (var t in jaggedArray)
                foreach (var t1 in t)
                    retval[index++] = t1;

            return retval;
        }

        public static T[] ToArray<T>(this T[,] multiArray)
        {
            var lines = multiArray.CountLines();
            var columns = multiArray.CountColumns();
            var retval = new T[lines * columns];

            for (int i = 0; i < lines; i++)
                for (int j = 0; j < columns; j++)
                    retval[i * columns + j] = multiArray[i, j];

            return retval;
        }

        public static T[][] ToJaggedArray<T>(this T[,] multiArray)
        {
            var lines = multiArray.CountLines();
            var columns = multiArray.CountColumns();
            var retval = new T[lines][];

            for (int i = 0; i < lines; i++)
            {
                retval[i] = new T[columns];
                for (int j = 0; j < columns; j++)
                    retval[i][j] = multiArray[i, j];
            }

            return retval;
        }

        public static T[,] ToMultiArray<T>(this T[][] jaggedArray)
        {
            int lines = jaggedArray.CountLines();
            int columns = jaggedArray.CountColumns();
            var retval = new T[lines, columns];

            for (int i = 0; i < jaggedArray.Length; i++)
                for (int j = 0; j < jaggedArray[i].Length; j++)
                    retval[i, j] = jaggedArray[i][j];

            return retval;
        }

        public static int CountLines<T>(this T[,] multiArray)
        {
            return multiArray.GetLength(0);
        }

        public static int CountColumns<T>(this T[,] multiArray)
        {
            return multiArray.GetLength(1);
        }

        public static int CountLines<T>(this T[][] jaggedArray)
        {
            return jaggedArray.Length;
        }

        public static int CountColumns<T>(this T[][] jaggedArray)
        {
            return jaggedArray.Max(arg => arg.Length);
        }

        #endregion
    }
}