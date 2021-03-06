﻿using System;
using System.Collections.Generic;

namespace Labs.FileStorage.Console.Files.Export
{
    public abstract class MetainformationExporter : IExportable
    {
        /* Properties and fields */
        public ExportFormat Format { get; set; }
        public ICollection<FileMetainformation> FilesMetainformation { get; set; }


        /* Constructors */
        public MetainformationExporter(ICollection<FileMetainformation> filesMetainformation)
        {
            FilesMetainformation = filesMetainformation;
        }

        /* Methods */
        public abstract void Export(String filename);
    }
}
