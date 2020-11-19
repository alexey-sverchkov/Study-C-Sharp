using System;
using System.IO;
using Labs.FileStorage.Console.Files;

namespace Labs.FileStorage.Console.CommandLineParsing.Commands.FileCommands
{
    public class FileUploadCommand : ICommand
    {        
        public String PathToFile { get; set; }

        public void Run()
        {
            FileInfo fileToUpload = new FileInfo(PathToFile);
           
            ApplicationContext.FileStorage.Add(fileToUpload);
            // update database
            ApplicationContext.Database.Update();
            System.Console.WriteLine($"The file {PathToFile} has been uploaded");                             
            FileMetainformation fm = ApplicationContext.FileStorage.GetFileMetainformationFrom(fileToUpload);
            fm.Print('s');
        }
    }
}
