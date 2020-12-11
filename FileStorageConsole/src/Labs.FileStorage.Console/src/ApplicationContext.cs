using Labs.FileStorage.Console.Files.Export;
using System.Collections.Generic;

namespace Labs.FileStorage.Console
{
    public static class ApplicationContext
    {
        public static Domain.Users.User               User { get; set; }
        public static Data.Files.FileStorage               FileStorage { get; set; }
        public static Data.Files.Database                  Database { get; set; }
        public static List<MetainformationExporter>   MetainformationExporters { get; set; }
    }
}
