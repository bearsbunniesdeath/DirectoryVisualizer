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
        /// <summary>
        /// Get a list of first-level directories
        /// </summary>
        List<String> GetListOfDirectories();

        /// <summary>
        /// Get a list of first-level files
        /// </summary>
        List<String> GetListOfFiles();

        /// <summary>
        /// Get the size of the directory in bytes
        /// </summary>
        /// <returns>The size of the directory in bytes</returns>
        long GetSize();

        /// <summary>
        /// Gets the size of a child directory in bytes
        /// </summary>
        /// <param name="name">The name of the directory in this directory</param>
        /// <returns>The size of the directory in bytes</returns>
        long GetSizeOfDirectory(string name);

        /// <summary>
        /// Gets the size of a child file in the directory in bytes
        /// </summary>
        /// <param name="name">A name of the file in the directory</param>
        /// <returns>The size of the file in bytes</returns>
        long GetSizeOfFile(string name);
    }
}
