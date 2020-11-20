using System;
using System.Collections.Generic;
using System.Linq;

namespace Labs.FileStorage.Console.Files.Export
{
    public enum ExportFormat
    {
        NoSpecified, // to make sure that we not miss this field to assign
        Json,
        XML     
    }    
}
