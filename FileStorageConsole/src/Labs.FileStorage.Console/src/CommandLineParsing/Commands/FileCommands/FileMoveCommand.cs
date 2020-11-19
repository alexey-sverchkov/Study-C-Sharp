using System;

namespace Labs.FileStorage.Console.CommandLineParsing.Commands.FileCommands
{
    public class FileMoveCommand : ICommand
    {
        public String SourceFileName { get; set; }        
        public String DestinationFileName { get; set; }

        public void Run()
        {
            ApplicationContext.FileStorage.ChangeFileName(SourceFileName, DestinationFileName);
            // update database
            ApplicationContext.Database.Update();
            System.Console.WriteLine($"The file {SourceFileName} has been moved to {DestinationFileName}");
        }
    }
}
