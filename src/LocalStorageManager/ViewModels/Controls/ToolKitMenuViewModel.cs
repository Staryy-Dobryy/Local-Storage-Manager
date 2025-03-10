using CommunityToolkit.Mvvm.ComponentModel;
using LocalStorageManager.PluginCore.Controls.Implementations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalStorageManager.ViewModels.Controls
{
    public class ToolKitMenuViewModel : ObservableObject
    {
        public ObservableCollection<ToolKitMenuItemControl> PluginMenuItemControls { get; set; } 
        public ToolKitMenuViewModel()
        {
            PluginMenuItemControls = App.PluginItemControls;
        }
    }
}
