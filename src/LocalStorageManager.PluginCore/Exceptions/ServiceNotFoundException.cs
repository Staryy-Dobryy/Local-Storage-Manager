using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalStorageManager.PluginCore.Exceptions
{
    public class ServiceNotFoundException : Exception
    {
        public readonly IServiceProvider ServiceProvider;
        public ServiceNotFoundException(Type type, IServiceProvider serviceProvider) : base($"{type.Name} not found in service provider") 
        {
            ServiceProvider = serviceProvider;
        }
    }
}
