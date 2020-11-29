using Labs.FileStorage.Console.Exceptions;
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

            if (Format.Equals(ExportFormat.NoSpecified))
            {
                throw new FileException("Error: Unknown format of export");
            }

            if (ExportFormatExtensions.isAvailable(Format))
            {
                if (Format.Equals(ExportFormat.Json))
                {
                    exporter = new JsonMetainformationExporter(ApplicationContext.Database.GetFilesMetainformation());
                }
                // search through all metainformation exporters to get the appropriate one
                foreach (MetainformationExporter item in ApplicationContext.MetainformationExporters)
                {                    
                    if ((Format.Equals(ExportFormat.Xml) && item.GetType().Name.ToLower().StartsWith("xml")) ||
                        (Format.Equals(ExportFormat.Yaml) && item.GetType().Name.ToLower().StartsWith("yaml")))
                    {
                        // copy reference
                        exporter = item;
                        // update all metainformation files
                        exporter.FilesMetainformation = ApplicationContext.Database.GetFilesMetainformation();
                        break;
                    }
                }                

                // TODO: add other formats, when they appear
            }
            else
            {
                throw new FileException($"Error: Format {Format} is unavailable");
            }
           

            if (exporter != null)
            {
                exporter.Export(DestinationPath);
                System.Console.WriteLine($"The meta-information has been exported, path = {DestinationPath}");
            }
        }
    }
}
