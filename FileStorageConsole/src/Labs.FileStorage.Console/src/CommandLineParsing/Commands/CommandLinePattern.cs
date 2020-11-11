using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace lab_02.src.CommandLineParsing
{
    public class CommandLinePattern
    {
        /* Properties */
        public String Type { get; set; }
        public String Name { get; set; }
        public List<String> Parameters { get; set; }        


        /* Methods */        

        public CommandLinePattern HasParameter(String name)
        {
            Parameters.Add(name);
            return this;
        }


        public virtual bool TryParse(String[] args, out ICommand result)
        {
            result = null;
            // pattern can't match an empty string
            if (args.Length == 0)
                return false;

            // pattern can't match some other command
            if (!args[0].Equals(Type))
                return false;

            Name = args[1];              

            for(int i = 2; i < args.Length; ++i)
            {
                Parameters.Add(args[i]);
            }

            // for command with certain type and name try to find corresponding class
            var className =  "lab_02.src.CommandLineParsing." + Type + Name + "Command";
            var type = System.Type.GetType(className);
            
            // class not found
            if (type == null) return false;

            // create an instance
            result = (ICommand)System.Activator.CreateInstance(type);

            // TODO in future add parsing parameters

            return true;
        }


        public virtual ICommand Parse(String[] args)
        {
            ICommand result;
            if (TryParse(args, out result))
                return result;

            throw new FormatException();
        }

        
    }
}
