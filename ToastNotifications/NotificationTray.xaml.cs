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
            this.NotificationsSource?.Hide(control.Notification.Id);

            //UpdateBounds();
        }
    }
}
