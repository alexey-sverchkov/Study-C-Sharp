using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Labs.FileStorage.Console.CommandLineParsing.Commands;
using Labs.FileStorage.Console.CommandLineParsing.InitialProgramArguments;
using Labs.FileStorage.Console.Exceptions;
using Labs.FileStorage.Console.Files.Export;
using Labs.FileStorage.Console.PluginLoaders;
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

            AuthenticationManager authenticator = new AuthenticationManager();
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
            Files.Database database = new Files.Database { Path = pathOfDatabase };
            ApplicationContext.Database = database;


            try
            {
                // create file storage
                Files.FileStorage fileStorage = new Files.FileStorage(user, configUsersDirectoryPath, pathOfDatabase);
                ApplicationContext.FileStorage = fileStorage;
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return;
            }


            // get all metainformation exporters from assemblies
            try
            {
                List<MetainformationExporter> metainformationExporters = PluginLoader.LoadMetainformationExporters("./plugins/export");
                ApplicationContext.MetainformationExporters = metainformationExporters;
                System.Console.WriteLine($"{metainformationExporters.Count} plugin(s) found");

                GC.Collect();
                GC.WaitForPendingFinalizers();               

                /*// uncomment this to see all loaded assemblies
                foreach (System.Reflection.Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
                {
                    System.Console.WriteLine(asm.GetName().Name);
                }*/
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                System.Console.WriteLine(ex.StackTrace);
            }

            // program loop
            String currentCommand;
            while(!(currentCommand = System.Console.ReadLine()).Trim().Equals("exit"))
            {
                String[] parameters = currentCommand.Split(" ");                
                String typeOfCommand = parameters[0];
                try
                {
                    var commandBuilder = CommandBuilder.BuildWithType(typeOfCommand);
                    var command = commandBuilder.Build(parameters);

                    command.Run();
                }
                catch (FormatException ex)
                {
                    System.Console.WriteLine("Command not found!");
                }
                catch (Exception ex) when (ex is FileNotFoundException || ex is FileException)
                {
                    System.Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                    System.Console.WriteLine(ex.StackTrace);
                }
            }
        }                
    }
}
