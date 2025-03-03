using LocalStorageManager.PluginLoader.Services.Interfaces;
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
        public List<UserControl> LoadPlugins(string pluginsFolder)
        {
            var userControls = new List<UserControl>();
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

                        var controlTypes = assembly.GetTypes()
                            .Where(t => typeof(UserControl).IsAssignableFrom(t) && !t.IsAbstract);

                        foreach (var controlType in controlTypes)
                        {
                            // Создаём экземпляр пользовательского элемента управления
                            var control = CreateControlInstance(controlType);

                            if (control != null)
                            {
                                userControls.Add(control);
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
        private UserControl? CreateControlInstance(Type controlType)
        {
            try
            {
                // Создаём экземпляр класса
                var control = (UserControl)Activator.CreateInstance(controlType);

                // Инициализируем компонент (загружаем XAML)
                InitializeControl(control);

                return control;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при создании экземпляра {controlType.FullName}: {ex.Message}");
                return null;
            }
        }

        private void InitializeControl(UserControl control)
        {
            var initializeMethod = control.GetType().GetMethod("InitializeComponent", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (initializeMethod != null)
            {
                object[] _params = [true];
                initializeMethod.Invoke(control, _params);
            }
            else
            {
                // Если метод InitializeComponent не найден, пытаемся загрузить XAML напрямую
                AvaloniaXamlLoader.Load(control);
            }
        }
    }
}
