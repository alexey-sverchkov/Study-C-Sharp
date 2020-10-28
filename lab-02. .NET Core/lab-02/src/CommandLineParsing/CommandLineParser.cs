using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;

namespace lab_02.src
{
    public static class CommandLineParser
    {
        public static CommandLineOptions ParseCommandLineArgs(this string[] args)
        {
            var options = new CommandLineOptions();
            var hasCommandLineErrors = false;

            CommandLine.Parser.Default.ParseArguments<CommandLineOptions>(args)
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
