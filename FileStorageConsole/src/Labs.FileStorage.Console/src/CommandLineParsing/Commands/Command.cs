using System;
using System.Collections.Generic;

namespace Labs.FileStorage.Console.CommandLineParsing.Commands
{
    // Review: class should be renamed because it is not inherited from ICommand but named as it is inherited
    // Review: Not sure that we need this class at all, it can be static method of CommandLinePattern
    public static class Command
    {
        // Review: Methods should has Verb in name. e.g. BuildWithType
        public static CommandLinePattern WithType(string type)
        {
            return new CommandLinePattern
            {
                Type = type,
                Name = "",
                Parameters = new List<String>(),                
            };
        }
    }
}
