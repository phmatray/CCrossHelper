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
    ///     Value converter that translates true to <see cref="Visibility.Visible" /> and false to
    ///     <see cref="Visibility.Collapsed" />.
    /// </summary>
    public sealed class BooleanToVisibilityConverter : IValueConverter
    {
        #region methods

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (value is bool && (bool)value)
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value is Visibility && (Visibility)value == Visibility.Visible;
        }

        #endregion
    }
}