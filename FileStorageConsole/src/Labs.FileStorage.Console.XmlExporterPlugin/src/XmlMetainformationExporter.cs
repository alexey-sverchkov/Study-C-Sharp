﻿using Labs.FileStorage.Console.Business.Files.Export;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Labs.FileStorage.Console.Business.Domain.Files;

namespace Labs.FileStorage.Console.Business.Plugins.Export.XmlExporterPlugin
{
    public class XmlMetainformationExporter : MetainformationExporter
    {
        public XmlMetainformationExporter(ICollection<FileMetainformation> filesMetainformation)
            : base(filesMetainformation)
        {
            Format = ExportFormat.Xml;
        }

        public override void Export(String filename)
        {
            // open file stream
            using (FileStream file = File.Create(filename))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(HashSet<FileMetainformation>));
                serializer.Serialize(file, FilesMetainformation);
            }
        }
    }
}
