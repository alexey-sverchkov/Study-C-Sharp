using System;
using System.Collections.Generic;
using System.Linq;

namespace Labs.FileStorage.Console.Files.Export
{
    public enum ExportFormat
    {
        NoSpecified = 0, // to make sure that we not miss this field to assign
        Json = 1,
        Xml = 2,
        Yaml = 3
    }

    public static class ExportFormatExtensions
    {
        /* Properties and Fields */

        // key - export format, value represents state of availableness (true - available, false - unavailable)
        private static Dictionary<ExportFormat, bool> _exportFormats = new Dictionary<ExportFormat, bool>();

        static ExportFormatExtensions()
        {
            foreach(ExportFormat value in Enum.GetValues(typeof(ExportFormat)))
            {
                _exportFormats[value] = false;
            }

            // Json is available out of box
            _exportFormats[ExportFormat.Json] = true;

            // mark available ExportFormat types - if such handler exists - true, otherwise - false
            foreach (var item in ApplicationContext.MetainformationExporters)
            {
                if (item.GetType().Name.ToLower().StartsWith("xml"))
                {
                    _exportFormats[ExportFormat.Xml] = true;
                }
                else if (item.GetType().Name.ToLower().StartsWith("yaml"))
                {
                    _exportFormats[ExportFormat.Yaml] = true;
                }

                // TODO: add other formats, when they appear
            }
        }

        // REVIEW: method name should start from capital letter.
        public static bool isAvailable(ExportFormat exportFormat)
        {
            return _exportFormats[exportFormat];
        }
    }
}
