/* Author : 
 * Philippe Matray
 * 
 * Date:
 * 2014-01-23
 */

using System;
using System.Globalization;
using System.Windows.Data;

namespace CCrossHelper.Lib.Phone.Converters
{
    /// <summary>
    ///     Value converter that translates a string to lower.
    /// </summary>
    public class StringToLowerConverter : IValueConverter
    {
        #region methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string)
                return (value as string).ToLower();

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}