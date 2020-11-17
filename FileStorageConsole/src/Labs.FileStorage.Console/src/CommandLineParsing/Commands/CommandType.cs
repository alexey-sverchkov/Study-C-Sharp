namespace Labs.FileStorage.Console.CommandLineParsing.Commands
{
    public enum CommandType
    {
        // Review: Better to setup some value for 0 like null or undefined to make sure that we not miss this field to assign
        NoSpecified = 0,
        User = 1,
        File = 2
    }
}
