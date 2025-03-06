using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using LocalStorageManager.PluginCore.Controls.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalStorageManager.PluginCore.Controls.Implementations
{
    public abstract class BasePluginCoreControl : UserControl, IPluginCoreControl
    {
        public void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
