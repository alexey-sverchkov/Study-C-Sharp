using Labs.FileStorage.Console.Users;
using Labs.FileStorage.Console.Files;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labs.FileStorage.Console.src
{
    public static class ApplicationContext
    {
        public static Users.User         User { get; set; }
        public static Files.FileStorage  FileStorage { get; set; }
        public static Files.Database     Database { get; set; }
    }
}
