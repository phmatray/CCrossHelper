/* Author : 
 * Jerry Nixon, Philippe Matray
 * 
 * Date:
 * 2014-02-14
 * 
 * Link:
 * http://blog.jerrynixon.com/2013/12/the-two-ways-to-handle-orientation-in.html
 */

using System;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CCrossHelper.Lib.Store.Helpers
{
    public class OrientationHelper
    {
        #region properties

        public string LandscapeStateName
        {
            get { return "Landscape"; }
        }

        public string PortraitStateName
        {
            get { return "Portrait"; }
        }

        #endregion

        #region methods
        
        public void Current_SizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            var page = sender as Page;
            if (page == null)
                throw new Exception("sender is not a page");

            var o = ApplicationView.GetForCurrentView().Orientation;

            var stateName = o.Equals(ApplicationViewOrientation.Landscape) 
                ? LandscapeStateName 
                : PortraitStateName;

            VisualStateManager.GoToState(page, stateName, true);
        }

        #endregion
    }
}