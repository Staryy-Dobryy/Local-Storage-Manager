using CommunityToolkit.Mvvm.ComponentModel;
using LocalStorageManager.PluginCore.Controls.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalStorageManager.ViewModels.Controls
{
    public class ToolKitButtonsMenuViewModel : ObservableObject
    {
        private ToolKitMenuButtonsControl _activePluginButtons;
        public ToolKitMenuButtonsControl ActivePluginButtons
        {
            get => _activePluginButtons;
            set => SetProperty(ref _activePluginButtons, value);
        }
        public ToolKitButtonsMenuViewModel()
        {
            ActivePluginButtons = App.PluginButtonsControls[App.CurrentPlugin];
            App.OnCurrentPluginChange += OnActivePluginButtonsChanged;
        }
        private void OnActivePluginButtonsChanged(int newActive)
        {
            ActivePluginButtons = App.PluginButtonsControls[newActive];
        }
    }
}
