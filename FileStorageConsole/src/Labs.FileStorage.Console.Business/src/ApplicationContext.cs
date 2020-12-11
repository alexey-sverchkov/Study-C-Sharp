using System.Collections.Generic;
using Labs.FileStorage.Console.Business.Files.Export;

namespace Labs.FileStorage.Console.Business
{
    public static class ApplicationContext
    {
        public static Domain.Users.User               User { get; set; }
        public static Data.Files.FileStorage          FileStorage { get; set; }
        public static Data.Files.Database             Database { get; set; }
        public static List<MetainformationExporter>   MetainformationExporters { get; set; }
    }
}
