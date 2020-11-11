using System;
using System.IO;

namespace lab_02.Files
{
    [Serializable]
    public class FileMetainformation
    {
        // properties with fields
        public  String   Name { get; set; } // file name
        public  String   Extension { get; set; }
                
        public  ulong    SizeInBytes { get; set; }
        public  double   SizeInKilobytes => (double)SizeInBytes / 1024;

        public  double   SizeInMegabytes => SizeInKilobytes / 1024;

        public  DateTime CreationDate { get; set; }
       
        public uint DownloadsNumber { get; set; }

        // constructors
        public FileMetainformation(String name, String extension, ulong sizeInBytes, DateTime creationDate)
        {
            Name = name;
            Extension = extension;
            SizeInBytes = sizeInBytes;
            CreationDate = creationDate;
        }

        public FileMetainformation(FileInfo file)
        {
            Name = file.Name;
            Extension = file.Extension;
            SizeInBytes = (ulong)file.Length;
            CreationDate = file.CreationTime;
        }


        // Methods
        public override String ToString()
        {
            return $"FileMetainformation [ name: {Name}, " +
                                         $"extension: {Extension}, " +
                                         $"size: {SizeInBytes} bytes, " + $"creation date: {CreationDate.ToString("F")}, " +
                                         $"number of downloads: {DownloadsNumber}";
        }
    }
}
