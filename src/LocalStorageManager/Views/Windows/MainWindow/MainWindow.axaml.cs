using Avalonia.Controls;
using LocalStorageManager.ViewModels.Windows;

namespace LocalStorageManager.Views.Windows
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ExtendClientAreaToDecorationsHint = true;
            ExtendClientAreaChromeHints = Avalonia.Platform.ExtendClientAreaChromeHints.NoChrome;
            ExtendClientAreaTitleBarHeightHint = -1;

            DataContext = new MainWindowViewModel();
        }
    }
}