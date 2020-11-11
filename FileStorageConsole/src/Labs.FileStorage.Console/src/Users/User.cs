﻿using System;
using System.IO;
using System.Linq;

namespace lab_02.Users
{
    public class User
    {
        /* properties and fields  */
        public String   Login { get; set; }
        public String   Password { get; set; }
        public DateTime CreationDate { get; }

        private long storageUsed;
        public  long StorageUsed
        {
            get => storageUsed;
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Warning: size of storage can't be less than zero");
                    storageUsed = 0;
                }
                else
                {
                    storageUsed = value;
                }
            }
        }
        public DirectoryInfo UserDirectory { get; }



        /* constructors */
        public User(string login, string password, DateTime creationDate, String usersDirectoryPath)
        {
            Login = login;
            Password = password;
            CreationDate = creationDate;
                        
            // get used storage
            DirectoryInfo directoryInfo = new DirectoryInfo(usersDirectoryPath);            
            DirectoryInfo[] subDirectories = directoryInfo.GetDirectories();            

            bool isUserDirectoryExists = false; // user folder doesn't exist 
            foreach(DirectoryInfo currentSubDirectory in subDirectories)
            {
                if (currentSubDirectory.Name.Equals(Login))
                {
                    UserDirectory = currentSubDirectory;
                    isUserDirectoryExists = true;
                    break;
                }
            }

            if (isUserDirectoryExists)
            {
                StorageUsed = UserDirectory.EnumerateFiles("*", SearchOption.AllDirectories).Sum(file => file.Length);
            }
            else
            {
                // create new directory for user
                directoryInfo.CreateSubdirectory(Login);
                StorageUsed = 0;
            }
        }
    }
}
