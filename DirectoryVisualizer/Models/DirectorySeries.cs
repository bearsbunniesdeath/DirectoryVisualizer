using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryVisualizer.Models
{
    class DirectorySeries
    {
        private string _name;
        private long _size;

        public DirectorySeries(string name, long size) 
        {
            _name = name;
            _size = size;
        }

        public string Name
        {
            get
            {
                return _name;
            }
           
        }

        public long Size
        {
            get
            {
                return _size;
            }
        }           
    }
}
