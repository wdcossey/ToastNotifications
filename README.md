# ToastNotifications
####Toast notifications for Wpf with MVVM support.
ToastNotifications allows you to show Success, Information, Warning and Error animated notifications, which will disappear after several seconds.

Feel free to modify and use this code with MIT license.

[![Build status](https://ci.appveyor.com/api/projects/status/xk2e7g0nxfh5v92q?svg=true)](https://ci.appveyor.com/project/raflop/toastnotifications)  [![Nuget install](https://img.shields.io/badge/nuget-install-green.svg)](https://www.nuget.org/packages/ToastNotifications/) [![MIT license](https://img.shields.io/badge/mit-license-blue.svg)](https://github.com/raflop/ToastNotifications/blob/master/LICENSE)

##Demo:

[![demo](http://devcrew.pl/github/toastnotifications/demo.gif)](http://devcrew.pl/github/toastnotifications/demo.gif)

## Install via [Nuget Package ToastNotifications](https://www.nuget.org/packages/ToastNotifications/)
```
Install-Package ToastNotifications
```
##Usage
###### xaml

```xml
<!- import namespace -->
xmlns:toast="clr-namespace:ToastNotifications;assembly=ToastNotifications"

<!- add NotificationTray to place in view where notifications should appear and make binding to NotificationsSource in viewmodel -->
<toast:NotificationTray  NotificationsSource="{Binding NotificationSource}"
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

####Configuration
######Flow direction
Set direction in which new notifications will appear. It's relative to notification control position.
Avalaible options are:
* LeftDown  (default)
* RightDown
* LeftUp
* RightUp

```xml
<toast:NotificationTray PopupFlowDirection="LeftDown"  />
```

######Notification source properties

```csharp
public MainViewModel()
{
    NotificationSource = new NotificationsSource
    {
        MaximumNotificationCount = 4,

        NotificationLifeTime = TimeSpan.FromSeconds(3)
    };
}
```

Set MaximumNotificationCount = NotificationsSource.UnlimitedNotifications to allow unlimited number of notifications


##Contributors
Uwy (https://github.com/Uwy)

Andy Li (https://github.com/oneandy)

BrainCrumbz (https://github.com/BrainCrumbz)
