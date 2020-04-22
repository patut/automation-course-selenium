using System;
using System.Linq;
using System.Reflection;

namespace Automation.Core.Components
{
    internal static class Utilities
    {
        public static Type GetTypeByName(string type)
        {
            var assemblies = Assembly.GetCallingAssembly()
                .GetReferencedAssemblies()
                .Select(assembly => 
                    Assembly.Load(assembly))
                .ToList();

            return assemblies.SelectMany(i => i.GetTypes())
                .FirstOrDefault(a => 
                    a.FullName.Equals(type, StringComparison.OrdinalIgnoreCase));
        }
    }
}