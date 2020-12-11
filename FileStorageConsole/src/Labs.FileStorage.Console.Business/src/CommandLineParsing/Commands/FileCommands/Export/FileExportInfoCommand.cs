using System;
using System.Collections.Generic;
using System.Linq;
using Labs.FileStorage.Console.Business.Files.Export;

namespace Labs.FileStorage.Console.Business.CommandLineParsing.Commands.FileCommands.Export
{
    public class FileExportInfoCommand : ICommand
    {
        public void Run()
        {
            IEnumerable<ExportFormat> availableFormats = from format in (ExportFormat[])Enum.GetValues(typeof(ExportFormat))
                                                         // filter only available types
                                                         where (!format.Equals(ExportFormat.NoSpecified) && ExportFormatExtensions.IsAvailable(format))
                                                         select format;

            System.Console.WriteLine("Available export formats:");
            foreach (var availableFormat in availableFormats)
            {
                System.Console.WriteLine($"- {availableFormat}");
            }
        }
    }
}
