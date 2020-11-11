using System;
using CommandLine;

namespace lab_02.CommandLineParsing
{
    public sealed class InitialCommandLineOptions
    {
        [Option('l', "login", Required = true, HelpText = "Login of user")]
        public String Username { get; set; }

        [Option('p', "password", Required = true, HelpText = "Password of user")]
        public String Password { get; set; }
    }
}
