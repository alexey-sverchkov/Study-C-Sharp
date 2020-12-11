using System;
using System.IO;
using Labs.FileStorage.Console.Business.Domain.Files;

namespace Labs.FileStorage.Console.Business.CommandLineParsing.Commands.FileCommands
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
