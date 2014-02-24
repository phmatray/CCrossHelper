/* Author : 
 * Philippe Matray
 * 
 * Date:
 * 2014-01-30
 */

using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace CCrossHelper.Lib.Store.Converters
{
    /// <summary>
    ///     Value converter that translates true to <see cref="Visibility.Collapsed" /> and false to
    ///     <see cref="Visibility.Visible" />.
    /// </summary>
    public sealed class BooleanToVisibilityNegateConverter : IValueConverter
    {
        #region methods

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (value is bool && (bool)value)
                ? Visibility.Collapsed
                : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value is Visibility && (Visibility)value == Visibility.Collapsed;
        }

        #endregion
    }
}