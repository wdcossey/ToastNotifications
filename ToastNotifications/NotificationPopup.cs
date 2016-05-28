using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace ToastNotifications
{
    [DefaultProperty("Child")]
    [ContentProperty("Child")]
    public class NotificationPopup : Control
    {
        private NotificationPopupWindow _window;

        static NotificationPopup()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NotificationPopup), new FrameworkPropertyMetadata(typeof(NotificationPopup)));
        }

        public NotificationPopup()
        {
            Loaded += OnLoaded;
            Unloaded += OnUnloaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            _window = new NotificationPopupWindow(this);
            _window.PopupContent = Child;
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            _window = null;
        }

        public static readonly DependencyProperty ChildProperty = DependencyProperty.Register(nameof(Child), typeof(FrameworkElement), typeof(NotificationPopup), new FrameworkPropertyMetadata(default(FrameworkElement), ChildChanged));

        public static readonly DependencyProperty IsOpenProperty = DependencyProperty.Register(nameof(IsOpen), typeof(bool), typeof(NotificationPopup), new FrameworkPropertyMetadata(default(bool), IsOpenChanged));

        public FrameworkElement Child
        {
            get { return (FrameworkElement) GetValue(ChildProperty); }
            set { SetValue(ChildProperty, value); }
        }

        public bool IsOpen
        {
            get { return (bool) GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value); }
        }

        private static void IsOpenChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var popup = dependencyObject as NotificationPopup;
            if (popup == null)
                return;

            if (eventArgs.NewValue == eventArgs.OldValue)
                return;

            bool isOpen = (bool) eventArgs.NewValue;

            if (isOpen)
                popup._window.Show();
            else
                popup._window.Hide();
        }

        private static void ChildChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var popup = dependencyObject as NotificationPopup;
            if (popup == null)
                return;

            if (eventArgs.NewValue == eventArgs.OldValue)
                return;

            FrameworkElement child = eventArgs.NewValue as FrameworkElement;

            if (child == null)
                return;

            if (popup._window == null)
                return;

            popup._window.PopupContent = child;
        }
    }
}
