using System;
using System.IO;
using Labs.FileStorage.Console.Domain.Exceptions;
using Labs.FileStorage.Console.Domain.Files;

namespace Labs.FileStorage.Console.Business.CommandLineParsing.Commands.FileCommands
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
                // check file integrity
                FileIntegrityChecker fic = new FileIntegrityChecker();
                if (fic.CalculateMD5(extendedFileInfo.FileContent.FullName).Equals(extendedFileInfo.Metainformation.Hash))
                {
                    File.Copy(extendedFileInfo.FileContent.FullName, $@"{DestinationPath}\{extendedFileInfo.FileContent.Name}");
                    // increase number of downloads of file
                    extendedFileInfo.Metainformation.DownloadsNumber++;
                    // update database
                    ApplicationContext.Database.SyncWith(ApplicationContext.FileStorage);
                    System.Console.WriteLine($"The file {FileName} has been downloaded");
                }
                else
                {
                    throw new FileException($"File {FileName} differs from original, which was uploaded into storage");
                }
            }
            else
            {
                throw new FileException($"File {FileName} already exists in directory {DestinationPath}");
            }
        }
    }
}
