using CommandLine;
using lab_02.src;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace lab_02
{
    class Program
    {
        static void Main(string[] args)
        {
            // get user login and password from cli
            var startOptions = CommandLineParser.ParseCommandLineArgs(args); 
            
            // invalid number of parameters
            if (startOptions == null)
            {
                return;
            }

            String parsedUsername = startOptions.Username;
            String parsedPassword = startOptions.Password;


            // get user login and password from appsettings json file
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            String configUsername = config["User:Login"];
            String configPassword = config["User:Password"];
        

            // input login of user is unknown
            if (!parsedUsername.Equals(configUsername))
            {
                Console.WriteLine($"Error: User {parsedUsername} is not found!");
                return;
            }

            if (!parsedPassword.Equals(configPassword))
            {
                Console.WriteLine($"Error: Input password of user: {parsedUsername} is not correct!");
                return;
            }

            Console.WriteLine("Successfully logged in!");

           
        }                
    }
}
