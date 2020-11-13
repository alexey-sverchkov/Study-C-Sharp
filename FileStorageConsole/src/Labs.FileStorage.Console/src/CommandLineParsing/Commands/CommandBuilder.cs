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
        public List<String> Parameters { get; set; }        


        /* Methods */        

        public static CommandBuilder BuildWithType(String typeOfCommand)
        {
            return new CommandBuilder
            {
                TypeOfCommand = typeOfCommand,
                Name = "",
                Parameters = new List<String>(),
            };
        }        


        public CommandBuilder HasParameter(String name)
        {
            Parameters.Add(name);
            return this;
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

            for(int i = 2; i < args.Length; ++i)
            {
                Parameters.Add(args[i]);
            }
            
            // for command with certain type and name try to find corresponding class                      
            var className = "Labs.FileStorage.Console.CommandLineParsing.Commands." + TypeOfCommand + Name + "Command";
            var type = System.Type.GetType(className);
            
            
            // class not found
            if (type == null) return false;

            // create an instance
            result = (ICommand)System.Activator.CreateInstance(type);

            // TODO in future add parsing parameters

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
