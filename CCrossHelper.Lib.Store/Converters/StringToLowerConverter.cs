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
    ///     Value converter that translates a string to lower.
    /// </summary>
    public class StringToLowerConverter : IValueConverter
    {
        #region methods

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is string)
                return (value as string).ToLower();

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}