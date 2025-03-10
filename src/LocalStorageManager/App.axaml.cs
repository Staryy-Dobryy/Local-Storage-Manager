using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using LocalStorageManager.Controls;
using LocalStorageManager.PluginCore.Controls.Implementations;
using LocalStorageManager.PluginCore.Core.Interfaces;
using LocalStorageManager.PluginLoader.Services.Implementations;
using LocalStorageManager.PluginLoader.Services.Interfaces;
using LocalStorageManager.ViewModels;
using LocalStorageManager.ViewModels.Controls;
using LocalStorageManager.ViewModels.Windows;
using LocalStorageManager.Views;
using LocalStorageManager.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace LocalStorageManager
{
    public partial class App : Application
    {
        public static IServiceProvider Services { get; private set; }
        public static ObservableCollection<ToolKitMenuItemControl> PluginItemControls { get; private set; } = new();
        private List<IUsefulPlugin> Plugins { get; set; } = new();
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            Services = serviceCollection.BuildServiceProvider();
            LoadPlugins(serviceCollection);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
                // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
                DisableAvaloniaDataAnnotationValidation();
                var mainWindow = Services.GetRequiredService<MainWindow>();
                desktop.MainWindow = mainWindow;
            }

            base.OnFrameworkInitializationCompleted();
        }

        private void DisableAvaloniaDataAnnotationValidation()
        {
            // Get an array of plugins to remove
            var dataValidationPluginsToRemove =
                BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

            // remove each entry found
            foreach (var plugin in dataValidationPluginsToRemove)
            {
                BindingPlugins.DataValidators.Remove(plugin);
            }
        }
        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(typeof(MainWindow));
            services.AddSingleton(typeof(TitleBarViewModel));
            services.AddSingleton(typeof(TitleBar));
            services.AddSingleton(typeof(ToolKitMenuViewModel));
            services.AddSingleton(typeof(ToolKitMenu));
            services.AddSingleton<IPluginLoaderService, PluginLoaderService>();
        }
        private void LoadPlugins(IServiceCollection serviceCollection)
        {
            var rootDir = Directory.GetCurrentDirectory();
            var pluginsFolder = Path.Combine(rootDir, "Plugins");
   
            var pluginService = Services.GetRequiredService<IPluginLoaderService>();

            Plugins = pluginService.LoadPlugins(pluginsFolder, serviceCollection);
            Services = serviceCollection.BuildServiceProvider();
            var f = Services;

            foreach(var plugin in Plugins)
            {
                PluginItemControls.Add(plugin.GetControl<ToolKitMenuItemControl>(Services));
            }
        }
    }
}