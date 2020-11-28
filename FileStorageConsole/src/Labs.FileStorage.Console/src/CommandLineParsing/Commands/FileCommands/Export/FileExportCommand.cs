using Labs.FileStorage.Console.CommandLineParsing.Commands.Exceptions;
using Labs.FileStorage.Console.Files.Export;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labs.FileStorage.Console.CommandLineParsing.Commands.FileCommands.Export
{
    public class FileExportCommand : ICommand
    {
        public String DestinationPath { get; set; }
        public ExportFormat Format { get; set; }

        public void Run()
        {
            // switch-case is not supported cuz of ExportFormat is not a constant :(
            MetainformationExporter exporter = null;
            if (Format.Equals(ExportFormat.Json))
            {
                exporter = new JsonMetainformationExporter(ApplicationContext.Database.GetFilesMetainformation());                
            }
            else if (Format.Equals(ExportFormat.Xml))
            {
                exporter = new XmlMetainformationExporter(ApplicationContext.Database.GetFilesMetainformation());
            }
            else if (Format.Equals(ExportFormat.NoSpecified))
            {
                throw new FileException("Error: Unknown format of export");
            }
            if (exporter != null)
            {
                exporter.Export(DestinationPath);
                System.Console.WriteLine($"The meta-information has been exported, path = {DestinationPath}");
            }
        }
    }
}
