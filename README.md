# ToastNotifications
####Toast notifications for WPF with MVVM support.

ToastNotifications allows you to show Success, Information, Warning and Error animated notifications, which will disappear after several seconds.

Feel free to modify and use this code with MIT license.

[![Build status](https://ci.appveyor.com/api/projects/status/xk2e7g0nxfh5v92q?svg=true)](https://ci.appveyor.com/project/raflop/toastnotifications)  [![Nuget install](https://img.shields.io/badge/nuget-install-green.svg)](https://www.nuget.org/packages/ToastNotifications/) [![MIT license](https://img.shields.io/badge/mit-license-blue.svg)](https://github.com/raflop/ToastNotifications/blob/master/LICENSE)

## Demo

[![demo](http://devcrew.pl/github/toastnotifications/demo.gif)](http://devcrew.pl/github/toastnotifications/demo.gif)

## Installation

Install via [Nuget Package ToastNotifications](https://www.nuget.org/packages/ToastNotifications/)

```
Install-Package ToastNotifications
```

## Usage

### XAML

```xml
<!- import namespace -->
xmlns:toast="clr-namespace:ToastNotifications;assembly=ToastNotifications"

<!- add NotificationTray to place in view where notifications should appear
    and bind to NotificationsSource in viewmodel -->
<toast:NotificationTray NotificationsSource="{Binding NotificationSource}"
                        PopupFlowDirection="RightUp"
                        VerticalAlignment="Top"
                        HorizontalAlignment="Right" />
```

### C&#35;

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

## Configuration

### Flow direction

Set direction in which new notifications will appear. It's relative to notification control position.
Avalaible options are:

* LeftDown  (default)
* RightDown
* LeftUp
* RightUp

```xml
<toast:NotificationTray PopupFlowDirection="LeftDown" />
```

### NotificationSource properties

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

Set `MaximumNotificationCount = NotificationsSource.UnlimitedNotifications` to allow unlimited number of notifications.

Set `NotificationLifeTime = NotificationsSource.NeverEndingNotification` to make notifications opened until user close them.

## Additional informations

### Strongly named assembly
Assembly is strongly named using pfx file. Pfx file stored in repository is used only in development and continues build, and it is not used to produce official nuget, the real one is not public.

Development:
```sha1
Public key (hash algorithm: sha1):
002400000480000094000000060200000024000052534131000400000100010021df04555b3db9
fdba3206cf5129b646a4ea889fa8e605faed25fd735f710c0b8b920b8465e0ca3cdab8e24234a1
f4784cff36fef6ae322a28daa626068c457137b02316af29c9c409cba65c4e5c5ecedf6a5c2c0a
334dc6f7c09dc8b77f5e2d4fc064b283d2814223a41e1bf8faeb037bb6c55179eee23633b87344
bf01e0d0

Public key token is 3a7d2ce07ac615dc
```
Release:
```sha1
Public key (hash algorithm: sha1):
002400000480000094000000060200000024000052534131000400000100010041e364d228daad
36e196e7107c6f462568cafe9b0e625e8afbda5db7725e1cdcca788304083b1a92846b372e002c
06c6f74d9466d93f1fceb6a6b207625a515b3790a9d541edc40b3e2d987ea25cff0e5bb9208046
efc04b7e726d8b56b0d4974071e3db0c1f139888e582c72da6659fbfcf1801fdcdca2449013ae5
d0426dce

Public key token is e89d9d7314a7c797
```

## Contributors

Uwy (https://github.com/Uwy)

Andy Li (https://github.com/oneandy)

BrainCrumbz (https://github.com/BrainCrumbz)
