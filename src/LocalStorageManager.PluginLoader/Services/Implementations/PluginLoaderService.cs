using LocalStorageManager.PluginCore.Controls.Implementations;
using LocalStorageManager.PluginCore.Controls.Interfaces;
using LocalStorageManager.PluginCore.Core.Implementations;
using LocalStorageManager.PluginCore.Core.Interfaces;
using LocalStorageManager.PluginLoader.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LocalStorageManager.PluginLoader.Services.Implementations
{
    public class PluginLoaderService : IPluginLoaderService
    {
        public List<IUsefulPlugin> LoadPlugins(string pluginsFolder, IServiceCollection services)
        {
            var userControls = new List<IUsefulPlugin>();
            try
            {
                // Получаем все файлы плагинов
                var pluginFiles = Directory.GetFiles(pluginsFolder, "*.dll");
                foreach (var pluginFile in pluginFiles)
                {
                    try
                    {
                        // Загружаем сборку плагина
                        var assembly = Assembly.LoadFrom(pluginFile);
                        // Находим все типы, наследующиеся от UserControl
                        // Добавь сборку в список AssemblyDescriptor

                        var pluginTypes = assembly.GetTypes()
                            .Where(t => IsInheritedFromLocalStorageManagerPlugin(t) && !t.IsAbstract);

                        var f = pluginTypes.Count();
                        foreach (var pluginType in pluginTypes)
                        {
                            // Создаём экземпляр пользовательского элемента управления
                            var pluginInstance = CreateControlInstance(pluginType);
                            pluginInstance.Load();
                            pluginInstance.InitControls(services);
                            pluginInstance.LoadExtensions(services);
                            if (pluginInstance != null)
                            {
                                userControls.Add(pluginInstance as IUsefulPlugin);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка при загрузке плагина {pluginFile}: {ex.Message}");
                    }
                }
            }
            catch (Exception)
            {
                Directory.CreateDirectory(pluginsFolder);
                throw;
            }
            return userControls;
        }
        private ILoadablePlugin<ToolKitMenuItemControl, ToolKitMenuButtonsControl, ToolKitActionControl> CreateControlInstance(Type controlType)
        {
            try
            {
                // Создаём экземпляр класса
                var control = (ILoadablePlugin<ToolKitMenuItemControl, ToolKitMenuButtonsControl, ToolKitActionControl>)Activator.CreateInstance(controlType);


                return control;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при создании экземпляра {controlType.FullName}: {ex.Message}");
                return null;
            }
        }
        public bool IsInheritedFromLocalStorageManagerPlugin(Type typeToCheck)
        {
            Type? baseType = typeToCheck.BaseType;
            while (baseType != null)
            {
                if (baseType.IsGenericType &&
                    baseType.GetGenericTypeDefinition() == typeof(LocalStorageManagerPlugin<,,>))
                {
                    return true;
                }
                baseType = baseType.BaseType;
            }
            return false;
        }
    }
}
