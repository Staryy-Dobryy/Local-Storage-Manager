using LocalStorageManager.PluginCore.Controls.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalStorageManager.PluginCore.Core.Interfaces
{
    public interface IUsefulPlugin
    {
        // TODO (get A B C)
        string PluginIconPath { get; set; }
        TControl? GetControl<TControl>(IServiceProvider serviceProvider) where TControl : class, IPluginCoreControl;
    }
}
