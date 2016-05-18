using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace ToastNotifications
{
    /// <summary>
    /// Interaction logic for NotificationTray.xaml
    /// </summary>
    public partial class NotificationTray : UserControl
    {
        public static readonly DependencyProperty NotificationsSourceProperty = DependencyProperty.Register("NotificationsSource", typeof(NotificationsSource), typeof(NotificationTray), new PropertyMetadata(new NotificationsSource()));

        private Window _window;

        public NotificationTray()
        {
            InitializeComponent();

            if (DesignerProperties.GetIsInDesignMode(this))
            {
                Popup.IsOpen = false;
            }
            else
            {
                Loaded += OnLoaded;
                Unloaded += OnUnloaded;
            }
        }

        public NotificationsSource NotificationsSource
        {
            get { return (NotificationsSource) GetValue(NotificationsSourceProperty); }
            set { SetValue(NotificationsSourceProperty, value); }
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            _window = Window.GetWindow(this);
            
            _window.SizeChanged += WindowOnSizeChanged;
            _window.LocationChanged += WindowOnLocationChanged;
            _window.StateChanged += WindowOnStateChanged;
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            _window.SizeChanged -= WindowOnSizeChanged;
            _window.LocationChanged -= WindowOnLocationChanged;
            _window.StateChanged -= WindowOnStateChanged;
        }

        private void WindowOnStateChanged(object sender, EventArgs eventArgs)
        {
            UpdateBounds();
        }

        private void WindowOnLocationChanged(object sender, EventArgs eventArgs)
        {
            UpdateBounds();
        }

        private void WindowOnSizeChanged(object sender, SizeChangedEventArgs sizeChangedEventArgs)
        {
            UpdateBounds();
        }

        private void Notification_OnNotificationClosed(object sender, RoutedEventArgs e)
        {
            var control = sender as NotificationControl;

            if (control == null)
                return;

            // Check for null just in case binding was lost in between
            this.NotificationsSource?.Hide(control.Notification.Id);

            UpdateBounds();
        }

        private void UpdateBounds()
        {
            Popup.HorizontalOffset += 1;
            Popup.HorizontalOffset -= 1;
        }
    }
}
