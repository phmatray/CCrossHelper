/* Author: 
 * Philippe Matray, Thiru
 * 
 * Date:
 * 2014-02-14
 * 
 * Link:
 * http://stackoverflow.com/questions/10828179/how-to-get-the-resolution-of-screen-for-a-winrt-app
 */

using System;
using Windows.Foundation;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace CCrossHelper.Lib.Store.Helpers
{
    public enum ScreenTypeEnum
    {
        Slate,
        WorkHorsePC,
        FamilyHub
    }

    public class WindowHelper
    {
        #region properties

        public Rect Bounds
        {
            get { return Window.Current.Bounds; }
        }

        public double Height
        {
            get { return Bounds.Height; }
        }

        public double Width
        {
            get { return Bounds.Width; }
        }

        public double Dpi
        {
            get { return DisplayInformation.GetForCurrentView().LogicalDpi; }
        }

        public string ScreenTypeSlateName
        {
            get { return GetScreenTypeName(ScreenTypeEnum.Slate); }
        }

        public string ScreenTypeWorkHorsePCName
        {
            get { return GetScreenTypeName(ScreenTypeEnum.WorkHorsePC); }
        }

        public string ScreenTypeFamilyHubName
        {
            get { return GetScreenTypeName(ScreenTypeEnum.FamilyHub); }
        }

        #endregion

        #region methods

        public ScreenTypeEnum GetScreenType()
        {
            double h;
            switch (ApplicationView.Value)
            {
                case ApplicationViewState.FullScreenLandscape:
                case ApplicationViewState.Filled:
                case ApplicationViewState.Snapped:
                    h = Height;
                    break;
                case ApplicationViewState.FullScreenPortrait:
                    h = Width;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            double inches = h/Dpi;

            return inches < 10
                ? ScreenTypeEnum.Slate
                : inches < 14
                    ? ScreenTypeEnum.WorkHorsePC
                    : ScreenTypeEnum.FamilyHub;
        }

        public string GetScreenTypeName(ScreenTypeEnum screenType)
        {
            return Enum.GetName(typeof(ScreenTypeEnum), screenType);
        }

        #endregion
    }
}