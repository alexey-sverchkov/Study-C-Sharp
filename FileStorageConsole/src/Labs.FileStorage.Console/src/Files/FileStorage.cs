using System;
﻿using ByteSizeLib;
using Labs.FileStorage.Console.Users;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using Labs.FileStorage.Console.src;
using Labs.FileStorage.Console.CommandLineParsing.Commands.Exceptions;

namespace Labs.FileStorage.Console.Files
{
    public class FileStorage
    {
        public static readonly ByteSize MAX_FILE_SIZE;     // max file size in bytes
        public static readonly ByteSize STORAGE_CAPACITY;  // total capacity of user storage

        /* Properties and Fields */
        private readonly Dictionary<String, ExtendedFileInfo> files = new Dictionary<String, ExtendedFileInfo>();
        private readonly User user;                           
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
            this.user = user;
            DirectoryInfo   directoryInfo = new DirectoryInfo(usersDirectoryPath);
            DirectoryInfo[] subDirectories = directoryInfo.GetDirectories();

            bool isUserDirectoryExists = false; // user folder doesn't exist 
            foreach (DirectoryInfo currentSubDirectory in subDirectories)
            {
                if (currentSubDirectory.Name.Equals(user.Login))
                {
                    this.user.DirectoryPath = currentSubDirectory.FullName;
                    isUserDirectoryExists = true;
                    break;
                }
            }

            if (isUserDirectoryExists)
            {
                FileManager fm = new FileManager();
                ICollection<FileMetainformation> filesMetainfo = fm.GetMetainformationFromFile(databaseLocation);
                foreach (FileMetainformation fileMetainfo in filesMetainfo)
                {
                    FileInfo file = new FileInfo(fileMetainfo.Name);
                    this.files.Add(file.Name, new ExtendedFileInfo(file, fileMetainfo));
                }
            }
            else
            {
                // create new directory for user
                DirectoryInfo newUserDirectory = directoryInfo.CreateSubdirectory(user.Login);
                this.user.DirectoryPath = newUserDirectory.FullName;
            }
        }

        /* Methods */
        
        // returns used size of storage
        public ulong GetSize()
        {               
            // pair - <String, ExtendedFileInfo>
            return (ulong)files.Sum(pair => (decimal)pair.Value.Metainformation.SizeInBytes);
        }
        
        public bool Contains(FileInfo file)
        {
            return files.ContainsKey(file.Name);
        }

        public void Add(FileInfo file)
        {
            if (!Contains(file))
            {
                files.Add(file.Name, new ExtendedFileInfo(file, new FileMetainformation(file)));
                File.Create(user.DirectoryPath + "\\" + file.Name);
                ApplicationContext.Database.Update();
            }
            else
            {
                throw new FileException("File already exists in storage!");
            }
        }        

        public void Remove(FileInfo file)
        {
            // file exists in storage
            if (files.ContainsKey(file.Name))
            {
                files.Remove(file.Name);
                File.Delete(user.DirectoryPath + "\\" + file.Name);
                ApplicationContext.Database.Update();
            }
            else
            {
                throw new FileException($"File {file.Name} does not found in the storage");
            }
        }


        public HashSet<ExtendedFileInfo> GetFiles()
        {
            HashSet<ExtendedFileInfo> collection = new HashSet<ExtendedFileInfo>();
            // add only files
            foreach(var pair in files)
            {
                collection.Add(pair.Value);
            }
            return collection;
        }

        public HashSet<FileMetainformation> GetFilesMetainformation()
        {
            HashSet<FileMetainformation> collection = new HashSet<FileMetainformation>();
            // add only filemetainformation of files
            foreach(var pair in files)
            {
                collection.Add(pair.Value.Metainformation);
            }
            return collection;
        }
    }
}
