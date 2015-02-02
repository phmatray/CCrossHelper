/* Author: 
 * Philippe Matray
 * 
 * Date:
 * 2014-01-23, 2014-01-27
 */

using System;

namespace CCrossHelper.Lib.Portable.Extensions
{
    public static partial class NumberExtension
    {
        /// <summary>
        ///     Determines whether the specified number is odd.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        public static bool IsOdd(this int number)
        {
            return ((number & 1) == 1);
        }

        /// <summary>
        ///     Determines whether the specified number is odd.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        public static bool IsOdd(this uint number)
        {
            return ((number & 1) == 1);
        }

        /// <summary>
        ///     Determines whether the specified number is even.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        public static bool IsEven(this int number)
        {
            return ((number & 1) == 0);
        }

        /// <summary>
        ///     Determines whether the specified number is even.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        public static bool IsEven(this uint number)
        {
            return ((number & 1) == 0);
        }

        /// <summary>
        ///     Converts number to its roman representation.
        /// </summary>
        /// <example>
        ///     http://stackoverflow.com/questions/7040289/converting-integers-to-roman-numerals
        /// </example>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string ToRoman(this int number)
        {
            if ((number < 0) || (number > 3999))
                throw new ArgumentOutOfRangeException("number", number, "insert value betwheen 1 and 3999");

            if (number < 1) return String.Empty;
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900);
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);

            throw new ArgumentOutOfRangeException("number", number, "something bad happened");
        }
    }
}