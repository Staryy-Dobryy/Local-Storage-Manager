using LocalStorageManager.PluginCore.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalStorageManager.PluginLoader.Services.Interfaces
{
    public interface IPluginLoaderService
    {
        List<IUsefulPlugin> LoadPlugins(string pluginsFolder, IServiceCollection services);
    }
}
