using System;
using System.Collections.Generic;
using System.Text;

namespace lab_02.src.CommandLineParsing
{
    public static class Command
    {
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
