using System;
using System.Collections.Generic;
using System.Text;

namespace lab_02.src.CommandLineParsing
{
    class UserInfoCommand : ICommand
    {
        public String   Login { get; set; }
        public DateTime CreationDate { get; set; }
        public ulong    StorageUsed { get; set; }

        public void Run()
        {
            Console.WriteLine("login: " + Login);
            Console.WriteLine("creation Date: " + CreationDate.ToString("d")); // format: yyyy-mm-dd
            Console.WriteLine("storage used: " + StorageUsed + " bytes");
        }
    }
}
