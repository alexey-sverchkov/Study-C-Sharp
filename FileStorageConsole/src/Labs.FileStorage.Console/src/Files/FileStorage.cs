using System.Collections.Generic;
using System.IO;

namespace lab_02.Files
{
    public class FileStorage
    {
        /* Properties and Fields */
        private readonly List<ExtendedFileInfo> files;

        /* Constructors */
        public FileStorage(List<FileMetainformation> filesMetainformation)
        {
            files = new List<ExtendedFileInfo>();
            foreach(FileMetainformation fm in filesMetainformation)
            {
                FileInfo currentFile = new FileInfo(fm.Name + "." + fm.Extension);
                files.Add(new ExtendedFileInfo(currentFile, fm));
            }
        }
    }
}
