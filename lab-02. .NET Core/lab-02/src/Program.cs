using CommandLine;
using lab_02.src;
using lab_02.src.Users;
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

            String configUsername     = config["User:Login"];
            String configPassword     = config["User:Password"];
            String configCreationDate = config["User:Creation Date"];            
        

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

            DateTime creationDate = DateTime.Parse(configCreationDate);

            // create user
            User user = new User(configUsername, configPassword, creationDate);

            Console.WriteLine("Successfully logged in!");
         

            // program loop
            String currentCommand = null;
            while(!(currentCommand = Console.ReadLine()).Equals("exit"))
            {
                String[] parameters = currentCommand.Split(" ");
                switch (parameters[0])
                {
                    case ("user"):
                        {
                            // command: user info
                            if (parameters.Length == 2 && parameters[1].Equals("info"))
                            {
                                Console.WriteLine("login: " + user.Login);
                                Console.WriteLine("creation Date: " + user.CreationDate.ToString("d")); // format: yyyy-mm-dd
                                Console.WriteLine($"storage used: {user.StorageUsed} bytes");
                            }
                            else
                            {
                                Console.WriteLine("Command is not found!");
                            }
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Command is not found!");
                            break;
                        }
                }
            }
           
        }                
    }
}
