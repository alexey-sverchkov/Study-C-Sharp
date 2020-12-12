using System;
using System.IO;

namespace Labs.FileStorage.Console.Domain.Files
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