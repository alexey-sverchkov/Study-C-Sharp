using Labs.FileStorage.Console.src;
using System;
using System.IO;

namespace Labs.FileStorage.Console.CommandLineParsing.Commands
{
    class FileRemoveCommand : ICommand
    {
        public String FileName { get; set; }

        public void Run()
        {
            FileInfo file = new FileInfo("./" + FileName);
            ApplicationContext.FileStorage.Remove(file);
            System.Console.WriteLine($"the file {FileName} has been removed");
        }
    }
}
