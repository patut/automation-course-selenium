using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Automation.Core.Components
{
    internal static class Utilities
    {
        public static Type GetTypeByName(string type)
        {
            var assemblyFiles = Directory.GetFiles(Environment.CurrentDirectory, "*.dll", SearchOption.AllDirectories);
            
            var assemblies = assemblyFiles.Select(a => Assembly.Load(AssemblyName.GetAssemblyName(a)))
                .ToList();

            return assemblies.SelectMany(i => i.GetTypes())
                .FirstOrDefault(a => 
                    a.FullName.Equals(type, StringComparison.OrdinalIgnoreCase));
        }
    }
}