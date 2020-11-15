using System;
using System.Configuration;
using System.IO;
using Labs.FileStorage.Console.CommandLineParsing.Commands;
using Labs.FileStorage.Console.CommandLineParsing.Commands.Exceptions;
using Labs.FileStorage.Console.CommandLineParsing.InitialProgramArguments;
using Labs.FileStorage.Console.src;
using Labs.FileStorage.Console.src.CommandLineParsing.Commands;
using Labs.FileStorage.Console.Users;
using Microsoft.Extensions.Configuration;

namespace Labs.FileStorage.Console
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
                System.Console.WriteLine($"Error: User {parsedUsername} is not found!");
                return;
            }

            if (!authenticator.IsPasswordCorrect(parsedUsername, parsedPassword))
            {
                System.Console.WriteLine($"Error: Input password of user: {parsedUsername} is not correct!");
                return;
            }

            // create user
            User user = new User(configUsername, configPassword, DateTime.Parse(configCreationDate));
            ApplicationContext.User = user;
            System.Console.WriteLine("Successfully logged in!");


            // get path of database and read all metainformation from database file
            String pathOfDatabase = ConfigurationManager.AppSettings["databaseLocation"];

            // create Database
            Files.Database database = new Files.Database() { Path = pathOfDatabase };
            ApplicationContext.Database = database;
         

            Files.FileStorage fileStorage = null;
            try
            {
                // create file storage
                fileStorage = new Files.FileStorage(user, configUsersDirectoryPath, pathOfDatabase);
                ApplicationContext.FileStorage = fileStorage;
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return;
            }                    

            // program loop
            String currentCommand = null;
            while(!(currentCommand = System.Console.ReadLine()).Equals("exit"))
            {
                String[] parameters = currentCommand.Split(" ");
                switch (parameters[0])
                {
                    case ("User"):
                        {                           
                            try
                            {                                
                                var commandLinePattern = CommandBuilder.BuildWithType(CommandType.User.ToString());                                                               
                                var command = commandLinePattern.BuildFrom(parameters);                                                               

                                command.Run();
                            }
                            catch(FormatException ex)
                            {
                                System.Console.WriteLine("Command not found!");
                            }
                            catch(Exception ex)
                            {
                                System.Console.WriteLine(ex.Message);
                                System.Console.WriteLine(ex.StackTrace);
                            }

                            break;
                        }
                    case ("File"):
                        {
                            try
                            {
                                var commandLinePattern = CommandBuilder.BuildWithType(CommandType.File.ToString());
                                var command = commandLinePattern.BuildFrom(parameters);

                                command.Run();
                            }
                            catch (FormatException ex)
                            {
                                System.Console.WriteLine("Command not found!");
                            }
                            catch (FileException ex)
                            {
                                System.Console.WriteLine(ex.Message);
                            }
                            catch (Exception ex)
                            {
                                System.Console.WriteLine(ex.Message);
                                System.Console.WriteLine(ex.StackTrace);
                            }

                            break;
                        }
                    default:
                        {
                            System.Console.WriteLine("Command is not found!");
                            break;
                        }
                }
            }
        }                
    }
}
