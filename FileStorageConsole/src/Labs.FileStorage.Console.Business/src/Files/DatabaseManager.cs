using System;
using Labs.FileStorage.Console.Data.Files;

namespace Labs.FileStorage.Console.Business.Files
{
    public class DatabaseManager
    {
        /* Properties and fields  */
        public Database Database { get; protected set; }

        /* Constructors */
        public DatabaseManager()
        {}

        /* Methods */

        public void CreateDatabaseInstance(String databasePath)
        {
            Database = new Database
            {
                Path = databasePath
            };
            ApplicationContext.Database = Database;
        }
    }
}
