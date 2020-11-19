using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Labs.FileStorage.Console.Files.Export
{
    public class JsonMetainformationExporter : MetainformationExporter
    {
        public JsonMetainformationExporter(ICollection<FileMetainformation> filesMetainformation) 
            : base(filesMetainformation)
        {
            Format = ExportFormat.Json;
        }

        public override void Export(String filename)
        {
            // open file stream
            using (StreamWriter file = File.CreateText(filename))
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                String result = JsonSerializer.Serialize(FilesMetainformation, typeof(HashSet<FileMetainformation>), options);
                System.Console.WriteLine(result);
                file.Write(result);
            }
        }
    }
}
