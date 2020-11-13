using System;

namespace Labs.FileStorage.Console.CommandLineParsing.Commands
{
    class UserInfoCommand : ICommand
    {
        public String   Login { get; set; }
        public DateTime CreationDate { get; set; }
        public ulong    StorageUsed { get; set; }

        public void Run()
        {
            System.Console.WriteLine("login: " + Login);
            System.Console.WriteLine("creation Date: " + CreationDate.ToString("d")); // format: yyyy-mm-dd
            System.Console.WriteLine("storage used: " + StorageUsed + " bytes");
        }
    }
}
