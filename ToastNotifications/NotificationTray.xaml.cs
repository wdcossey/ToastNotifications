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
        public static readonly DependencyProperty NotificationsSourceProperty = DependencyProperty.Register(nameof(NotificationsSource), typeof(NotificationsSource), typeof(NotificationTray), new PropertyMetadata(new NotificationsSource()));

        public static readonly DependencyProperty PopupFlowDirectionProperty = DependencyProperty.Register(nameof(PopupFlowDirection), typeof(PopupFlowDirection), typeof(NotificationTray), new FrameworkPropertyMetadata(default(PopupFlowDirection)));

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

        public PopupFlowDirection PopupFlowDirection
        {
            get { return (PopupFlowDirection) GetValue(PopupFlowDirectionProperty); }
            set { SetValue(PopupFlowDirectionProperty, value); }
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
        }

        private void Notification_OnNotificationClosed(object sender, RoutedEventArgs e)
        {
            var control = sender as NotificationControl;

            if (control == null)
                return;

            // Check for null just in case binding was lost in between
            NotificationsSource?.Hide(control.Notification.Id);

            //UpdateBounds();
        }
    }
}
