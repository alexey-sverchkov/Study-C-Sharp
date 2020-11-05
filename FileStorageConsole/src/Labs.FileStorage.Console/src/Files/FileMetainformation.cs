using System;
using System.Collections.Generic;
using System.Text;

namespace lab_02.src.Files
{
    [Serializable]
    public class FileMetainformation
    {
        // properties with fields
        public  String   Name { get; set; } // file name
        public  String   Extension { get; set; }

        private ulong    size;
        public  ulong    SizeInBytes {
            get
            {
                return size;
            }
            set
            {
                if (value >= 0)
                {
                    size = value;
                }
                else
                {
                    Console.WriteLine("Warning, size of file can't be less than zero");
                    size = 0;
                }
            }
        }
        public  double   SizeInKilobytes
        {
            get
            {
                return (double)size / 1024;
            }
        }

        public  double   SizeInMegabytes
        {
            get
            {
                return SizeInKilobytes / 1024;
            }
        }

        public  DateTime CreationDate { get; set; }

        private uint     downloadsNumber = 0;
        public  uint     DownloadsNumber
        {
            get
            {
                return downloadsNumber;
            }
            set
            {
                if (value >= 0)
                {
                    downloadsNumber = value;
                }
                else
                {
                    Console.WriteLine("Warning, number of downloads of file can't be less than zero");
                    downloadsNumber = 0;
                }
            }
        }

        // constructors
        public FileMetainformation(String name, String extension, ulong sizeInBytes, DateTime creationDate)
        {
            Name = name;
            Extension = extension;
            SizeInBytes = sizeInBytes;
            CreationDate = creationDate;
        }


        // Methods
        public override String ToString()
        {
            return $"FileMetainformation [ name: {Name}, " +
                                         $"extension: {Extension}, " +
                                         $"size: {SizeInBytes} bytes, " + $"creation date: {CreationDate.ToString("F")}" +
                                         $"number of downloads: {DownloadsNumber}";
        }
    }
}
