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

        public ExtendedFileInfo(FileInfo fileContent, FileMetainformation metainformation)
        {
            //FileContent = fileContent;
            FileContent = new FileInfo($"{ApplicationContext.User.DirectoryPath}\\{fileContent.Name}");
            Metainformation = metainformation;
        }

        public override String ToString()
        {
            return $"ExtendedFileInfo [{FileContent.ToString()}, {Metainformation.ToString()}]";
        }


    }
}