using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using LocalStorageManager.PluginCore.Controls.Implementations;
using LocalStorageManager.ViewModels.Controls;

namespace LocalStorageManager.Controls;

public partial class ToolKitButtonsMenu : UserControl
{
    public static readonly StyledProperty<string> ActivePluginButtonsProperty =
    AvaloniaProperty.Register<TitleBar, string>(nameof(ActivePluginButtons));


    public string ActivePluginButtons
    {
        get => GetValue(ActivePluginButtonsProperty);
        set => SetValue(ActivePluginButtonsProperty, value);
    }
    public ToolKitButtonsMenu()
    {
        InitializeComponent();
        DataContext = new ToolKitButtonsMenuViewModel();

        this.Bind(ActivePluginButtonsProperty, new Avalonia.Data.Binding("ActivePluginButtons")
        {
            Mode = Avalonia.Data.BindingMode.TwoWay
        });
    }
}