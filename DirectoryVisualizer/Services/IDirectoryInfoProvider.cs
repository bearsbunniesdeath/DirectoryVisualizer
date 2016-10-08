using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryVisualizer.Services
{
    interface IDirectoryInfoProvider
    {
        List<String> GetListOfDirectories();
        List<String> GetListOfFiles();
        long GetSizeOfDirectory(string name);
        long GetSizeOfFile(string name);
    }
}
