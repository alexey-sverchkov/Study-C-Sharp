using System;
using System.Collections.Generic;
using Labs.FileStorage.Console.Domain.Files;

namespace Labs.FileStorage.Console.Data.Files
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
        public void SyncWith(FileStorage storage)
        {
            FileManager fm = new FileManager();
            fm.WriteMetainformationToFile(storage.GetFilesMetainformation(), Path);
        }

        // get all files metainformation from database
        public HashSet<FileMetainformation> GetFilesMetainformation()
        {
            FileManager fm = new FileManager();
            HashSet<FileMetainformation> collection = new HashSet<FileMetainformation>(fm.GetMetainformationFromFile(Path));
            return collection;
        }
    }
}
