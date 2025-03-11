using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using LocalStorageManager.ViewModels.Controls;

namespace LocalStorageManager.Controls;

public partial class ToolKitMenu : UserControl
{
    public ToolKitMenu()
    {
        InitializeComponent();
        DataContext = new ToolKitMenuViewModel();

    }
    public ToolKitMenuViewModel ViewModel => (ToolKitMenuViewModel)DataContext;
}