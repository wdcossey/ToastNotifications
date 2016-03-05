# ToastNotifications
Toast notifications for Wpf with MVVM support.

##Demo:

[![demo](http://devcrew.pl/github/toastnotifications/demo.gif)](http://devcrew.pl/github/toastnotifications/demo.gif)

##Usage
###### xaml

```xml
<!- import namespace -->
xmlns:toastNotifications="clr-namespace:ToastNotifications;assembly=ToastNotifications"

<!- add NotificationTray to place in view where notifications should appear and make binding to NotificationsSource in viewmodel -->
<toastNotifications:NotificationTray  NotificationsSource="{Binding NotificationSource}" 
                                      VerticalAlignment="Top" 
                                      HorizontalAlignment="Right" />
```

###### csharp
```csharp
// Create viewmodel for window with property of type NotificationsSource.
// NotificationsSource is used to show nofifications in ToastNotifications control

public class MainViewModel : INotifyPropertyChanged
{
    private NotificationsSource _notificationSource;

    public NotificationsSource NotificationSource
    {
        get { return _notificationSource; }
        set
        {
            _notificationSource = value;
            OnPropertyChanged("NotificationSource");
        }
    }

    public MainViewModel()
    {
        NotificationSource = new NotificationsSource();
    }

    public void ShowInformation(string message)
    {
        NotificationSource.Show(message, NotificationType.Information);
    }

    public void ShowSuccess(string message)
    {
        NotificationSource.Show(message, NotificationType.Success);
    }

    public void ShowWarning(string message)
    {
        NotificationSource.Show(message, NotificationType.Warning);
    }

    public void ShowError(string message)
    {
        NotificationSource.Show(message, NotificationType.Error);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName = null)
    {
        var handler = PropertyChanged;
        handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
```

