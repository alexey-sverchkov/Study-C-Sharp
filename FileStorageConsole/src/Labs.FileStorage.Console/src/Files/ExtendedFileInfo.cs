using System;
using System.IO;
using Labs.FileStorage.Console.Domain.Files;

namespace Labs.FileStorage.Console.Files
{
    public class ExtendedFileInfo
    {
        /* Properties */
        public FileInfo FileContent { get; set; }
        public FileMetainformation Metainformation { get; set; }

        /* Constructors */

        public ExtendedFileInfo(String filename, String userDirectoryPath, FileMetainformation metainformation)
        {
            FileContent = new FileInfo($"{userDirectoryPath}\\{filename}");
            Metainformation = metainformation;
        }

        public override String ToString()
        {
            return $"ExtendedFileInfo [{FileContent.ToString()}, {Metainformation.ToString()}]";
        }


    }
}