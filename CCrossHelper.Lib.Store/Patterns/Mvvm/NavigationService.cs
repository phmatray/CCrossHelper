/* Author : 
 * Philippe Matray
 * 
 * Date:
 * 2014-01-30
 */

using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace CCrossHelper.Lib.Store.Patterns.Mvvm
{
    public class NavigationService : INavigationService
    {
        #region fields

        private readonly Frame _frame;
        public event NavigatingCancelEventHandler Navigating;

        #endregion

        #region ctor

        public NavigationService(Frame frame)
        {
            if (frame == null)
                throw new ArgumentNullException();

            frame.Navigating -= FrameNavigating;
            _frame = frame;
            _frame.Navigating += FrameNavigating;
        }

        #endregion

        #region properties

        public object Parameter { get; private set; }

        #endregion

        #region methods

        public bool Navigate(Type page, object parameter = null)
        {
            Parameter = parameter;

            return parameter == null
                ? _frame.Navigate(page)
                : _frame.Navigate(page, parameter);
        }

        public bool Navigate(string type, object parameter = null)
        {
            Parameter = parameter;

            return parameter == null
                ? _frame.Navigate(Type.GetType(type))
                : _frame.Navigate(Type.GetType(type), parameter);
        }

        public void GoBack()
        {
            if (EnsureMainFrame() && _frame.CanGoBack)
                _frame.GoBack();
        }

        private bool EnsureMainFrame()
        {
            return _frame != null;
        }

        private void FrameNavigating(object sender, NavigatingCancelEventArgs e)
        {
            if (Navigating != null)
                Navigating(this, e);
        }

        #endregion
    }
}