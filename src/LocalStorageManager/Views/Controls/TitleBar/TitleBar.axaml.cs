using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using LocalStorageManager.ViewModels;
using LocalStorageManager.ViewModels.Controls;

namespace LocalStorageManager.Controls;

public partial class TitleBar : UserControl
{
    public TitleBar()
    {
        InitializeComponent();
        DataContext = new TitleBarViewModel();
    }
}