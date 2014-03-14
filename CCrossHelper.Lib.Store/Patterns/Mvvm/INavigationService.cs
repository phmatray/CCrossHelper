/* Author : 
 * Philippe Matray
 * 
 * Date:
 * 2014-01-30
 */

using System;
using Windows.UI.Xaml.Navigation;

namespace CCrossHelper.Lib.Store.Patterns.Mvvm
{
    public interface INavigationService
    {
        /// <summary>
        ///     This attribute will play a special role because it is through it than
        ///     we can recover the parameter passing of a ViewModel to another.
        /// </summary>
        object Parameter { get; }

        event NavigatingCancelEventHandler Navigating;

        /// <summary>
        ///     This method will allow us to navigate to another page with or without parameters.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="parameter"></param>
        bool Navigate(Type page, object parameter = null);

        /// <summary>
        ///     This method will allow us to navigate to another page with or without parameters.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="parameter"></param>
        bool Navigate(string type, object parameter = null);

        /// <summary>
        ///     This method will call the native GoBack method to return the frame object
        ///     to the previously viewed.
        /// </summary>
        void GoBack();
    }
}