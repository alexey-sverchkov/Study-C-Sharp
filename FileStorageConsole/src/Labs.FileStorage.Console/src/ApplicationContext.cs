using Labs.FileStorage.Console.Files.Export;
using Labs.FileStorage.Console.Domain.Users;
using System.Collections.Generic;

namespace Labs.FileStorage.Console
{
    public static class ApplicationContext
    {
        public static Domain.Users.User               User { get; set; }
        public static Files.FileStorage               FileStorage { get; set; }
        public static Files.Database                  Database { get; set; }
        public static List<MetainformationExporter>   MetainformationExporters { get; set; }
    }
}
