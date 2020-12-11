using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Labs.FileStorage.Console.Business.Files.Export;

namespace Labs.FileStorage.Console.Business.PluginLoaders
{
    public class PluginLoader
    {
        public static List<MetainformationExporter> LoadMetainformationExporters(String directoryPath)
        {
            var pluginsList = new List<MetainformationExporter>();

            // 1. read all the dll files from the 'directoryPath' folder
            String[] files = Directory.GetFiles(directoryPath, "*.dll");

            // 2. read the assembly from files
            foreach(String file in files)
            {
                var context = new AssemblyLoadContext(name: null, isCollectible: true);

                Assembly assembly = context.LoadFromAssemblyPath(Path.Combine(Directory.GetCurrentDirectory(), file));

                // 3. extract all the types that inherit from abstract class MetainformationExporter
                Type[] pluginTypes = assembly.GetTypes().Where(t => typeof(MetainformationExporter).IsAssignableFrom(t) &&
                                                                                    !t.IsAbstract).ToArray();

                foreach(Type pluginType in pluginTypes)
                {
                    // 4. Create an instance from the extracted type
                    var pluginInstance = Activator.CreateInstance(pluginType, ApplicationContext.Database.GetFilesMetainformation())
                                                                                as MetainformationExporter;
                    pluginsList.Add(pluginInstance);
                }

                context.Unload();
            }

            return pluginsList;
        }
    }
}
