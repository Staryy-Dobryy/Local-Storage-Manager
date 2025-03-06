using LocalStorageManager.PluginCore.Core.Implementations;
using LocalStorageManager.PluginCore.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalStorageManager.PluginCore.Tools
{
    internal static class PluginLoadHandler
    {
        internal static void OnPluginLoaded(string pluginName)
        {
            Console.WriteLine(pluginName);
        }
    }
}
