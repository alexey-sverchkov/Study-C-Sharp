using System;
using System.IO;

namespace Labs.FileStorage.Console.Files
{
    [Serializable]
    public class FileMetainformation
    {
        // properties with fields
        public  String   Name { get; set; } // file name
        public  String   Extension { get; set; }
                
        public  ulong    SizeInBytes { get; set; }              

        public  DateTime CreationDate { get; set; }
       
        public uint DownloadsNumber { get; set; }     
        
        // hash of file
        public String Hash { get; set; }

        /* Constructors  */

        public FileMetainformation(FileInfo file)
        {
            Name = file.Name;
            Extension = file.Extension;
            SizeInBytes = (ulong)file.Length;
            CreationDate = file.CreationTime;
            FileIntegrityChecker fic = new FileIntegrityChecker();
            Hash = fic.CalculateMD5(file.FullName);
        }


        /* Methods */
        public override String ToString()
        {
            return $"FileMetainformation [ name: {Name}, " +
                                         $"extension: {Extension}, " +
                                         $"size: {SizeInBytes} bytes, " + $"creation date: {CreationDate.ToString("F")}, " +
                                         $"number of downloads: {DownloadsNumber}";
        }                

        // prints metainformation
        // @params:
        // type: 's' - short, includes name, extension and size
        // type: 'f' - full,  includes name, extension, size, creation date and number of downloads 
        public void Print(char type)
        {
            switch (type)
            {
                case 's':
                    {
                        System.Console.WriteLine($"- file name: {Name}");
                        System.Console.WriteLine($"- file extension: {Extension}");
                        System.Console.WriteLine($"- file size: {SizeInBytes} bytes");
                        break;
                    }
                case 'f':
                    {
                        System.Console.WriteLine($"- file name: {Name}");
                        System.Console.WriteLine($"- file extension: {Extension}");
                        System.Console.WriteLine($"- file size: {SizeInBytes} bytes");
                        System.Console.WriteLine($"- creation date: {CreationDate.ToString("F")}");
                        System.Console.WriteLine($"- number of downloads: {DownloadsNumber}");                                                
                        break;
                    }
                default:
                    {
                        throw new FormatException($"Error: type {type} is unknown to use Print()");                        
                    }
            }
        }        
    }
}
