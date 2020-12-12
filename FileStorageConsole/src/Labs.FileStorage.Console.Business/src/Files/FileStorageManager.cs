using System;
using Labs.FileStorage.Console.Domain.Users;

namespace Labs.FileStorage.Console.Business.Files
{
    public class FileStorageManager
    {
        /* Properties and fields  */
        public Data.Files.FileStorage FileStorage { get; private set; }

        /* Constructors */
        public FileStorageManager()
        { }

        /* Methods */
        public void CreateFileStorageInstance(User user, String usersDirectoryPath, String databasePath)
        {
            FileStorage = new Data.Files.FileStorage(user, usersDirectoryPath, databasePath);
            ApplicationContext.FileStorage = FileStorage;
        }


    }
}
