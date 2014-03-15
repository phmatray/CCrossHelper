/* Author:
 * Diederik Krols
 * 
 * Link: 
 * http://blogs.u2u.be/diederik/post/2012/03/19/A-StringFormat-converter-for-Windows-8-Metro.aspx
 * 
 * Date:
 * 2012-03-19
 */

using System;
using Windows.UI.Xaml.Data;

namespace CCrossHelper.Lib.Store.Converters
{
    public class StringFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            // No format provided.
            if (parameter == null)
                return value;

            return String.Format((String)parameter, value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}