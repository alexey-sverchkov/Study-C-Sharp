using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Labs.FileStorage.Console.Domain.Files;

namespace Labs.FileStorage.Console.Data.Files
{
    public class FileManager
    {
        /* Methods */
        public void WriteMetainformationToFile(FileMetainformation fileMetainformation, String filepath)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filepath, FileMode.Open))
            {
                formatter.Serialize(fs, fileMetainformation);
            }
        }

        public void WriteMetainformationToFile(ICollection<FileMetainformation> collectionOfMetainformation, String filepath)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filepath, FileMode.Open))
            {
                formatter.Serialize(fs, collectionOfMetainformation);
            }
        }

        public ICollection<FileMetainformation> GetMetainformationFromFile(String filepath)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filepath, FileMode.Open))
            {
                ICollection<FileMetainformation> deserializedMetainformation = (ICollection<FileMetainformation>)formatter.Deserialize(fs);
                return deserializedMetainformation;
            }
        }
    }
}
