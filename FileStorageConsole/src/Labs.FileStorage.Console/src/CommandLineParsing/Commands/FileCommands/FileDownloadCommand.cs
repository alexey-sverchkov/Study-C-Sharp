﻿using System;
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
            // file does not exists in destination directory            
            if (!File.Exists($@"{DestinationPath}\{FileName}"))
            {                
                File.Copy(extendedFileInfo.FileContent.FullName, $@"{DestinationPath}\{extendedFileInfo.FileContent.Name}");
                System.Console.WriteLine($"The file {FileName} has been downloaded");
            }
            else
            {
                throw new FileException($"File {FileName} already exists in directory {DestinationPath}");
            }
        }
    }
}
