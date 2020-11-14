using System;
using System.Collections.Generic;
using System.Text;

namespace Labs.FileStorage.Console.CommandLineParsing.Commands.Exceptions
{
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
