using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;

namespace lab_02.src
{
    public sealed class CommandLineOptions
    {
        [Option('l', "login", Required = true, HelpText = "Login of user")]
        public String Username { get; set; }

        [Option('p', "password", Required = true, HelpText = "Password of user")]
        public String Password { get; set; }
    }
}
