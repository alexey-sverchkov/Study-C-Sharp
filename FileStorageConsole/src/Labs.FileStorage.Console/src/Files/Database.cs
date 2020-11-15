﻿using Labs.FileStorage.Console.src;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}