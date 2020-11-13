using System;
﻿using ByteSizeLib;
using Labs.FileStorage.Console.Users;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace Labs.FileStorage.Console.Files
{
    public class FileStorage
    {
        public static readonly ByteSize MAX_FILE_SIZE;     // max file size in bytes
        public static readonly ByteSize STORAGE_CAPACITY;  // total capacity of user storage

        /* Properties and Fields */
        private readonly HashSet<ExtendedFileInfo> files = new HashSet<ExtendedFileInfo>();

        /* Constructors */

        static FileStorage()
        {
            String maxFileSizeStr     = ConfigurationManager.AppSettings["storageMaxFileSize"];
            String storageCapacityStr = ConfigurationManager.AppSettings["storageCapacity"];
            MAX_FILE_SIZE = ByteSize.Parse(maxFileSizeStr);            
            STORAGE_CAPACITY = ByteSize.Parse(storageCapacityStr);            
        }

        public FileStorage(User user, String usersDirectoryPath, String databaseLocation)
        {
            DirectoryInfo   directoryInfo = new DirectoryInfo(usersDirectoryPath);
            DirectoryInfo[] subDirectories = directoryInfo.GetDirectories();

            bool isUserDirectoryExists = false; // user folder doesn't exist 
            foreach (DirectoryInfo currentSubDirectory in subDirectories)
            {
                if (currentSubDirectory.Name.Equals(user.Login))
                {
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
