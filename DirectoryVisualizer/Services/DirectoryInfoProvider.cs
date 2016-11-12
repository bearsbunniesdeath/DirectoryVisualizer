using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryVisualizer.Services
{
    class DirectoryInfoProvider : IDirectoryInfoProvider
    {
        private DirectoryInfo dirInfo;
     
        public DirectoryInfoProvider(string dirPath)
        {
            dirInfo = new DirectoryInfo(dirPath);
        }

        public DirectoryInfoProvider(DirectoryInfo dirInfo)
        {
            this.dirInfo = dirInfo;
        }
             
        public List<string> GetListOfDirectories()
        {
            DirectoryInfo[] dirs = dirInfo.GetDirectories();
            List<string> dirPaths = new List<string>();
            foreach (DirectoryInfo dir in dirs)
            {
                dirPaths.Add(dir.Name);
            }
            return dirPaths;
        }
        
        public List<string> GetListOfFiles()
        {
            FileInfo[] files = dirInfo.GetFiles();
            List<string> filePaths = new List<string>();
            foreach(FileInfo file in files)
            {
                filePaths.Add(file.Name);
            }
            return filePaths;
        }
       
        public long GetSize()
        {
            return CalculateDirectorySize(dirInfo);
        }
        
        public long GetSizeOfDirectory(string name)
        {          
            //Get the directory we want to look at
            DirectoryInfo dir = dirInfo.GetDirectories().First(d => d.Name == name);

            return CalculateDirectorySize(dir);             
        }

        private long CalculateDirectorySize(DirectoryInfo dirInfo)
        {
            long size = 0;

            //First check the files
            FileInfo[] files = dirInfo.GetFiles();
            foreach (FileInfo file in files)
            {
                size += file.Length;
            }

            //Next iterate through the directories
            DirectoryInfo[] dirs = dirInfo.GetDirectories();
            foreach(DirectoryInfo dir in dirs)
            {
                size += CalculateDirectorySize(dir);
            }

            return size;
        }
       
        public long GetSizeOfFile(string name)
        {
            FileInfo file = dirInfo.GetFiles().First(f => f.Name == name);
            return file.Length;
        }
    }
}
