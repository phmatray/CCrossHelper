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
    ///     Value converter that translates true to false and false to true;
    /// </summary>
    public sealed class BooleanNegateConverter : IValueConverter
    {
        #region methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(value is bool && (bool) value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(value is bool && (bool) value);
        }

        #endregion
    }
}