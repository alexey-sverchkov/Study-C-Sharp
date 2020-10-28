using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;

namespace lab_02.src
{
    public static class CommandLineParser
    {
        public static InitialCommandLineOptions ParseCommandLineArgs(this string[] args)
        {
            var options = new InitialCommandLineOptions();
            var hasCommandLineErrors = false;

            CommandLine.Parser.Default.ParseArguments<InitialCommandLineOptions>(args)
                .WithParsed(x =>
                {
                    options.Username = x.Username;
                    options.Password = x.Password;
                })
                .WithNotParsed(_ => hasCommandLineErrors = true);

            if (hasCommandLineErrors)
            {
                return null;
            }

            return options;
        }
    }
}
