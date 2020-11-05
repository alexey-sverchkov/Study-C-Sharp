using System;
using System.Collections.Generic;
using System.Text;

namespace lab_02.src.Files
{
    public class FileMetainformation
    {
        // properties with fields
        public  String   Name { get; set; } // file name
        public  String   Extension { get; set; }

        private ulong    size;
        public  ulong    Size {
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
        public FileMetainformation(String name, String extension, ulong size, DateTime creationDate)
        {
            Name = name;
            Extension = extension;
            Size = size;
            CreationDate = creationDate;
        }


        // Methods
        public override String ToString()
        {
            return $"FileMetainformation [ name: {Name}, " +
                                         $"extension: {Extension}, " +
                                         $"size: {Size}, " + $"creation date: {CreationDate.ToString("F")}" +
                                         $"number of downloads: {DownloadsNumber}";
        }
    }
}
