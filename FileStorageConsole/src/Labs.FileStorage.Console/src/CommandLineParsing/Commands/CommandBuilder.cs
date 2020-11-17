using System;
using Labs.FileStorage.Console.CommandLineParsing.Commands.FileCommands;
using Labs.FileStorage.Console.CommandLineParsing.Commands.UserCommands;

namespace Labs.FileStorage.Console.CommandLineParsing.Commands
{    
    public class CommandBuilder
    {
        /* Properties */
        public CommandType TypeOfCommand { get; set; }
        public string TypeOfCommandName => TypeOfCommand.ToString().ToLower();
        public String Name { get; set; }          


        /* Methods */        

        public static CommandBuilder BuildWithType(CommandType typeOfCommand)
        {
            return new CommandBuilder
            {
                TypeOfCommand = typeOfCommand,
                Name = string.Empty,                
            };
        }        
       

        public virtual bool TryBuild(String[] args, out ICommand result)
        {
            result = null;
            // pattern can't match an empty string
            if (args.Length == 0)
            {
                return false;
            }

            // pattern can't match some other command
            if (!args[0].ToLower().Equals(TypeOfCommandName))
            {
                return false;
            }

            Name = args[1];                          
            
            // for command with certain type and name try to find corresponding class                                  
            switch($"{TypeOfCommandName} {Name}")
            {
                case ("user info"):
                    {
                        result = new UserInfoCommand();
                        break;
                    }
                case ("file upload"):
                    {
                        result = new FileUploadCommand
                        {
                            PathToFile = args[2]
                        };
                        break;
                    }
                case ("file remove"):
                    {
                        // Review: Do the same as in previous `file upload` case
                        result = new FileRemoveCommand();
                        ((FileRemoveCommand)result).FileName = args[2];
                        break;
                    }
                case ("file info"):
                    {
                        // Review: Do the same as in previous `file upload` case
                        result = new FileInfoCommand();
                        ((FileInfoCommand)result).FileName = args[2];
                        break;
                    }
                case ("file move"):
                    {
                        // Review: Do the same as in previous `file upload` case
                        result = new FileMoveCommand();
                        ((FileMoveCommand)result).SourceFileName = args[2];
                        ((FileMoveCommand)result).DestinationFileName = args[3];
                        break;
                    }
                case ("file download"):
                    {
                        // Review: Do the same as in previous `file upload` case
                        result = new FileDownloadCommand();
                        ((FileDownloadCommand)result).FileName = args[2];
                        ((FileDownloadCommand)result).DestinationPath = args[3];
                        break;
                    }
                default:
                    {
                        break;
                    }
            }                        
            
            // class not found
            if (result == null)
            {
                return false;
            }                        

            return true;
        }

        public virtual ICommand Build(String[] args)
        {
            if (TryBuild(args, out var result))
            {
                return result;
            }

            throw new FormatException();
        }
    }
}
