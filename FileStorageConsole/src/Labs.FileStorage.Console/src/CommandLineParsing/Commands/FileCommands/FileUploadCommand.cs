using Labs.FileStorage.Console.CommandLineParsing.Commands.Exceptions;
using Labs.FileStorage.Console.Files;
using Labs.FileStorage.Console.src;
using System;
using System.IO;

namespace Labs.FileStorage.Console.CommandLineParsing.Commands
{
    public class FileUploadCommand : ICommand
    {        
        public String PathToFile { get; set; }

        public void Run()
        {
            FileInfo fileToUpload = new FileInfo(PathToFile);
           
            ApplicationContext.FileStorage.Add(fileToUpload);
            System.Console.WriteLine($"The file {PathToFile} has been uploaded");
            //fm.PrintInfoAbout(fileToUpload, 's');                    
            FileMetainformation fm = ApplicationContext.FileStorage.GetFileMetainformationFrom(fileToUpload);
            fm.Print('s');
        }
    }
}
