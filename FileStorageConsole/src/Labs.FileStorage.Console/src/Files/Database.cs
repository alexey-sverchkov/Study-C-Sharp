using System;
using System.Collections.Generic;

namespace Labs.FileStorage.Console.Files
{
    public class Database
    {
        /* Properties and fields */
        public String Path { get; set; }

        public Database()
        {
            // ctor
        }

        /* Methods */
        public void Update()
        {
            FileManager fm = new FileManager();
            fm.WriteMetainformationToFile(ApplicationContext.FileStorage.GetFilesMetainformation(), ApplicationContext.Database.Path);
        }

        // get all files metainformation from database
        public HashSet<FileMetainformation> GetFilesMetainformation()
        {
            FileManager fm = new FileManager();
            HashSet<FileMetainformation> collection = (HashSet<FileMetainformation>)fm.GetMetainformationFromFile(Path);
            return collection;
        }
    }
}
