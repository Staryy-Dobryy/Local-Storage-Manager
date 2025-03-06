using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalStorageManager.PluginCore.Core.Interfaces
{
    public interface IExtendablePlugin
    {
        void LoadExtensions(IServiceCollection services);
    }
}
