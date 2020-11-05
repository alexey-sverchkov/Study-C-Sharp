using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace lab_02.src.Files
{
    public class ExtendedFileInfo
    {
        /* Properties */
        public FileInfo FileContent { get; set; }
        public FileMetainformation Metainformation { get; set; }

        /* Constructors */

        public ExtendedFileInfo(FileInfo fileContent, FileMetainformation metainformation)
        {
            FileContent = fileContent;
            Metainformation = metainformation;
        }

        public override String ToString()
        {
            return $"ExtendedFileInfo [{FileContent.ToString()}, {Metainformation.ToString()}]";
        }


    }
}
