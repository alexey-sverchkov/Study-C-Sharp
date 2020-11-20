using System;
using System.Collections.Generic;

namespace Labs.FileStorage.Console.Files.Export
{
    public sealed class ExportFormat
    {
        public static readonly ExportFormat Undefined = new ExportFormat("undefined"); // to make sure that we not miss this field to assign
        public static readonly ExportFormat Json = new ExportFormat("json");
        public static readonly ExportFormat XML = new ExportFormat("xml");

        private static readonly SortedList<String, ExportFormat> Values = new SortedList<string, ExportFormat>();
        private        readonly String Value;

        private ExportFormat(String value)
        {
            Value = value;
            Values.Add(value, this);
        }

        public static implicit operator ExportFormat(String value) 
        {
            return Values[value];
        }

        public static implicit operator String(ExportFormat value)
        {
            return value.Value;
        }
    }    
}
