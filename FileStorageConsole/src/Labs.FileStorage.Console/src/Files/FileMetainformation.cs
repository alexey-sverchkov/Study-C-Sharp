using System;

namespace lab_02.Files
{
    [Serializable]
    public class FileMetainformation
    {
        // properties with fields
        public  String   Name { get; set; } // file name
        public  String   Extension { get; set; }

        // REVIEW: ulong is always >= 0
        private ulong    size;
        public  ulong    SizeInBytes {
            get => size;
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
        public  double   SizeInKilobytes => (double)size / 1024;

        public  double   SizeInMegabytes => SizeInKilobytes / 1024;

        public  DateTime CreationDate { get; set; }

        // REVIEW: the same
        private uint     downloadsNumber = 0;
        public  uint     DownloadsNumber
        {
            get => downloadsNumber;
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
                                         $"size: {SizeInBytes} bytes, " + $"creation date: {CreationDate.ToString("F")}, " +
                                         $"number of downloads: {DownloadsNumber}";
        }
    }
}
