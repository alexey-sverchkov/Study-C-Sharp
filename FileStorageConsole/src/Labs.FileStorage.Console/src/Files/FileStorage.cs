using System;
using ByteSizeLib;
using Labs.FileStorage.Console.Users;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using Labs.FileStorage.Console.CommandLineParsing.Commands.Exceptions;

namespace Labs.FileStorage.Console.Files
{
    public class FileStorage
    {
        private static readonly ByteSize MAX_FILE_SIZE;     // max file size in bytes
        private static readonly ByteSize STORAGE_CAPACITY;  // total capacity of user storage

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
                    FileInfo file = new FileInfo($"{user.DirectoryPath}\\{fileMetainfo.Name}");                    
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
            ByteSize sizeOfFile = new ByteSize(file.Length);
            if (sizeOfFile < MAX_FILE_SIZE)
            {
                if (!Contains(file))
                {
                    files.Add(file.Name, new ExtendedFileInfo(file, new FileMetainformation(file)));                                      
                    File.Copy(file.FullName, user.DirectoryPath + "\\" + file.Name);
                }
                else
                {
                    throw new FileException("File already exists in storage!");
                }
            }
            else
            {
                throw new FileException("File size is too large to upload");
            }
        }        

        public void Remove(FileInfo file)
        {
            // file exists in storage
            if (files.ContainsKey(file.Name))
            {
                files.Remove(file.Name);
                File.Delete(user.DirectoryPath + "\\" + file.Name);                
            }
            else
            {
                throw new FileException($"File {file.Name} does not found in the storage");
            }
        }


        public HashSet<ExtendedFileInfo> GetExtendedFiles()
        {
            HashSet<ExtendedFileInfo> collection = new HashSet<ExtendedFileInfo>();
            // add only files
            foreach(var pair in files)
            {
                collection.Add(pair.Value);
            }
            return collection;
        }

        public ExtendedFileInfo GetExtendedFile(String filename)
        {
            if (files.ContainsKey(filename))
            {
                return files[filename];
            }
            else
            {
                throw new FileException($"File {filename} does not found in the storage");
            }
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

        // return file metainformation if file exists in storage
        public FileMetainformation GetFileMetainformationFrom(FileInfo file)
        {
            if (Contains(file))
            {
                if (files.TryGetValue(file.Name, out ExtendedFileInfo extendedFileInfo))
                {
                    return extendedFileInfo.Metainformation;
                }

                throw new FileException($"Can't get file {file.Name} from storage");
            }

            throw new FileException($"File {file.Name} does not found in the storage");
        }

        public void ChangeFileName(String sourceFileName, String destinationFileName)
        {
            if (Contains(new FileInfo("./" + sourceFileName)))
            {
                ExtendedFileInfo extendedFileInfo = new ExtendedFileInfo(files[sourceFileName].FileContent, files[sourceFileName].Metainformation);                

                // rename binary file in storage and user folder
                extendedFileInfo.FileContent.MoveTo(user.DirectoryPath + "\\" + destinationFileName);
                // update file name in file metainformation                
                extendedFileInfo.Metainformation.Name = destinationFileName;
                // update file extension in file metainformation
                extendedFileInfo.Metainformation.Extension = extendedFileInfo.FileContent.Extension;                

                // remove old entry from collection
                files.Remove(sourceFileName);

                // add new entry to collection
                files.Add(destinationFileName, extendedFileInfo);                                              
            }
            else
            {
                throw new FileException($"File {sourceFileName} does not found in the storage");
            }
        }
    }
}
