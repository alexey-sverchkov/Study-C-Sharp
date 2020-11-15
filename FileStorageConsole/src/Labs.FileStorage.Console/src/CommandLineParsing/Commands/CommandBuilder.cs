using System;
using System.Collections.Generic;
using Labs.FileStorage.Console.src.CommandLineParsing;
using Labs.FileStorage.Console.src.CommandLineParsing.Commands;

namespace Labs.FileStorage.Console.CommandLineParsing.Commands
{    
    public class CommandBuilder
    {
        /* Properties */
        public String TypeOfCommand { get; set; }
        public String Name { get; set; }          


        /* Methods */        

        public static CommandBuilder BuildWithType(String typeOfCommand)
        {
            return new CommandBuilder
            {
                TypeOfCommand = typeOfCommand,
                Name = "",                
            };
        }        
       

        public virtual bool TryBuildFrom(String[] args, out ICommand result)
        {
            result = null;
            // pattern can't match an empty string
            if (args.Length == 0)
            {
                return false;
            }

            // pattern can't match some other command
            if (!args[0].Equals(TypeOfCommand))
            {
                return false;
            }

            Name = args[1];                          
            
            // for command with certain type and name try to find corresponding class                                  
            switch(TypeOfCommand + " " + Name)
            {
                case ("User Info"):
                    {
                        result = new UserInfoCommand();
                        break;
                    }
                case ("File Upload"):
                    {
                        result = new FileUploadCommand();
                        ((FileUploadCommand)result).PathToFile = args[2];
                        break;
                    }
                case ("File Remove"):
                    {
                        result = new FileRemoveCommand();
                        ((FileRemoveCommand)result).FileName = args[2];
                        break;
                    }
                case ("File Info"):
                    {
                        result = new FileInfoCommand();
                        ((FileInfoCommand)result).FileName = args[2];
                        break;
                    }
                case ("File Move"):
                    {
                        result = new FileMoveCommand();
                        ((FileMoveCommand)result).SourceFileName = args[2];
                        ((FileMoveCommand)result).DestinationFileName = args[3];
                        break;
                    }
                case ("File Download"):
                    {
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
            if (result == null) return false;                        

            return true;
        }

        public virtual ICommand BuildFrom(String[] args)
        {
            if (TryBuildFrom(args, out var result))
            {
                return result;
            }

            throw new FormatException();
        }
    }
}
