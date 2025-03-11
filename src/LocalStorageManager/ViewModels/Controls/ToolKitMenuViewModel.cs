using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LocalStorageManager.Models;
using LocalStorageManager.PluginCore.Controls.Implementations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LocalStorageManager.ViewModels.Controls
{
    public class ToolKitMenuViewModel : ObservableObject
    {
        public ObservableCollection<PluginItemModel> PluginMenuItemControls { get; set; }
        public ICommand SelectMenuItemCommand { get; }
        public ToolKitMenuViewModel()
        {
            PluginMenuItemControls = App.PluginItemControls;
            SelectMenuItemCommand = new RelayCommand<int>(ExecuteSelectMenuItemCommand);

        }
        private void ExecuteSelectMenuItemCommand(int parameter)
        {
            App.CurrentPlugin = parameter;
        }
    }
}
