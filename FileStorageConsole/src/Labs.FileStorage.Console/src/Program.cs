using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Configuration;
using lab_02.CommandLineParsing;
using lab_02.Files;
using lab_02.Users;
using lab_02.src.CommandLineParsing;

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
            User user = new User(configUsername, configPassword, DateTime.Parse(configCreationDate));
            Console.WriteLine("Successfully logged in!");


            // get path of database and read all metainformation from database file
            String pathOfDatabase = ConfigurationManager.AppSettings["databaseLocation"];

            FileStorage fileStorage = null;
            try
            {
                // create file storage
                fileStorage = new FileStorage(user, configUsersDirectoryPath, pathOfDatabase);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }                    

            
            // program loop
            String currentCommand = null;
            while(!(currentCommand = Console.ReadLine()).Equals("exit"))
            {
                String[] parameters = currentCommand.Split(" ");
                switch (parameters[0])
                {
                    case ("User"):
                        {                           
                            try
                            {
                                var commandLinePattern = Command.WithType("User");
                                var command = commandLinePattern.Parse(parameters);
                                
                                // command is user info - to get all staff from existing classes
                                if (command.GetType().ToString().Equals("lab_02.src.CommandLineParsing.UserInfoCommand"))
                                {
                                    ((UserInfoCommand)command).Login = user.Login;
                                    ((UserInfoCommand)command).CreationDate = user.CreationDate;
                                    ((UserInfoCommand)command).StorageUsed = fileStorage.GetSize();
                                }

                                command.Run();
                            }
                            catch(FormatException ex)
                            {
                                Console.WriteLine("Command not found!");
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                Console.WriteLine(ex.StackTrace);
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
