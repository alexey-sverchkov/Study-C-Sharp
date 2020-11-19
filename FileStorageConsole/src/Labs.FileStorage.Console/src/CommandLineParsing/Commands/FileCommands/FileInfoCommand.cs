using System;
using System.IO;
using Labs.FileStorage.Console.Files;

namespace Labs.FileStorage.Console.CommandLineParsing.Commands.FileCommands
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
