using DirectoryVisualizer.Models;
using DirectoryVisualizer.Services;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryVisualizer.Models
{
    class DirectoryInfoProxy
    {
        private string _path;
        private string _name;
        private IDirectoryInfoProvider _provider;
     
        public DirectoryInfoProxy(string dirPath)
        {
            _path = Path.GetDirectoryName(dirPath);
            _name = new DirectoryInfo(dirPath).Name;
            _provider = new DirectoryInfoProvider(dirPath);
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public long CalculateDirectorySize()
        {
            return _provider.GetSize();        
        }              
    }
}
