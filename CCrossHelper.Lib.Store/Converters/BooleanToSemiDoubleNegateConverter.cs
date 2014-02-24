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
    ///     Value converter that translates true to 0 and false to SemiOpacityValue;
    /// </summary>
    public sealed class BooleanToSemiDoubleNegateConverter : IValueConverter
    {
        #region constants

        private const double NoneOpacityValueConst = 0;
        private const double SemiOpacityValueConst = 0.5;

        #endregion

        #region fields

        private double _semiOpacityValue;

        #endregion

        #region methods

        public object Convert(object value, Type targetType, object semiOpacityValue, string language)
        {
            _semiOpacityValue = semiOpacityValue is double
                ? (double)semiOpacityValue
                : SemiOpacityValueConst;

            return (value is bool && (bool)value)
                ? NoneOpacityValueConst
                : _semiOpacityValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value is double && Math.Abs((double)value - NoneOpacityValueConst) < 0.0001;
        }

        #endregion
    }
}