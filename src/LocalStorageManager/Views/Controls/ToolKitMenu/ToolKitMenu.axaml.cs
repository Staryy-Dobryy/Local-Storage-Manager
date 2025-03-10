using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using LocalStorageManager.ViewModels.Controls;

namespace LocalStorageManager.Controls;

public partial class ToolKitMenu : UserControl
{
    public ToolKitMenu() : this((ToolKitMenuViewModel)App.Services.GetService(typeof(ToolKitMenuViewModel))) { }
    public ToolKitMenu(ToolKitMenuViewModel viewModel)
    {
        InitializeComponent();

        DataContext = viewModel;
    }
}