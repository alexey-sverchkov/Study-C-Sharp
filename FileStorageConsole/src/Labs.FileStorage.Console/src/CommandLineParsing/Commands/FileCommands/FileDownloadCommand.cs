using System;
using System.IO;
using Labs.FileStorage.Console.CommandLineParsing.Commands.Exceptions;
using Labs.FileStorage.Console.Files;

namespace Labs.FileStorage.Console.CommandLineParsing.Commands.FileCommands
{
    public class FileDownloadCommand : ICommand
    {
        public String FileName { get; set; }
        public String DestinationPath { get; set; }

        public void Run()
        {
            ExtendedFileInfo extendedFileInfo = ApplicationContext.FileStorage.GetExtendedFile(FileName);
            // Review: use string interpolation. Do not use concatenation where it is not needed.
            // Read: find and read an artival about how string concatenation is working on C#
            // what is better to write + or use something else and when
            // file does not exists in destination directory
            if (!File.Exists(DestinationPath + $@"\{FileName}"))
            {                
                File.Copy(extendedFileInfo.FileContent.FullName, DestinationPath + $@"\{extendedFileInfo.FileContent.Name}");
                System.Console.WriteLine($"The file {FileName} has been downloaded");
            }
            else
            {
                throw new FileException($"File {FileName} already exists in directory {DestinationPath}");
            }
        }
    }
}
