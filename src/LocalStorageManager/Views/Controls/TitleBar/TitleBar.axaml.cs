using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using LocalStorageManager.ViewModels;
using LocalStorageManager.ViewModels.Controls;

namespace LocalStorageManager.Controls;

public partial class TitleBar : UserControl
{
    public static readonly StyledProperty<string> TitleProperty =
        AvaloniaProperty.Register<TitleBar, string>(nameof(Title));


    public string Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }
    public TitleBar() : this((TitleBarViewModel)App.Services.GetService(typeof(TitleBarViewModel)))
    {
    }
    public TitleBar(TitleBarViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;

        this.Bind(TitleProperty, new Avalonia.Data.Binding("Title")
        {
            Mode = Avalonia.Data.BindingMode.TwoWay
        });
    }
}