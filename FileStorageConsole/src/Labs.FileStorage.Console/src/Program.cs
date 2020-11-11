using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Configuration;
using lab_02.CommandLineParsing;
using lab_02.Files;
using lab_02.Users;

namespace lab_02
{
    class Program
    {
        static void Main(string[] args)
        {
            // get user login and password from cli
            var startOptions = args.ParseCommandLineArgs(); 
            
            // invalid number of parameters
            if (startOptions == null)
            {
                return;
            }

            String parsedUsername = startOptions.Username;
            String parsedPassword = startOptions.Password;


            // get user login and password from appsettings.json file
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("src/appsettings.json", true, true)
                .Build();

            String configUsername           = config["User:Login"];
            String configPassword           = config["User:Password"];
            String configCreationDate       = config["User:Creation Date"];
            String configUsersDirectoryPath = config["Users Directory:Location"];
            Console.WriteLine(configUsersDirectoryPath);


            // validate username and password

            UserAuthenticationManager authenticator = new UserAuthenticationManager();
            authenticator.AddUser(new User(configUsername, configPassword, DateTime.Parse(configCreationDate)));           

            if (!authenticator.IsUserExists(parsedUsername))
            {
                Console.WriteLine($"Error: User {parsedUsername} is not found!");
                return;
            }

            if (!authenticator.IsPasswordCorrect(parsedUsername, parsedPassword))
            {
                Console.WriteLine($"Error: Input password of user: {parsedUsername} is not correct!");
                return;
            }
            

            // create user
            User user = new User(configUsername, configPassword, DateTime.Parse(configCreationDate), configUsersDirectoryPath);
            Console.WriteLine("Successfully logged in!");


            // get path of database and read all metainformation from database file
            String pathOfDatabase = ConfigurationManager.AppSettings["databaseLocation"];

            FileStorage fileStorage = null;
            try
            {
                FilesManager fm = new FilesManager();
                List<FileMetainformation> allFilesMetainformation = (List<FileMetainformation>)fm.GetMetainformationFromFile(pathOfDatabase);
                fileStorage = new FileStorage(allFilesMetainformation); // create file storage
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }                    


            // REVIEW: there also, pls use another class for parsing command line.
            // REVIEW: each command logic should be implemented in separate class, possible with the shared interface
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
