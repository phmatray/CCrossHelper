/* Author : 
 * Philippe Matray
 * 
 * Date:
 * 2014-01-23
 */

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CCrossHelper.Lib.Phone.Converters
{
    /// <summary>
    ///     Value converter that translates true to <see cref="Visibility.Visible" /> and false to
    ///     <see cref="Visibility.Collapsed" />.
    /// </summary>
    public sealed class BooleanToVisibilityConverter : IValueConverter
    {
        #region methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value is bool && (bool) value)
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Visibility && (Visibility) value == Visibility.Visible;
        }

        #endregion
    }
}