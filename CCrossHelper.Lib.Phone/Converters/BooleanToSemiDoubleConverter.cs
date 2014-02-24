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
    ///     Value converter that translates true to SemiOpacityValue and false to 0;
    /// </summary>
    public sealed class BooleanToSemiDoubleConverter : IValueConverter
    {
        #region constants

        private const double NoneOpacityValueConst = 0;
        private const double SemiOpacityValueConst = 0.5;

        #endregion

        #region fields

        private double _semiOpacityValue;

        #endregion

        #region methods

        public object Convert(object value, Type targetType, object semiOpacityValue, CultureInfo culture)
        {
            _semiOpacityValue = semiOpacityValue is double
                ? (double) semiOpacityValue
                : SemiOpacityValueConst;

            return (value is bool && (bool) value)
                ? _semiOpacityValue
                : NoneOpacityValueConst;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is double && Math.Abs((double) value - _semiOpacityValue) < 0.0001;
        }

        #endregion
    }
}