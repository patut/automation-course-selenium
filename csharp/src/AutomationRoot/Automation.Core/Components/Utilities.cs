using System;
using System.Linq;
using System.Reflection;

namespace Automation.Core.Components
{
    internal static class Utilities
    {
        public static Type GetTypeByName(string type)
        {
            const string ASSEMBLY = "Automation.Testing, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
                
            var assemblies = Assembly.Load(ASSEMBLY)
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