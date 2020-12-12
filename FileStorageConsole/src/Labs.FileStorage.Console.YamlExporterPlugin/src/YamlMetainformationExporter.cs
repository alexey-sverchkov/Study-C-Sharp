using Labs.FileStorage.Console.Business.Files.Export;
using System;
using System.Collections.Generic;
using System.IO;
using Labs.FileStorage.Console.Domain.Files;

namespace Labs.FileStorage.Console.Business.Plugins.Export.YamlExporterPlugin
{
    public class YamlMetainformationExporter : MetainformationExporter
    {
        public YamlMetainformationExporter(ICollection<FileMetainformation> filesMetainformation)
            : base(filesMetainformation)
        {
            Format = ExportFormat.Yaml;
        }

        public override void Export(String filename)
        {
            // open file stream
            using (StreamWriter file = File.CreateText(filename))
            {
                var serializer = new YamlDotNet.Serialization.Serializer();
                serializer.Serialize(file, FilesMetainformation);
            }
        }
    }
}
