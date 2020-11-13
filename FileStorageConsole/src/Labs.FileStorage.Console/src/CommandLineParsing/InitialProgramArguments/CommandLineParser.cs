using CommandLine;

namespace Labs.FileStorage.Console.CommandLineParsing.InitialProgramArguments
{
    public static class CommandLineParser
    {
        public static InitialCommandLineOptions ParseCommandLineArgs(this string[] args)
        {
            var options = new InitialCommandLineOptions();
            var hasCommandLineErrors = false;

            Parser.Default.ParseArguments<InitialCommandLineOptions>(args)
                .WithParsed(x =>
                {
                    options.Username = x.Username;
                    options.Password = x.Password;
                })
                .WithNotParsed(_ => hasCommandLineErrors = true);

            return hasCommandLineErrors ? null : options;
        }
    }
}
