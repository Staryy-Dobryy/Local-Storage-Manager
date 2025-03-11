using LocalStorageManager.PluginCore.Controls;
using LocalStorageManager.PluginCore.Controls.Implementations;
using LocalStorageManager.PluginCore.Controls.Interfaces;
using LocalStorageManager.PluginCore.Core.Interfaces;
using LocalStorageManager.PluginCore.Exceptions;
using LocalStorageManager.PluginCore.Tools;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LocalStorageManager.PluginCore.Core.Implementations
{
    public abstract class LocalStorageManagerPlugin<TMenuItemControl, TButtonsControl, TActionControl> : ILoadablePlugin<TMenuItemControl, TButtonsControl, TActionControl>, IUsefulPlugin, IExtendablePlugin
        where TMenuItemControl : ToolKitMenuItemControl, new()
        where TButtonsControl : ToolKitMenuButtonsControl, new()
        where TActionControl : ToolKitActionControl, new()
    {
        public string PluginIconPath { get; set; }
        public delegate void PluginLoad(string pluginName);
        private event PluginLoad? OnPluginLoad;

        public virtual void Load()
        {
            OnPluginLoad += PluginLoadHandler.OnPluginLoaded;
        }
        public virtual void LoadExtensions(IServiceCollection services)
        {

        }
        public void InitControls(IServiceCollection services)
        {
            services.AddSingleton(typeof(TMenuItemControl));
            services.AddSingleton(typeof(TButtonsControl));
            services.AddSingleton(typeof(TActionControl));

            OnPluginLoad?.Invoke(this.GetType().Name);
        }

        public TControl? GetControl<TControl>(IServiceProvider serviceProvider) where TControl : class, IPluginCoreControl
        {
            switch (typeof(TControl))
            {
                case Type controlType when controlType.IsAssignableFrom(typeof(TMenuItemControl)):
                    return serviceProvider.GetService<TMenuItemControl>() as TControl;

                case Type controlType when controlType.IsAssignableFrom(typeof(TButtonsControl)):
                    return serviceProvider.GetService<TButtonsControl>() as TControl;

                case Type controlType when controlType.IsAssignableFrom(typeof(TActionControl)):
                    return serviceProvider.GetService<TActionControl>() as TControl;

            }

            throw new ServiceNotFoundException(typeof(TControl), serviceProvider);
        }
    }
}
