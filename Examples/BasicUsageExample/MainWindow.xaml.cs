using System.Windows;

namespace BasicUsageExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _vm = new MainViewModel();
        }

        private int _count = 0;
        private readonly MainViewModel _vm;

        private void Button_ShowInformationClick(object sender, RoutedEventArgs e)
        {
            _vm.ShowInformation($"{_count++} Information");
        }

        private void Button_ShowSuccessClick(object sender, RoutedEventArgs e)
        {
            _vm.ShowSuccess($"{_count++} Success");
        }

        private void Button_ShowWarningClick(object sender, RoutedEventArgs e)
        {
            _vm.ShowWarning($"{_count++} Warning");
        }

        private void Button_ShowErrorClick(object sender, RoutedEventArgs e)
        {
            _vm.ShowError($"{_count++} Error");
        }
    }
}
