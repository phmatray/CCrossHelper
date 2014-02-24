/* Author : 
 * Philippe Matray
 * 
 * Date:
 * 2014-01-30
 */

using System;
using Windows.UI.Xaml.Data;

namespace CCrossHelper.Lib.Store.Converters
{
    /// <summary>
    ///     Value converter that translates true to false and false to true;
    /// </summary>
    public sealed class BooleanNegateConverter : IValueConverter
    {
        #region methods

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return !(value is bool && (bool)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return !(value is bool && (bool)value);
        }

        #endregion
    }
}