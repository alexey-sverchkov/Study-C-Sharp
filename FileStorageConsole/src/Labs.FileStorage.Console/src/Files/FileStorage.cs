using lab_02.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace lab_02.Files
{
    public class FileStorage
    {
        /* Properties and Fields */
        private readonly List<ExtendedFileInfo> files = new List<ExtendedFileInfo>();

        /* Constructors */       

        public FileStorage(User user, String usersDirectoryPath, String databaseLocation)
        {
            DirectoryInfo   directoryInfo = new DirectoryInfo(usersDirectoryPath);
            DirectoryInfo[] subDirectories = directoryInfo.GetDirectories();
            DirectoryInfo userDirectory = null;

            bool isUserDirectoryExists = false; // user folder doesn't exist 
            foreach (DirectoryInfo currentSubDirectory in subDirectories)
            {
                if (currentSubDirectory.Name.Equals(user.Login))
                {
                    userDirectory = currentSubDirectory;
                    isUserDirectoryExists = true;
                    break;
                }
            }

            if (isUserDirectoryExists)
            {                
                FilesManager fm = new FilesManager();
                ICollection<FileMetainformation> filesMetainfo = fm.GetMetainformationFromFile(databaseLocation);
                foreach (FileMetainformation fileMetainfo in filesMetainfo)
                {
                    FileInfo file = new FileInfo(fileMetainfo.Name + "." + fileMetainfo.Extension);
                    this.files.Add(new ExtendedFileInfo(file, fileMetainfo));
                }
            }
            else
            {
                // create new directory for user
                directoryInfo.CreateSubdirectory(user.Login);
            }

        }

        /* Methods */
        
        // returns used size of storage
        public ulong GetSize()
        {            
            return (ulong)files.Sum(extendedFileInfo => (decimal)extendedFileInfo.Metainformation.SizeInBytes);            
        }
    }
}
