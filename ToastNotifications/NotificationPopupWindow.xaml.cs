using System;
using System.Windows;

namespace ToastNotifications
{
    /// <summary>
    /// Interaction logic for NotificationPopup.xaml
    /// </summary>
    public partial class NotificationPopupWindow : Window
    {
        #region private fields

        private FrameworkElement _attachedElement;

        #endregion private fields

        #region dependency properties

        public static readonly DependencyProperty PopupFlowDirectionProperty = DependencyProperty.Register(nameof(PopupFlowDirection), typeof(PopupFlowDirection), typeof(NotificationPopupWindow), new PropertyMetadata(default(PopupFlowDirection)));

        public PopupFlowDirection PopupFlowDirection
        {
            get { return (PopupFlowDirection)GetValue(PopupFlowDirectionProperty); }
            set { SetValue(PopupFlowDirectionProperty, value); }
        }

        public static readonly DependencyProperty PopupContentProperty = DependencyProperty.Register(
            nameof(PopupContent), typeof(FrameworkElement), typeof(NotificationPopupWindow), new PropertyMetadata(default(FrameworkElement)));

        public FrameworkElement PopupContent
        {
            get { return (FrameworkElement)GetValue(PopupContentProperty); }
            set { SetValue(PopupContentProperty, value); }
        }

        #endregion dependency properties

        public NotificationPopupWindow(FrameworkElement attachedElemnt)
        {
            InitializeComponent();
            SetProperties(attachedElemnt);

            Loaded += OnLoaded;
            Unloaded += OnUnloaded;
        }

        #region init
        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            BindEvents();
        }

        private void OnUnloaded(object sender, RoutedEventArgs routedEventArgs)
        {
            UnbindEvents();
        }

        private void BindEvents()
        {
            Owner.SizeChanged += OwnerOnSizeChanged;
            Owner.LocationChanged += OwnerOnLocationChanged;
            Owner.Loaded += OwnerOnLoaded;
            Owner.ContentRendered += OwnerOnContentRendered;

            _attachedElement.LayoutUpdated += AttachedElementOnLayoutUpdated;
            _attachedElement.SizeChanged += AttachedElementOnSizeChanged;
        }

        private void UnbindEvents()
        {
            Owner.SizeChanged -= OwnerOnSizeChanged;
            Owner.LocationChanged -= OwnerOnLocationChanged;
            Owner.Loaded -= OwnerOnLoaded;
            Owner.ContentRendered -= OwnerOnContentRendered;

            _attachedElement.LayoutUpdated -= AttachedElementOnLayoutUpdated;
            _attachedElement.SizeChanged -= AttachedElementOnSizeChanged;
        }

        #endregion init

        #region event handlers
        private void OwnerOnSizeChanged(object sender, SizeChangedEventArgs sizeChangedEventArgs)
        {
            UpdateBounds();
        }

        private void OwnerOnLocationChanged(object sender, EventArgs eventArgs)
        {
            UpdateBounds();
        }

        private void OwnerOnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            UpdateBounds();
        }

        private void AttachedElementOnLayoutUpdated(object sender, EventArgs eventArgs)
        {
            UpdateBounds();
        }

        private void AttachedElementOnSizeChanged(object sender, SizeChangedEventArgs sizeChangedEventArgs)
        {
            UpdateBounds();
        }

        private void OwnerOnContentRendered(object sender, EventArgs eventArgs)
        {
            UpdateBounds();
        }

        #endregion event handlers

        private void SetProperties(FrameworkElement attachedElemnt)
        {
            Owner = GetWindow(attachedElemnt);
            _attachedElement = attachedElemnt;
        }

        private void UpdateBounds()
        {
            var location = _attachedElement.PointToScreen(new Point(0, 0));


            switch (PopupFlowDirection)
            {
                case PopupFlowDirection.LeftUp:
                    {
                        Left = location.X - Width;
                        Top = location.Y - Height;
                    }
                    break;
                case PopupFlowDirection.LeftDown:
                    {
                        Left = location.X - Width;
                        Top = location.Y;
                    }
                    break;
                case PopupFlowDirection.RightUp:
                    {
                        Left = location.X;
                        Top = location.Y - Height;
                    }
                    break;
                case PopupFlowDirection.RightDown:
                    {
                        Left = location.X;
                        Top = location.Y;
                    }
                    break;
            }
        }
    }
}
