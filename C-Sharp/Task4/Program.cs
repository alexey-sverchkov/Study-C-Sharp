using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string oldText = "is";
            string newText = "IS";

            string dirPath = "../../Txt";
            String mask = "^[a-zA-Z]+$";            

            DirectoryInfo di = new DirectoryInfo(dirPath);
            FileInfo[] fiArr = di.GetFiles();

            FindAndReplaceInAllFiles(di, mask, oldText, newText);         
        }

        // returns new text after replacement
        /* @params:
         * filepath - path to file
         * oldText  - text, which would be replaced
         * newText  - text, which replaces oldText
         */
        static String getReplacedText(String filepath, String oldText, String newText)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filepath))
                {
                    String textInFile = sr.ReadToEnd();
                    String newTextInFile = textInFile.Replace(oldText, newText);
                    return newTextInFile;
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException(ex.Message, ex.StackTrace);
            }
        }

        // replace text in file with the given one
        /* @params:
         * filepath - path to file where text would be replaced
         * text     - text, which replaces old text in file
         */
        static void ReplaceTextInFile(String filepath, String text)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filepath, false))
                {
                    sw.WriteLine(text);
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException(ex.Message, ex.StackTrace);
            }
        }

        // replaces given old text with new text in all files in given girectory, inlcuding subdirectories
        /* @params:
         * dir       - directory, in which the replacement is made
         * mask      - regex to filter filenames
         * oldText   - text, which would be replaced
         * newText   - text, text, which replaces oldText
         * recursive - flag if current directory contains subdirectory (or subdirectories)
         */
        public static void FindAndReplaceInAllFiles(DirectoryInfo dir, String mask, String oldText, String newText, bool recursive = false)
        {
            foreach (FileInfo file in dir.GetFiles()
                .Where(file => Regex.IsMatch(file.Name, mask)))
            {
                String textToReplace = getReplacedText(file.FullName, oldText, newText);
                ReplaceTextInFile(file.FullName, textToReplace);
            }
            DirectoryInfo[] subdirectores = dir.GetDirectories();
            if (subdirectores.Length > 0) { recursive = true; } // check if there is subdirectories in current directory
            if (recursive)
            {
                foreach (DirectoryInfo subdir in subdirectores)
                {
                    FindAndReplaceInAllFiles(subdir, mask,  oldText, newText, recursive);
                }
            }           
        }
    }
}
