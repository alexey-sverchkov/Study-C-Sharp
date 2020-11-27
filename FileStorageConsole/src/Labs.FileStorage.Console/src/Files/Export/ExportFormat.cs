using System;
using System.Collections.Generic;
using System.Linq;

namespace Labs.FileStorage.Console.Files.Export
{
    public enum ExportFormat
    {
        NoSpecified = 0, // to make sure that we not miss this field to assign
        Json = 1,
        Xml = 2
    }    
}
