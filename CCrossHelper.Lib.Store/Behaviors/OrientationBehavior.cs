/* Author : 
 * Jerry Nixon
 * 
 * Date:
 * 2014-02-14
 * 
 * Link:
 * http://blog.jerrynixon.com/2013/12/the-two-ways-to-handle-orientation-in.html
 */

using System.ComponentModel;
using System.Diagnostics;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.Xaml.Interactivity;

namespace CCrossHelper.Lib.Store.Behaviors
{
    [TypeConstraint(typeof (Panel))]
    public class OrientationBehavior : DependencyObject, IBehavior
    {
        public static readonly DependencyProperty LandscapeStateNameProperty =
            DependencyProperty.Register("LandscapeStateName", typeof (string), typeof (OrientationBehavior),
                new PropertyMetadata(null));

        public static readonly DependencyProperty PortraitStateNameProperty =
            DependencyProperty.Register("PortraitStateName", typeof (string), typeof (OrientationBehavior),
                new PropertyMetadata(null));

        public static readonly DependencyProperty NarrowStateNameProperty =
            DependencyProperty.Register("NarrowStateName", typeof (string), typeof (OrientationBehavior),
                new PropertyMetadata(null));

        public static readonly DependencyProperty NarrowWidthProperty =
            DependencyProperty.Register("NarrowWidth", typeof (int), typeof (OrientationBehavior),
                new PropertyMetadata(320));

        public static readonly DependencyProperty TransitionsProperty =
            DependencyProperty.Register("Transitions", typeof (bool), typeof (OrientationBehavior),
                new PropertyMetadata(true));

        [CustomPropertyValueEditor(CustomPropertyValueEditor.StateName)]
        public string LandscapeStateName
        {
            get { return (string) GetValue(LandscapeStateNameProperty); }
            set { SetValue(LandscapeStateNameProperty, value); }
        }

        [CustomPropertyValueEditor(CustomPropertyValueEditor.StateName)]
        public string PortraitStateName
        {
            get { return (string) GetValue(PortraitStateNameProperty); }
            set { SetValue(PortraitStateNameProperty, value); }
        }

        [CustomPropertyValueEditor(CustomPropertyValueEditor.StateName)]
        public string NarrowStateName
        {
            get { return (string) GetValue(NarrowStateNameProperty); }
            set { SetValue(NarrowStateNameProperty, value); }
        }

        public int NarrowWidth
        {
            get { return (int) GetValue(NarrowWidthProperty); }
            set { SetValue(NarrowWidthProperty, value); }
        }

        public bool Transitions
        {
            get { return (bool) GetValue(TransitionsProperty); }
            set { SetValue(TransitionsProperty, value); }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public DependencyObject AssociatedObject { get; set; }

        public void Attach(DependencyObject associatedObject)
        {
            AssociatedObject = associatedObject;
            Window.Current.SizeChanged += Current_SizeChanged;
            Window.Current.Activated += Current_Activated;
        }

        public void Detach()
        {
            Window.Current.SizeChanged -= Current_SizeChanged;
            Window.Current.Activated -= Current_Activated;
        }

        private void Current_Activated(object sender, WindowActivatedEventArgs e)
        {
            UpdateOrientation();
        }

        private void Current_SizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            UpdateOrientation();
        }

        private void UpdateOrientation()
        {
            Control control = VisualStateUtilities.FindNearestStatefulControl(AssociatedObject as FrameworkElement);
            if (control == null)
            {
                Debugger.Break();
                return;
            }

            if (Window.Current.Bounds.Width <= NarrowWidth)
            {
                // narrow
                if (!string.IsNullOrEmpty(NarrowStateName))
                    VisualStateManager.GoToState(control, NarrowStateName, Transitions);
            }
            else
            {
                switch (ApplicationView.GetForCurrentView().Orientation)
                {
                        // landscape
                    case ApplicationViewOrientation.Landscape:
                        if (!string.IsNullOrEmpty(LandscapeStateName))
                            VisualStateManager.GoToState(control, LandscapeStateName, Transitions);
                        break;
                        // portrait
                    case ApplicationViewOrientation.Portrait:
                        if (!string.IsNullOrEmpty(PortraitStateName))
                            VisualStateManager.GoToState(control, PortraitStateName, Transitions);
                        break;
                }
            }
        }
    }
}