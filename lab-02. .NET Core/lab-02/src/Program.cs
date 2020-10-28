using CommandLine;
using lab_02.src;
using System;
using System.Collections;
using System.Collections.Generic;

namespace lab_02
{
    class Program
    {
        static void Main(string[] args)
        {                       
            CommandLine.Parser.Default.ParseArguments<CommandLineOptions>(args)
                .WithParsed(RunOptions)
                .WithNotParsed(HandleParseError);            
        }

        static void RunOptions(CommandLineOptions opts)
        {
            String username = opts.Username;
            String password = opts.Password;

            Console.WriteLine($"username: {username}");
            Console.WriteLine($"password: {password}");
        }

        static void HandleParseError(IEnumerable<Error> errors)
        {   
            // basic handling errors 
        }
    }
}
