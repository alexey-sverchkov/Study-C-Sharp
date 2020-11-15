using Labs.FileStorage.Console.Files;
using Labs.FileStorage.Console.src;
using System;
using System.Collections.Generic;
using System.IO;

namespace Labs.FileStorage.Console.CommandLineParsing.Commands
{
    class FileInfoCommand : ICommand
    {
        public String FileName { get; set; }

        public void Run()
        {
            FileInfo file = new FileInfo(FileName);
            FileMetainformation fm = ApplicationContext.FileStorage.GetFileMetainformationFrom(file);
            fm.Print('f');
        }
    }
}
