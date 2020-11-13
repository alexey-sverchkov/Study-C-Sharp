using System;
using CommandLine;

namespace Labs.FileStorage.Console.CommandLineParsing.InitialProgramArguments
{
    public sealed class InitialCommandLineOptions
    {
        [Option('l', "login", Required = true, HelpText = "Login of user")]
        public String Username { get; set; }

        [Option('p', "password", Required = true, HelpText = "Password of user")]
        public String Password { get; set; }
    }
}
