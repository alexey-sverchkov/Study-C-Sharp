using System;
using System.IO;
using System.Security.Cryptography;

namespace Labs.FileStorage.Console.Files
{
    public class FileIntegrityChecker
    {
        /* Constructors */

        public FileIntegrityChecker()
        {
            // ctor
        }


        /* Methods */

        // calculates hash of file
        // @params:
        // filename - name of the file for which the hash will be calculated 
        public string CalculateMD5(String filename)
        {
            using (MD5 md5 = MD5.Create())
            {
                using (FileStream stream = File.OpenRead(filename))
                {
                    byte[] hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLower();
                }
            }
        }
    }
}
