using System;

namespace Labs.FileStorage.Console.CommandLineParsing.Commands.Exceptions
{
    // Review: exceptions folder should be moved up to src root
    [Serializable]
    public class FileException : Exception
    {
        public FileException() 
        { }

        public FileException(String message)
            : base(message)
        { }

        public FileException(String message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
